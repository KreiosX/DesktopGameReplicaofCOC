using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
public abstract class Asker
    {
       public enum AskerTurleri {Harami,Oklu,Piyade,Sipahi,Hepsi};
        public int genislik, yukseklik;
        public enum hareketTurleri {solaGit,sağaGit,yukarıGit,aşağıGit,solaVur,sağaVur,yukarıVur,AşağıVur,öl,dur};
        public hareketTurleri hareket;
        public Bina.binaTurleri oncelikliHedef;

        public BitmapImage kaynakResim;
        public Image imgAsker;
        public int yatayResimSayisi;

        public  object[] resimSagaGit;
        public object[] resimAsagiGit;
        public  object[] resimSolaGit;
        public  object[] resimYukariGit;

        public  object[] resimSagaSaldir;
        public  object[] resimAsagiSaldir;
        public  object[] resimSolaSaldir;
        public  object[] resimYukariSaldir;

        public Image imgBina;
        public ProgressBar saglik = new ProgressBar();

        public static Canvas Ekran;

public    static    String dir = Directory.GetCurrentDirectory();

        public ImageSource resim;
        public  AskerTurleri askerTuru;
       public double left, top, savunmaGucu, saldiriGucu, saldiriMenzili,saldiriHizi,hareketHizi,seviye,oncelikliHedefSaldiriCarpani;

        public int resimNo;


        public bool halaCanli() {


            return savunmaGucu > 0;
        }

        public ImageSource git()
        {
            left = Canvas.GetLeft(imgAsker);
            top = Canvas.GetTop(imgAsker);

            hedefBelirle();
            return resim;
        }


        public  void hedefBelirle()
        {
            Image hedefBina = null;
            double hedefMesafe = 99999999;

            foreach (object item in Ekran.Children)
            {
                if (item is Image)
                {
                    Image hdf = (Image)item;
                    if (hdf.Tag != null && hdf.Tag is Bina)
                    {
                        Bina bn = (Bina)hdf.Tag;
                        if ((Math.Abs(bn.left - left) + Math.Abs(bn.top - top)) < hedefMesafe)
                        {
                            hedefBina = hdf;
                            hedefMesafe = Math.Abs(bn.left - left) + Math.Abs(bn.top - top);
                        }
                    }
                }//if
            }//foreach
            if (hedefBina != null)
            {
                hedefeGit(hedefBina);
            }
            else
            {
                hedefeGit(0, 0);
            }

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


        public void sagaGit()
        {
            if (resimNo >= yatayResimSayisi)
            {
                resimNo = 0;
            }
            resim = (ImageSource)resimSagaGit[resimNo];
            resimNo++;

            if (sagNokta().X >= Ekran.ActualWidth - 5)
            {
                left = Ekran.ActualWidth - genislik - 5;//        hareket = hareketTurleri.aşağıGit;
                Canvas.SetLeft(imgAsker,left);
                Canvas.SetLeft(saglik, left);
            }
            else
            {
                left += 5;
                Canvas.SetLeft(imgAsker, left);
                Canvas.SetLeft(saglik, left);
            }
        }
        public void asagiGit()
        {
            if (resimNo >= yatayResimSayisi)
            {
                resimNo = 0;
            }
            resim = (ImageSource)resimAsagiGit[resimNo];
            resimNo++;

            if (altNokta().Y >= Ekran.ActualHeight - 5)
            {
                top = Ekran.ActualHeight - yukseklik - 5;//   hareket = hareketTurleri.solaGit;
                Canvas.SetTop(imgAsker, top);
                Canvas.SetTop(saglik, top-15);
            }
            else
            {
                top += 5;
                Canvas.SetTop(imgAsker, top);
                Canvas.SetTop(saglik, top-15);
            }
        }
        public void solaGit()
        {
            if (resimNo >= yatayResimSayisi)
            {
                resimNo = 0;
            }
            resim = (ImageSource)resimSolaGit[resimNo];
            resimNo++;

            if (solNokta().X <= 0)
            {
                //   hareket = hareketTurleri.yukarıGit;
                Canvas.SetLeft(imgAsker, 0);
                Canvas.SetLeft(saglik, 0);
            }
            else
            {
                left -= 5;
                Canvas.SetLeft(imgAsker, left);
                Canvas.SetLeft(saglik, left);
            }
        }
        public void yukariGit()
        {
            if (resimNo >= yatayResimSayisi)
            {
                resimNo = 0;
            }
            resim = (ImageSource)resimYukariGit[resimNo];
            resimNo++;

            if (ustNokta().Y <= 0)
            {
                //    hareket = hareketTurleri.sağaGit;
                Canvas.SetTop(imgAsker, 0);
                Canvas.SetTop(saglik, 0-15);
            }
            else
            {
                top -= 5;
                Canvas.SetTop(imgAsker, top);
                Canvas.SetTop(saglik, top-15);
            }
        }
        public void dur()
        {

        }
        public  void hedefeGit(Image hedef)
        {
            double sol = Canvas.GetLeft(hedef);
            double ust = Canvas.GetTop(hedef);

            double sag = sol + hedef.ActualWidth;
            double alt = ust + hedef.ActualHeight;

            Bina bn = (Bina)hedef.Tag;


            if (merkezNokta().X < sol)
            {
                hareket = hareketTurleri.sağaGit;
                sagaGit();
            }
            else if (merkezNokta().X > sag)
            {
                hareket = hareketTurleri.solaGit;
                solaGit();
            }
            else if (merkezNokta().Y > alt)
            {
                hareket = hareketTurleri.yukarıGit;
                yukariGit();
            }
            else if (merkezNokta().Y < ust)
            {
                hareket = hareketTurleri.aşağıGit;
                asagiGit();
            }
            else if (bn.savunmaGucu > 0)
            {
                saldir(hedef);

            }
            else
            {
                dur();
            }

        }
        public void hedefeGit(double sol, double ust)
        {


            double sag = sol + 16;
            double alt = ust + 16;




            if (merkezNokta().X < sol)
            {
                hareket = hareketTurleri.sağaGit;
                sagaGit();
            }
            else if (merkezNokta().X > sag)
            {
                hareket = hareketTurleri.solaGit;
                solaGit();
            }
            else if (merkezNokta().Y > alt)
            {
                hareket = hareketTurleri.yukarıGit;
                yukariGit();
            }
            else if (merkezNokta().Y < ust)
            {
                hareket = hareketTurleri.aşağıGit;
                asagiGit();
            }
            else
            {
                dur();
            }

        }


        public  void saldir(Image hedef)
        {

            yatayResimSayisi = 6;
            resimNo++;
            if (resimNo >= yatayResimSayisi)
            {
                resimNo = 0;
                Bina bn = (Bina)hedef.Tag;
                if (!bn.hasarAl(saldiriGucu))
                {
                    bn.yikil();
                    hedefBelirle();
                    return;
                }
            }


            switch (hareket)
            {
                case hareketTurleri.solaGit:
                    resim = (ImageSource)resimSolaSaldir[resimNo];
                    hareket = hareketTurleri.solaVur;

                    break;
                case hareketTurleri.sağaGit:
                    resim = (ImageSource)resimSagaSaldir[resimNo];
                    hareket = hareketTurleri.sağaVur;

                    break;
                case hareketTurleri.yukarıGit:
                    resim = (ImageSource)resimYukariSaldir[resimNo];
                    hareket = hareketTurleri.yukarıVur;

                    break;
                case hareketTurleri.aşağıGit:
                    resim = (ImageSource)resimAsagiSaldir[resimNo];
                    hareket = hareketTurleri.AşağıVur;

                    break;
                case hareketTurleri.solaVur:
                    resim = (ImageSource)resimSolaSaldir[resimNo];
                    break;
                case hareketTurleri.sağaVur:
                    resim = (ImageSource)resimSagaSaldir[resimNo];
                    break;
                case hareketTurleri.yukarıVur:
                    resim = (ImageSource)resimYukariSaldir[resimNo];
                    break;
                case hareketTurleri.AşağıVur:
                    resim = (ImageSource)resimAsagiSaldir[resimNo];
                    break;
                default:
                    break;
            }
            yatayResimSayisi = 9;


        }
        public bool hasarAl(double saldiriGucu)
        {

            if (savunmaGucu > 0)
            {
                savunmaGucu -= saldiriGucu;
            }
            else
            {
                geber();
            }

         




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

          

            return savunmaGucu > 0;
        }
   
        public void geber()
        {
          
            Ekran.Children.Remove(imgAsker);
            Ekran.Children.Remove(saglik);
            MainWindow m = new SavasOyunu.MainWindow();
            int aa = m.askerList.Count - 1;
            m.a.Text = aa.ToString();
        }

    }
}
