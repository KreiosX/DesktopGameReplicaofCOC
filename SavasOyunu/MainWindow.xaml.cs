using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SavasOyunu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pyd = 0;
        int pyd1 = 0;
        int pyd2 = 0;
        int arc = 0;
        int arc1 = 0;
        int arc2 = 0;
        int prd = 0;
        int prd1 = 0;
        int prd2 = 0;
        int cvr = 0;
        int cvr1 = 0;
        int cvr2 = 0;
        String dir = Directory.GetCurrentDirectory();
      public  List<Asker> askerList=new List<Asker>();
        List<Ev> evList = new List<Ev>();
        List<Savunma> kuleList = new List<Savunma>();

        public MainWindow()
        {
            InitializeComponent();
            Control();
        }

        public void Control()
        {
            Random rnd = new Random();
            pyd1 = rnd.Next(1, 50);
            a.Text = pyd1.ToString();
            arc1 = rnd.Next(1, 50);
            c.Text = arc1.ToString();
            prd1 = rnd.Next(1,50);
            b.Text = prd1.ToString();
            cvr1 = rnd.Next(1,50);
            d.Text = cvr1.ToString();
        }

        private void Ekran_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            Point p = Mouse.GetPosition(Ekran);
                if (piyadebtn.IsChecked == true && pyd<pyd1)
                {
                    pyd++;
                    Image askerR = new Image();
                    PiyadeAsker askerAsker = new PiyadeAsker(Ekran, askerR, p.X, p.Y);
                    askerList.Add(askerAsker);
                    askerR.Source = askerAsker.resim;
                    Ekran.Children.Add(askerR);
                    pyd2 = Convert.ToInt32(a.Text);
                    a.Text = (--pyd2).ToString();
                }
            if (okcubtn.IsChecked == true && arc < arc1)
            {
                arc++;
                Image askerR = new Image();
                OkluAsker askerAsker = new OkluAsker(Ekran, askerR, p.X, p.Y);
                askerList.Add(askerAsker);
                askerR.Source = askerAsker.resim;
                Ekran.Children.Add(askerR);
                arc2 = Convert.ToInt32(c.Text);
                c.Text = (--arc2).ToString();
            }
            if (haramibtn.IsChecked == true && prd < prd1)
            {
                prd++;
                Image askerR = new Image();
                OkluAsker askerAsker = new OkluAsker(Ekran, askerR, p.X, p.Y);
                askerList.Add(askerAsker);
                askerR.Source = askerAsker.resim;
                Ekran.Children.Add(askerR);
                prd2 = Convert.ToInt32(b.Text);
                b.Text = (--prd2).ToString();
            }
            if (sipahibtn.IsChecked == true && cvr < cvr1)
            {
                cvr++;
                Image askerR = new Image();
                OkluAsker askerAsker = new OkluAsker(Ekran, askerR, p.X, p.Y);
                askerList.Add(askerAsker);
                askerR.Source = askerAsker.resim;
                Ekran.Children.Add(askerR);
                cvr2 = Convert.ToInt32(d.Text);
                d.Text = (--cvr2).ToString();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < askerList.Count; i++)
            {
                askerList[i].imgAsker.Source = askerList[i].git();
           }


            for (int i = 0; i < kuleList.Count; i++)
            {
              
        
                kuleList[i].hedefBelirle(askerList);
           
            }
            int aa = askerList.Count;
            deger.Content = aa.ToString();

        }


        private void Ekran_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                Image evR = new Image();
                Ev ev = new Ev(Ekran, evR);
                evList.Add(ev);
                Ekran.Children.Add(evR);
                evR.Source = ev.resim;
                evR.Tag = ev;

            }

            for (int i = 0; i < 10; i++)
            {
                Image kuleR = new Image();
                SabitTop kule = new SabitTop(Ekran, kuleR,kuleList);
                kuleList.Add(kule);
                Ekran.Children.Add(kuleR);
                kuleR.Source = kule.resim;
                kuleR.Tag = kule;

            }






            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();

          




        }
    }
}
