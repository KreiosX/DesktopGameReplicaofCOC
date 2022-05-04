using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
    class SabitTop : Savunma
    {
       



        public SabitTop()
        {
            resim = resim = (ImageSource)new BitmapImage(new Uri(@dir + "/resimler/sabitTop.png"));
            binaTuru = binaTurleri.Savunma;
            savunmaGucu = 20000;
            seviye = 1;
            saldiriGucu = 200;
            saldiriHizi = 15;
            saldiriMenzili = 200;
            oncelikliHedef = Asker.AskerTurleri.Hepsi;
            genislik = 45;
            yukseklik = 45;


            saglik.Maximum = savunmaGucu;
            saglik.Minimum = 0;
            saglik.Value = savunmaGucu;
            saglik.Height = 10;
            saglik.Width = genislik;
            saglik.Visibility = System.Windows.Visibility.Hidden;
            saglik.Foreground = Brushes.Green;

        }



        public SabitTop(Canvas ekran, Image resim, List<Savunma> kuleListesi) : this()
        {
            kuleList = kuleListesi;
            Ekran = ekran;
            imgBina = resim;
            konumlandir();
        }

       
      

      

       

       
    }
}
