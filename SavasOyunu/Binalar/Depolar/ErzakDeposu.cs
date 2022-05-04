using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
    class ErzakDeposu : Depo
    {
        public ErzakDeposu()
        {
            resim = resim = (ImageSource)new BitmapImage(new Uri(@dir + "/resimler/ev.png"));
            binaTuru = binaTurleri.Depo;
            left = 0;
            top = 0;
            savunmaGucu = 2500;
            seviye = 1;
            kapasite = 100000;
            depoTuru = DepoTurleri.Erzak;

        }
    
    }
}
