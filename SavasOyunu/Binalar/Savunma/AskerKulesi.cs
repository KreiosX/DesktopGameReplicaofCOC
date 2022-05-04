using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
    class AskerKulesi : Savunma
    {
        public AskerKulesi()
        {
            resim = resim = (ImageSource)new BitmapImage(new Uri(@dir + "/resimler/ev.png"));
            binaTuru = binaTurleri.Savunma;
            left = 0;
            top = 0;
            savunmaGucu = 3000;
            seviye = 1;
            saldiriMenzili = 10;
            saldiriGucu = 0;
            saldiriHizi = 0;
            oncelikliHedef = Asker.AskerTurleri.Hepsi;
        }

       

      
    }
}
