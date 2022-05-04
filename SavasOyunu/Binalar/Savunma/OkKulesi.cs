using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
    class OkKulesi : Savunma
    {
        public OkKulesi()
        {
            resim = resim = (ImageSource)new BitmapImage(new Uri(@dir + "/resimler/ev.png"));
            binaTuru = binaTurleri.Savunma;
            left = 0;
            top = 0;
            savunmaGucu = 4000;
            seviye = 1;
            saldiriMenzili = 7;
            saldiriGucu = 100;
            saldiriHizi = 20;
            oncelikliHedef = Asker.AskerTurleri.Hepsi;
        }
      

      
    }
}
