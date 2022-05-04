using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;

namespace SavasOyunu
{
    // Aaskerin hedef bulup ona ulaşması sırasında kalındı. o hedefe ulaşması için arada kopukluk var giredilecek.
    class OkluAsker : Asker
    {
        public OkluAsker(Canvas ekran, Image oklu, double l, double t) : this()
        {
            Ekran = ekran;
            imgAsker = oklu;
            left = l;
            top = t;
            konumlandir();
        }
        public void konumlandir()
        {
            imgAsker.Height = 25;
            imgAsker.Width = 25;
            Canvas.SetLeft(imgAsker, left);
            Canvas.SetTop(imgAsker, top);



            saglik.Maximum = savunmaGucu;
            saglik.Minimum = 0;
            saglik.Value = savunmaGucu;
            saglik.Height = 5;
            saglik.Width = imgAsker.Width;

            saglik.Foreground = Brushes.Green;

            Ekran.Children.Add(saglik);
            Canvas.SetZIndex(saglik, 9999999);
            Canvas.SetTop(saglik, top - 15);
            Canvas.SetLeft(saglik, left);

        }

        public OkluAsker()
        {
            savunmaGucu = 600;
            saldiriGucu = 60;
            saldiriMenzili = 6;
            saldiriHizi = 20;
            hareketHizi = 12;
            seviye = 1;
            oncelikliHedef = Bina.binaTurleri.Hepsi;
            oncelikliHedefSaldiriCarpani = 1;
            askerTuru = AskerTurleri.Oklu;
            hareket = hareketTurleri.sağaGit;
            resimNo = 0;

            if (kaynakResim == null)
            {
                kaynakResim = new BitmapImage(new Uri(@dir + "/resimler/Archer.png"));
                yatayResimSayisi = 9;
                genislik = 64;
                yukseklik = 64;

                resimSagaGit = new object[yatayResimSayisi];
                resimAsagiGit = new object[yatayResimSayisi];
                resimSolaGit = new object[yatayResimSayisi];
                resimYukariGit = new object[yatayResimSayisi];
                int satir = 8;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)
                    resimYukariGit[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));
                satir = 9;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)
                    resimSolaGit[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));
                satir = 10;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)
                    resimAsagiGit[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));
                satir = 11;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)                                  //yatay    dikey    yatay dikey      
                    resimSagaGit[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));


                yatayResimSayisi = 6;//Saldırma resim sayısı 6 olduğu için böyle yapıldı

                resimSagaSaldir = new object[yatayResimSayisi];
                resimAsagiSaldir = new object[yatayResimSayisi];
                resimSolaSaldir = new object[yatayResimSayisi];
                resimYukariSaldir = new object[yatayResimSayisi];

                satir = 12;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)
                    resimYukariSaldir[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));
                satir = 13;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)
                    resimSolaSaldir[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));
                satir = 14;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)
                    resimAsagiSaldir[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));
                satir = 15;
                for (int sutun = 0; sutun < yatayResimSayisi; sutun++)                                  //yatay    dikey    yatay dikey      
                    resimSagaSaldir[sutun] = new CroppedBitmap(kaynakResim, new Int32Rect(sutun * genislik, satir * yukseklik, genislik, yukseklik));

            }
            yatayResimSayisi = 9;

            resim = (ImageSource)resimSagaGit[resimNo];

        }
    }
}
