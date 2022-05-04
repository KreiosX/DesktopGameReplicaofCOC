using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
   
    public abstract class Savunma:Bina
    {

     public   int saldiriTik = 10000;
     public   List<Asker> hedefListesi = new List<Asker>();
    public    List<Image> gulleListesi = new List<Image>();
  public static      List<Savunma> kuleList;


        public   double saldiriHizi, saldiriGucu, saldiriMenzili;
     public  Asker.AskerTurleri oncelikliHedef;


  
        public  void hedefBelirle(List<Asker> hedefList)
        {
           

            int hedefIndex = -1;
            double hedefMesafe = 99999999;


            for (int i = 0; i < hedefList.Count; i++)
            {

                double merkezLeft = Canvas.GetLeft(hedefList[i].imgAsker)+ hedefList[i].imgAsker.ActualWidth/2;
                double merkezTop = Canvas.GetTop(hedefList[i].imgAsker) + hedefList[i].imgAsker.ActualHeight/2;

                double yenimesafe = (Math.Abs(merkezLeft - merkezNokta().X) + Math.Abs(merkezTop - merkezNokta().Y));

                if ( yenimesafe< hedefMesafe&&yenimesafe< saldiriMenzili)
                {
                    hedefIndex = i;
                    hedefMesafe = yenimesafe;
                }


            }//for
            if (hedefIndex >= 0)
            {
                saldir(hedefList[hedefIndex],hedefList);
            }
            else
            {
                temizle();
            }

        }
        public  bool saldir(object hedef,List<Asker> hedefList)
        {
            saldiriTik++;
            bool yenilendi = false;
            if (saldiriTik >= saldiriHizi )
            {
                BitmapImage gulleResim = new BitmapImage(new Uri(@dir + "/resimler/gulle.png"));
                Image gulle = new Image();
                gulle.Source = gulleResim;
                gulle.Height = 8;
                gulle.Width = 8;
                Ekran.Children.Add(gulle);
                Canvas.SetTop(gulle, top+10);
                Canvas.SetLeft(gulle, left+20);
                Canvas.SetZIndex(gulle, 9999999);

           //     temizle();
               
                hedefListesi.Add((Asker)hedef);
                
                Canvas.SetZIndex(((Asker)hedef).imgAsker,999999999);
                Canvas.SetZIndex(((Asker)hedef).saglik, 999999999);
                gulleListesi.Add(gulle);
                saldiriTik = 0;
            }
            for (int i = 0; i < gulleListesi.Count; i++)
            {
                yenilendi = false;


                double gLeft = Canvas.GetLeft(gulleListesi[i]);
                double hLeft = Canvas.GetLeft(hedefListesi[i].imgAsker);
                double gTop = Canvas.GetTop(gulleListesi[i]);
                double hTop = Canvas.GetTop(hedefListesi[i].imgAsker);


                double gMerkezX = gLeft + gulleListesi[i].ActualWidth / 2;
                double gMerkezY = gTop + gulleListesi[i].ActualHeight/ 2;


                double merkezHedefY = hTop + hedefListesi[i].imgAsker.ActualHeight / 2;
                double merkezHedefX = hLeft + hedefListesi[i].imgAsker.ActualWidth / 2;


                double x = Math.Abs(gMerkezX- merkezHedefX);
                double y = Math.Abs(gMerkezY - merkezHedefY);

                if (gMerkezY>hTop+ hedefListesi[i].imgAsker.ActualHeight)//gulle aşağıdaysa
                {
                   gTop -= 4; yenilendi = true;
                }

                if (gMerkezY < hTop )//gulle yukarıdaysa
                {
                    gTop += 4; yenilendi = true;
                }

                if (gMerkezX < hLeft)//gulle soldaysa
                {
                    // gLeft += 3*(x / y);
                    gLeft += 4;
                    yenilendi = true;
                }
                if (gMerkezX > hLeft + hedefListesi[i].imgAsker.ActualWidth)//gulle sağdaysa
                {
                     gLeft -= 4 ; yenilendi = true;
                }


                if (yenilendi)
                {
                Canvas.SetLeft(gulleListesi[i], gLeft);
                Canvas.SetTop(gulleListesi[i], gTop);
                }
                else
                {
                    if (!hedefListesi[i].hasarAl(saldiriGucu))
                    {
                        hedefListesi[i].geber();
                        hedefList.Remove(hedefListesi[i]);
                    }
                    
                    Ekran.Children.Remove(gulleListesi[i]);
                    gulleListesi.RemoveAt(i);
                    hedefListesi.RemoveAt(i);
                   
                }
               
            }
            return true;
        }

        private void temizle()
        {

            for (int i = 0; i < gulleListesi.Count; i++)
            {
                Ekran.Children.Remove(gulleListesi[i]);
            }


            hedefListesi.Clear();
            gulleListesi.Clear();


        }

        public  void yikil()
        {
            Ekran.Children.Remove(imgBina);
            Ekran.Children.Remove(saglik);
            kuleList.Remove(this);

            temizle();
           
        }
    }
}
