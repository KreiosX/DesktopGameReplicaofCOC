using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SavasOyunu
{
    class Ev : Bina
    {
        double kapasite;
     



        public Ev()
        {
            resim = (ImageSource) new BitmapImage(new Uri(@dir + "/resimler/ev.png"));
            binaTuru = binaTurleri.Ev;
            savunmaGucu = 10000;
            seviye = 1;
            kapasite = 100;
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
        public Ev(Canvas ekran, Image ev) : this()
        {
            Ekran = ekran;
            imgBina = ev;
            konumlandir();
        }
        

    }
}
