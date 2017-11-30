using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

//RFID
using nsAlienRFID2;

//DB
using MySql.Data.MySqlClient;

//AForge Video Stream
using AForge.Video.DirectShow;
using MjpegProcessor;

//OpenALPR
using openalprnet;

//Motion Detection
using AForge.Vision.Motion;
using KOU_RFID_Plaka.Utils; //Depended On Old Project
using System.IO;
using System.Reflection;

namespace Campus_Gate_KOU
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        MjpegDecoder input_mjpeg, output_mjpeg;
        public string plate = ""; 

        public MySqlConnection conn;
        public const string str_conn = "Server=localhost;Database=kks;Uid=root;Pwd=;";

        //Some Necessary Variables
        public string inTrackNo = "";
        public string outTrackNo = "";
        public string inRfid = "";
        public string outRfid = "";
        public bool inCtrl = false;
        public bool outCtrl = false;

        //RFID Connections
        private clsReader mReader;
        private ComInterface mReaderInterface;

        //Get Current Directory For Saving Images To Folder
        string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath.Substring(0, (Application.ExecutablePath.Length - 19)));

        //Disable X Button
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Fitting Screen
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            //Fitting Stream -> PictureBoxes
            this.Controls.Add(input_cam);
            this.input_cam.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(output_cam);
            this.output_cam.SizeMode = PictureBoxSizeMode.StretchImage;
            this.logoPB.SizeMode = PictureBoxSizeMode.StretchImage;
            

            /*RFID Reader Inits*/
            mReader = new clsReader();
            mReaderInterface = ComInterface.enumTCPIP;
            mReader.Disconnect();

            try
            {
                if (mReaderInterface == ComInterface.enumTCPIP)
                    mReader.InitOnNetwork("192.168.1.100", 23);
                else
                    mReader.InitOnCom();

                string result = mReader.Connect();

                if (mReader.IsConnected)
                {
                    if (mReaderInterface == ComInterface.enumTCPIP)
                    {
                        this.Cursor = Cursors.Arrow;
                        if (!mReader.Login("alien", "password"))
                        {
                            mReader.Disconnect();
                            return;
                        }
                    }
                    mReader.AutoMode = "On";
                }
                //Stream Inits
                input_mjpeg = new MjpegDecoder();
                input_mjpeg.FrameReady += input_mjpeg_frameReady;

                output_mjpeg = new MjpegDecoder();
                output_mjpeg.FrameReady += output_mjpeg_frameReady;

                add_cam();

                //Timers
                antennaTimer1.Enabled = true;
                antennaTimer2.Enabled = true;
            }
            catch
            {
                inputInfoPanel.BackColor = Color.Red;
            }

            //Motion Detection Variables Inits
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in fic)
            {
                metroComboBox1.Items.Add(item.Name);
            }
            metroComboBox1.SelectedIndex = 0;
            detector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionBorderHighlighting());
            detector_ks = 0; // Init value
        }

        //If Free Entry Clicked
        public void authControl()
        {
            addRecordTile.Enabled = false;
            activate_cam.Enabled = false;
            MotionButton.Enabled = false;
        }

        //MySql Connection Class
        private void connectMySql()
        {
            closeMysqlConn();
            conn = new MySqlConnection(str_conn);

            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                MetroFramework.MetroMessageBox.Show(this, "Veritabanı Bağlantısı Kurulamadı" + e.Message, "KOU Surveillance", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }
        
        //Close MySql Connection Class
        private void closeMysqlConn()
        {
            try
            {
                if (conn != null)
                    conn.Close();
            }
            catch(Exception e)
            {
                MetroFramework.MetroMessageBox.Show(this, "Veritabanı Bağlantısı Kapatılamadı" + e.Message, "KOU Surveillance", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        //{If RFID No Exist In DB returns True} {Else Return False}
        public bool inControl()
        {
            closeMysqlConn();
            connectMySql();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT u.rfid_no, u.sicil_no, u.plate, u.image, u.name, u.lastname, u.list, u.fakulte, u.bolum " +
                                "FROM users u, faculties f, titles t " +
                                "WHERE  u.rfid_no = '" + rfidInTB.Text + "'";

            MySqlDataReader dr = cmd.ExecuteReader();
            if(dr.FieldCount > 0)
            {
                while(dr.Read())
                {
                    nameInTB.Text = dr.GetString("name");
                    surnameInTB.Text = dr.GetString("lastname");
                    facultyInTB.Text = dr.GetString("fakulte");
                    plateCarInTB.Text = dr.GetString("plate");
                    trackNoInTB.Text = dr.GetString("sicil_no");

                    string securityLevel = dr.GetString("list");

                    if (securityLevel == "yellow")
                    {
                        inputInfoPanel.BackColor = Color.Yellow;
                        nameLabel.BackColor = Color.Yellow;
                        surnameLabel.BackColor = Color.Yellow;
                        trackNoLabel.BackColor = Color.Yellow;
                        facultyLabel.BackColor = Color.Yellow;
                        plateLabel.BackColor = Color.Yellow;
                        photoInLabel.BackColor = Color.Yellow;
                    }
                    else if(securityLevel == "red" )
                    {
                        inputInfoPanel.BackColor = Color.Red;
                        nameLabel.BackColor = Color.Red;
                        surnameLabel.BackColor = Color.Red;
                        trackNoLabel.BackColor = Color.Red;
                        facultyLabel.BackColor = Color.Red;
                        plateLabel.BackColor = Color.Red;
                        photoInLabel.BackColor = Color.Red;
                    }
                    else if (securityLevel == "green")
                    {
                        inputInfoPanel.BackColor = Color.Green;
                        nameLabel.BackColor = Color.Green;
                        surnameLabel.BackColor = Color.Green;
                        trackNoLabel.BackColor = Color.Green;
                        facultyLabel.BackColor = Color.Green;
                        plateLabel.BackColor = Color.Green;
                        photoInLabel.BackColor = Color.Green;
                    }
                    else
                    {
                        inputInfoPanel.BackColor = Color.White;
                    }

                    ppIn.Image = Bitmap.FromFile(appPath + "\\userProfImg\\" + trackNoInTB.Text + nameInTB.Text + ".jpg");
                }
            }

            if (dr.HasRows)
                inCtrl = true;
            else
                inCtrl = false;

            dr.Close();

            if(!inCtrl)
            {
                if(trackNoInTB.Text != "" || rfidInTB.Text != "")
                {
                    nameInTB.Enabled = false;
                    surnameInTB.Enabled = false;

                    nameInTB.Text = "";
                    surnameInTB.Text = "";
                    trackNoInTB.Text = "";
                    rfidInTB.Text = "";
                    facultyInTB.Text = "";
                }

                inputInfoPanel.BackColor = Color.White;
                return false;
            }
            else
            {
                nameLabel.Visible = true;
                surnameLabel.Visible = true;
                nameInTB.Enabled = true;
                surnameInTB.Enabled = true;

                closeMysqlConn();
                return true;
            }
        }

        public bool outControl()
        {
            closeMysqlConn();
            connectMySql();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT u.rfid_no, u.sicil_no, u.plate, u.image, u.name, u.lastname, u.list, u.fakulte, u.bolum " +
                                "FROM users u, faculties f, titles t " +
                                "WHERE u.rfid_no = '" + rfidOutTB.Text + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.FieldCount > 0)
            {
                while (dr.Read())
                {
                    nameOutTB.Text = dr.GetString("name");
                    surnameOutTB.Text = dr.GetString("lastname");
                    facultyOutTB.Text = dr.GetString("fakulte");
                    plateCarOutTB.Text = dr.GetString("plate");
                    trackNoOutTB.Text = dr.GetString("sicil_no");

                    string securityLevel = dr.GetString("list");

                    if (securityLevel == "yellow")
                    {
                        outputPanelInfo.BackColor = Color.Yellow;
                        nameOutLabel.BackColor = Color.Yellow;
                        surnameOutLabel.BackColor = Color.Yellow;
                        trackNoOutLabel.BackColor = Color.Yellow;
                        facultyOutLabel.BackColor = Color.Yellow;
                        plateOutLabel.BackColor = Color.Yellow;
                        photoOutLabel.BackColor = Color.Yellow;
                    }
                    else if (securityLevel == "red")
                    {
                        outputPanelInfo.BackColor = Color.Red;
                        nameOutLabel.BackColor = Color.Red;
                        surnameOutLabel.BackColor = Color.Red;
                        trackNoOutLabel.BackColor = Color.Red;
                        facultyOutLabel.BackColor = Color.Red;
                        plateOutLabel.BackColor = Color.Red;
                        photoOutLabel.BackColor = Color.Red;
                    }
                    else if (securityLevel == "green")
                    {
                        outputPanelInfo.BackColor = Color.Green;
                        nameOutLabel.BackColor = Color.Green;
                        surnameOutLabel.BackColor = Color.Green;
                        trackNoOutLabel.BackColor = Color.Green;
                        facultyOutLabel.BackColor = Color.Green;
                        plateOutLabel.BackColor = Color.Green;
                        photoOutLabel.BackColor = Color.Green;
                    }
                    else
                    {
                        outputPanelInfo.BackColor = Color.White;
                    }

                    ppOut.Image = Bitmap.FromFile(appPath + "\\userProfImg\\" + trackNoOutTB.Text + nameOutTB.Text + ".jpg");
                }
            }
            if (dr.HasRows)
                outCtrl = true;
            else
                outCtrl = false;
            dr.Close();

            if (!outCtrl)
            {
                if ((trackNoInTB.Text != "") || (rfidInTB.Text != ""))
                {
                    nameOutTB.Enabled = false;
                    surnameInTB.Enabled = false;

                    nameOutTB.Text = "";
                    surnameOutTB.Text = "";
                    facultyOutTB.Text = "";
                    plateCarOutTB.Text = "";
                    trackNoOutTB.Text = "";
                }
                outputPanelInfo.BackColor = Color.White;
                return false;
            }
            else
            {
                nameOutLabel.Visible = true;
                surnameOutLabel.Visible = true;
                nameOutTB.Enabled = true;
                surnameOutTB.Enabled = true;

                closeMysqlConn();

                return true;
            }
        }

/*----------------------------------------KEEP LOGS START-----------------------------------------------------------------*/

        //Keep Log For Registered RFID Numbers (Input Gate)
        public void rfidInControlLog(string gateName)
        {
            connectMySql();
            MySqlTransaction tr = conn.BeginTransaction();
            MySqlCommand cmd = conn.CreateCommand();
            string snapDate = Helper.GetDatabaseDateFormat();
            cmd.CommandText = "INSERT INTO logs_( sicil_no, rfid, plate, input_entry, input_date)" + 
                              "VALUES('" + trackNoInTB.Text + "', '" + rfidInTB.Text + "','" + plateCarInTB.Text + "','" + gateName + "','" + snapDate + "')";

            try
            {
                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Eklenirken Bir Hata Oluştu!" + ex.Message, "KOU Surveillance - Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            closeMysqlConn();
        }

        //Input Gate Non-RFID Log
        public void nonRfidInControlLog(string gateName)
        {
            connectMySql();
            MySqlTransaction tr = conn.BeginTransaction();
            MySqlCommand cmd = conn.CreateCommand();
            string snapDate = Helper.GetDatabaseDateFormat();
            cmd.CommandText = "INSERT INTO logs_nonuser (rfid, plate, input_date, input_entry)" +
                              "VALUES('" + rfidInTB.Text + "','" + plateCarInTB.Text + "','" + snapDate + "','" + gateName + "')";

            try
            {
                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Eklenirken Bir Hata Oluştu!" + ex.Message, "KOU Surveillance - Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            closeMysqlConn();
        }

        //Keep Log For Registered RFID Numbers(Output Gate) 
        private void rfidOutControlLog(string gateName)    //Antenna No Here (after)
        {
            connectMySql();
            MySqlTransaction tr = conn.BeginTransaction();
            MySqlCommand cmd = conn.CreateCommand();
            string snapDate = Helper.GetDatabaseDateFormat();
            cmd.CommandText = "INSERT INTO logs_ (sicil_no, rfid, plate, output_entry, output_date)" +
                           "VALUES('" + trackNoOutTB.Text + "', '" + rfidOutTB.Text + "','" + plateCarOutTB.Text + "','" + gateName + "','" + snapDate + "')";

            try 
            {
                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Eklenirken Bir Hata Oluştu!" + ex.Message, "KOU Surveillance - Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            closeMysqlConn();
        }

        //Output Gate Non-RFID Log
        public void nonRfidOutControlLog(string gateName)
        {
            connectMySql();
            MySqlTransaction tr = conn.BeginTransaction();
            MySqlCommand cmd = conn.CreateCommand();
            string snapDate = Helper.GetDatabaseDateFormat();
            cmd.CommandText = "INSERT INTO logs_nonuser (rfid, plate, output_date, output_entry)" +
                              "VALUES('" + rfidOutTB.Text + "','" + plateCarOutTB.Text + "','" + snapDate + "','" + gateName + "')";

            try
            {
                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Eklenirken Bir Hata Oluştu!" + ex.Message, "KOU Surveillance - Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            closeMysqlConn();
        }

/*------------------------------------------KEEP LOGS END---------------------------------------------------------------*/        

/*-----------------------------------------ACTIVATE CAMERA START--------------------------------------------------------*/

        //Add Camera
        public void add_cam()
        {
            input_mjpeg.ParseStream(new Uri("http://192.168.1.108/cgi-bin/video.cgi"), "admin", "admin");
            output_mjpeg.ParseStream(new Uri("http://192.168.1.108/cgi-bin/video.cgi"), "admin", "admin");
        }

        /* Fill PictureBoxFrames > Video */
        private void output_mjpeg_frameReady(object sender, FrameReadyEventArgs e)
        {
            output_cam.Image = e.Bitmap;
        }

        private void input_mjpeg_frameReady(object sender, FrameReadyEventArgs e)
        {
            input_cam.Image = e.Bitmap;
        }
        /* Fill PictureBoxFrames > Video */

        //Activate Cameras
        private void activate_cam_Click(object sender, EventArgs e)
        {
            if (activate_cam.Text == "Kamera Deaktif")
            {
                //Open Cams
                input_mjpeg.ParseStream(new Uri("http://192.168.1.108/cgi-bin/video.cgi"), "admin", "admin");
                output_mjpeg.ParseStream(new Uri("http://192.168.1.108/cgi-bin/video.cgi"), "admin", "admin");
                activate_cam.Text = "Kamera Aktif";
                activate_cam.Style = MetroFramework.MetroColorStyle.Green;
            }
            else
            {
                //Close Cams
                input_mjpeg.StopStream();
                input_cam.InitialImage.Dispose(); // Edit After
                output_mjpeg.StopStream();

                activate_cam.Text = "Kamera Deaktif";
                activate_cam.Style = MetroFramework.MetroColorStyle.Red;
            }
        }

/*--------------------------------------------ACTIVATE CAMERA END-----------------------------------------------------*/

/*---------------------------------------------RFID ENTRY & EXIT START------------------------------------------------*/
        
        //Entry Function
        private void entry()
        {
            try
            {
                string inTagResponse = null;
                string inTagID = null;

                inTagResponse = mReader.G2Read(eG2Bank.EPC, "2", "6");
                int len = inTagResponse.Length;
                if (len >= 35)
                {
                    inTagID = inTagResponse.Substring(0, 35);
                    string inVal = inTagID.Trim();

                    ArrayList entryID = new ArrayList();

                    for (int i = 0; i < 8; i++)
                    {
                        if (Convert.ToString(inVal[i + 27]) != " ")
                            entryID.Add(inVal[i + 27]);
                    }

                    StringBuilder builder = new StringBuilder();
                    foreach (char gvalue in entryID)
                    {
                        builder.Append(gvalue);
                    }

                    int gdecValue = Convert.ToInt32(builder.ToString(), 16);

                    rfidInTB.Text = Convert.ToString(gdecValue);
                }
                else
                {
                    inTagID = inTagResponse.Substring(0, 23);
                    rfidInTB.Text = inTagID.Trim();
                }

                if (inControl())
                {
                    if (trackNoInTB.Text != inTrackNo)
                    {
                        rfidInControlLog("0");// mReader.ProgAntenna
                        inTrackNo = trackNoInTB.Text;
                    }
                    closeMysqlConn();
                }
                else
                {
                    if (rfidInTB.Text != inRfid)
                    {
                        nonRfidInControlLog("0");
                        inRfid = rfidInTB.Text;
                    }
                    closeMysqlConn();
                }

            }
            catch
            {
                rfidInTB.Text = "";
                nameInTB.Text = "";
                surnameInTB.Text = "";
                facultyInTB.Text = "";
                plateCarInTB.Text = "";
                trackNoInTB.Text = "";
                ppIn.Image = null;
                
            }
        }

        //Exit Function
        private void exit()
        {
            try
            {
                string outTagResponse = null;
                string outTagID = null;

                outTagResponse = mReader.G2Read(eG2Bank.EPC, "2", "6");
                int len = outTagResponse.Length;
                if (len >= 35)
                {
                    outTagID = outTagResponse.Substring(0, 35);
                    string outVal = outTagID.Trim();

                    ArrayList exitID = new ArrayList();

                    for (int i = 0; i < 8; i++)
                    {
                        if (Convert.ToString(outVal[i + 27]) != " ")
                            exitID.Add(outVal[i + 27]);
                    }

                    StringBuilder builder = new StringBuilder();
                    foreach (char cvalue in exitID)
                    {
                        builder.Append(cvalue);
                    }

                    int cdecValue = Convert.ToInt32(builder.ToString(), 16);

                    rfidOutTB.Text = Convert.ToString(cdecValue);

                }
                else
                {
                    outTagID = outTagResponse.Substring(0, 23);
                    rfidOutTB.Text = outTagID.Trim();
                }

                if (outControl())
                {
                    if (trackNoOutTB.Text != outTrackNo)
                    {
                        rfidOutControlLog("1");// mReader.ProgAntenna
                        outTrackNo = trackNoOutTB.Text;
                    }
                    closeMysqlConn();
                }
                else
                {
                    if (rfidOutTB.Text != outRfid)
                    {
                        nonRfidOutControlLog("1");
                        outRfid = rfidOutTB.Text;
                    }
                    closeMysqlConn();
                }
            }
            catch
            {
                nameOutTB.Text = "";
                surnameOutTB.Text = "";
                facultyOutTB.Text = "";
                plateCarOutTB.Text = "";
                trackNoOutTB.Text = "";
                rfidOutTB.Text = "";
                ppOut.Image = null;
            }

            closeMysqlConn();
        }
/*---------------------------------------RFID ENTRY & EXIT END------------------------------------------------*/
        
        //Authorize Exit
        public static void confirmClose()
        {
            AuthorizeLogOut aL = new AuthorizeLogOut(); 
            aL.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Reports rpr = new Reports();
            rpr.Show();
        }
        private void metroTile3_Click(object sender, EventArgs e)
        {
            UnregisteredRecords rpr = new UnregisteredRecords();
            rpr.Show();
        }

        /*-----------------------------------Timers Start----------------------------------*/
        private void antennaTimer1_Tick(object sender, EventArgs e)
        {
            try
            {
                mReader.ProgAntenna = "0";
                entry();
            }
            catch
            {
                rfidInTB.Text = "antennaTimer1 Catch";
            }
            finally
            {
               // inputProcessImageFile();
                plateReadInTB.Text = plate.ToString();
                bool entryRecordControl = inControl();
                resetControlTimer.Enabled = true;
            }
        }

        private void antennaTimer2_Tick(object sender, EventArgs e)
        {
            try
            {
                mReader.ProgAntenna = "1";
                exit();
            }
            catch
            {
                rfidOutTB.Text = "antennaTimer2 Catch";
            }
            finally
            {
                //outputProcessImageFile();
                plateReadOutTB.Text = plate.ToString();
                bool exitRecordControl = outControl();
                resetControlTimer.Enabled = true;
            }

        }
        /*-----------------------------------Timers End----------------------------------*/


        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

/*---------------------------------------------IMAGE PROCESS STUFF START------------------------------------------------------*/
        public Rectangle boundingRectangle(List<Point> points)
        {
            // Add checks here, if necessary, to make sure that points is not null,
            // and that it contains at least one (or perhaps two?) elements

            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);

            return new Rectangle(new Point(minX, minY), new Size(maxX - minX, maxY - minY));
        }

        private static System.Drawing.Image cropImage(System.Drawing.Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat); // bitmap hatası veriyor
        }

        public static Bitmap combineImages(List<System.Drawing.Image> images)
        {
            //read all images into memory
            Bitmap finalImage = null;

            try
            {
                var width = 0;
                var height = 0;

                foreach (var bmp in images)
                {
                    width += bmp.Width;
                    height = bmp.Height > height ? bmp.Height : height;
                }

                //create a bitmap to hold the combined image
                finalImage = new Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (var g = Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(Color.Black);

                    //go through each image and draw it on the final image
                    var offset = 0;
                    foreach (Bitmap image in images)
                    {
                        g.DrawImage(image, new Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (var image in images)
                {
                    image.Dispose();
                }
            }
        }
/*---------------------------------------------IMAGE PROCESS STUFF END------------------------------------------------------*/

        private void resetControls()
        {
            //licensePlatePic.Image = null;
            platesListBox.Items.Clear();
        }

        private void inputProcessImageFile()
        {
            Bitmap photoIn = (Bitmap)input_cam.Image.Clone();
            String config_file = Path.Combine(AssemblyDirectory, "openalpr.conf");
            String runtime_data_dir = Path.Combine(AssemblyDirectory, "runtime_data");
            //var region = rbUSA.Checked ? "us" : "eu";
            using (var calpr = new AlprNet("eu", config_file, runtime_data_dir))
            {

                if (!calpr.IsLoaded())
                {
                    platesListBox.Items.Add("Error initializing OpenALPR");
                    return;
                }

                var results = calpr.Recognize(photoIn);

                var images = new List<System.Drawing.Image>(results.Plates.Count());
                var i = 1;
                foreach (var result in results.Plates)
                {
                    var rect = boundingRectangle(result.PlatePoints);
                    var img = photoIn;
                    var cropped = cropImage(img, rect);
                    images.Add(cropped);

                    platesListBox.Items.Add("\t\t-- Plate #" + i++ + " --");
                    foreach (var plate in result.TopNPlates)
                    {
                        platesListBox.Items.Add(string.Format(@"{0} {1}% {2}", plate.Characters.PadRight(12),
                                                          plate.OverallConfidence.ToString("N1").PadLeft(8),
                                                          plate.MatchesTemplate.ToString().PadLeft(8)));
                    }
                }

                if (images.Any())
                {
                    licensePlatePic.Image = combineImages(images);
                }

                if (platesListBox.Items.Count > 1)
                {   
                    plate = platesListBox.Items[1].ToString();
                }
                else
                {
                    plate = "";
                }
            }
        }

        private void outputProcessImageFile()
        {
            Bitmap fotoc = (Bitmap) output_cam.Image.Clone();
            //var cregion = rbUSA.Checked ? "us" : "eu";
            String config_file = Path.Combine(AssemblyDirectory, "openalpr.conf");
            String runtime_data_dir = Path.Combine(AssemblyDirectory, "runtime_data");
            using (var alpr = new AlprNet("eu", config_file, runtime_data_dir)) // ülke plakaları -- önceki hali: "eu"
            {
                if (!alpr.IsLoaded())
                {
                    platesListBox.Items.Add("Error initializing OpenALPR");
                    return;
                }

                var results = alpr.Recognize(fotoc);

                var images = new List<System.Drawing.Image>(results.Plates.Count());
                var i = 1;
                foreach (var result in results.Plates)
                {
                    var crect = boundingRectangle(result.PlatePoints);
                    var cimg = fotoc;
                    var ccropped = cropImage(cimg, crect);
                    images.Add(ccropped);

                    platesListBox.Items.Add("\t\t-- Plate #" + i++ + " --");
                    foreach (var plate in result.TopNPlates)
                    {
                        platesListBox.Items.Add(string.Format(@"{0} {1}% {2}", plate.Characters.PadRight(12),
                                                          plate.OverallConfidence.ToString("N1").PadLeft(12), 
                                                          plate.MatchesTemplate.ToString().PadLeft(12)));       
                    }
                }

                if (images.Any())
                {
                    licensePlatePic.Image = combineImages(images);
                }

                if (platesListBox.Items.Count > 1)
                {
                    plate = platesListBox.Items[1].ToString();
                }
                else
                {
                    plate = "";
                }
            }

        }


        private void updateRecordTile_Click(object sender, EventArgs e)
        {
            LoginForm lgf = new LoginForm();
            lgf.Show();
        }


        /*-------------------------------Motion Stuff Start------------------------------------*/

        /*Motion Detect Variables*/
        FilterInfoCollection fic;
        VideoCaptureDevice device;
        MotionDetector detector;
        float detector_ks;

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(fic[metroComboBox1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = device;
            videoSourcePlayer1.Start();
        }

        //Motion Stuff Here
        private void metroButton2_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.Stop();
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            detector_ks = detector.ProcessFrame(image);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroLabel1.Text = "Algılama Katsayısı: " + detector_ks.ToString();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.Stop();
        }

        private void safeQuitTile_Click(object sender, EventArgs e)
        {
            confirmClose();
        }
        
        private void addRecordTile_Click(object sender, EventArgs e)
        {
            AuthorizeLogin lgf = new AuthorizeLogin();
            lgf.Show();
        }

        //Refreshing Timer
        private void resetControlTimer_Tick(object sender, EventArgs e)
        {
            //BackColors Refresh
            inputInfoPanel.BackColor = Color.White;
            nameLabel.BackColor = Color.White;
            surnameLabel.BackColor = Color.White;
            trackNoLabel.BackColor = Color.White;
            facultyLabel.BackColor = Color.White;
            plateLabel.BackColor = Color.White;
            photoInLabel.BackColor = Color.White;

            outputPanelInfo.BackColor = Color.White;
            nameOutLabel.BackColor = Color.White;
            surnameOutLabel.BackColor = Color.White;
            trackNoOutLabel.BackColor = Color.White;
            facultyOutLabel.BackColor = Color.White;
            plateOutLabel.BackColor = Color.White;
            photoOutLabel.BackColor = Color.White;

            if (plateReadInTB.Text != "" && plateReadOutTB.Text != "")
            {
                plateReadOutTB.Clear();
                plateReadInTB.Clear();
                resetControls();
            }
        }

        private void showPlateBtn_Click(object sender, EventArgs e)
        {
            if(platesListBox.Visible == false && licensePlatePic.Visible == false)
            {
                platesListBox.Visible = true;
                licensePlatePic.Visible = true;
            }
            else
            {
                licensePlatePic.Visible = false;
                platesListBox.Visible = false;
            }
        }

        private void MotionButton_Click(object sender, EventArgs e)
        {
            if (motionPanel.Visible == false && MotionButton.Text == "Sensör Deaktif")
            { 
                motionPanel.Visible = true;
                MotionButton.Text = "Sensör Aktif";
                MotionButton.Style = MetroFramework.MetroColorStyle.Green;
            }
            else if (motionPanel.Visible == true && MotionButton.Text == "Sensör Aktif")
            {
                MotionButton.Text = "Sensör Deaktif";
                motionPanel.Visible = false;
                MotionButton.Style = MetroFramework.MetroColorStyle.Red;

            }
        }
        /*-------------------------------Motion Stuff End------------------------------------*/
        
        
    }
}
