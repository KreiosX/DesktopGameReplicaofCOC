using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SavasOyunu
{
  public abstract class Bina
    {
      public static  Random rnd = new Random();
        public int genislik, yukseklik;

        public Image imgBina;
        public    ProgressBar saglik = new ProgressBar();

        public  static String dir = Directory.GetCurrentDirectory();
        public  enum binaTurleri {Uretim,Savunma,Depo,Ev,Hepsi};
        public static Canvas Ekran;
        public ImageSource resim;
        public binaTurleri binaTuru;
       public     double left, top, savunmaGucu, seviye;
        public bool hasarAl(double saldiriGucu) {

            if (savunmaGucu > 0)
            {
                savunmaGucu -= saldiriGucu;
            }

            if (saglik.Visibility == System.Windows.Visibility.Hidden)
            {
                saglik.Visibility = System.Windows.Visibility.Visible;
                Ekran.Children.Add(saglik);
                Canvas.SetZIndex(saglik, 9999999);
                Canvas.SetTop(saglik, top-15);
                Canvas.SetLeft(saglik, left);

            }
            else
            {


                //saglik.Dispatcher.Invoke(() => saglik.Value = savunmaGucu, DispatcherPriority.Background);
                saglik.Value = savunmaGucu;
                if (savunmaGucu > saglik.Maximum * 0.80)
                {
                    saglik.Foreground = Brushes.Green;
                }
                else if (savunmaGucu > saglik.Maximum * 0.60)
                {
                    saglik.Foreground = Brushes.Orange;
                }
                else if (savunmaGucu > saglik.Maximum * 0.40)
                {
                    saglik.Foreground = Brushes.OrangeRed;
                }
                else if (savunmaGucu > saglik.Maximum * 0.20)
                {
                    saglik.Foreground = Brushes.Red;
                }
                else
                {
                    saglik.Foreground = Brushes.DarkRed;
                }

                //Thread.Sleep(10);
            }


            return savunmaGucu > 0;
        }
         public void yikil() {

            if (this is Savunma)
            {
                Savunma sv = (Savunma)this;
                sv.yikil();
            }

            Ekran.Children.Remove(imgBina);
            Ekran.Children.Remove(saglik);
        }

        public bool halaSaglam()
        {


            return savunmaGucu > 0;
        }

        public Point merkezNokta()
        {
            Point merkez = new Point();
            merkez.X = left + genislik / 2;
            merkez.Y = top + yukseklik / 2;
            return merkez;
        }
        public Point solNokta()
        {
            Point sol = new Point();
            sol.X = left;
            sol.Y = top + yukseklik / 2;
            return sol;
        }

        public Point sagNokta()
        {
            Point sag = new Point();
            sag.X = left + genislik;
            sag.Y = top + yukseklik / 2;
            return sag;
        }
        public Point altNokta()
        {
            Point alt = new Point();
            alt.X = left + genislik / 2;
            alt.Y = top + yukseklik;
            return alt;
        }

        public Point ustNokta()
        {
            Point ust = new Point();
            ust.X = left + genislik / 2;
            ust.Y = top;
            return ust;
        }
        public void konumlandir()
        {
            left = Math.Round(rnd.NextDouble() * (Ekran.ActualWidth - genislik));
            top = Math.Round(rnd.NextDouble() * (Ekran.ActualHeight - yukseklik));
            imgBina.Height = yukseklik;
            imgBina.Width = genislik;
            Canvas.SetLeft(imgBina, left);
            Canvas.SetTop(imgBina, top);
        }
    }
}
