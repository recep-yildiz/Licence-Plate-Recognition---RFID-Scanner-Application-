# License-Plate-Recognition-using-OpenALPR---C-

• Lisans eğitimi ilk staj döneminde hazırlamaya çalıştığım plaka tanıma ve RFID etiket okuma özelliklerinin bir arada bulunduğu bir projedir.
• Hazırlamaya çalıştığım program C# diliyle yazılmış olup ek donanım gerektirmektedir; Alien RFID ve Dahua IP Kamera
• Donanımların alternatifleri edinilebilir.
• Program kabaca, kamera açısında olan bir aracın plakasını tanımlayabilir ve eğer araç etiket sahibi ise etiketi tanımlayabilir.
• Plaka tanımlama, yeni sayılabilecek OpenALPR kütüphanesi ile gerçekleştirirken, RFID kısmı donanım için donanıma özel hazırlanan kütüphaneden faydalanıldı.

** Eksiklikler **

• AForge kütüphanesi ile hareket sensörü eklemeye çalıştım ancak IP kamera ile uyumlu hale getiremedim, sadece USB kameralar ile çalıştırabildim.
• Program multithread hale getirilebilir, tek çekirdekte çalışırken performans sıkıntıları yaşanıyor. Bilindiği üzere görüntü işleme, işlemci açısından oldukça zahmetli bir iştir.
• Türk plakaları için daha optimize bir config dosyası hazırlanabilir.
