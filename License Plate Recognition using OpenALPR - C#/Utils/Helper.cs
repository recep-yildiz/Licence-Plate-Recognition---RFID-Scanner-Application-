using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace KOU_RFID_Plaka.Utils
{
    class Helper
    {
        /*public static void LoadFormInPanel(AnaEkran mainForm, Form subForm)
        {

             if (mainForm.mainPanel.Controls.Count > 0)
             {
                 string basetype = mainForm.mainPanel.Controls[0].GetType().BaseType.ToString();
                 if (basetype.Contains("Forms.Form"))
                 {
                     ((Form)mainForm.mainPanel.Controls[0]).Close();
                 }
             }
             subForm.TopLevel = false;
             subForm.AutoScroll = true;
             subForm.Width = mainForm.Width - 15;
             subForm.Height = mainForm.Height - 85;
             mainForm.mainPanel.Controls.Add(subForm);
             subForm.Show();
        }*/



        public static String Md5(String text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(text);
            btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        public static String GetDatabaseDateFormat()
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            return time.ToString(format);
        }
    }
}
