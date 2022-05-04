using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
    class Kısla : Uretim
    {
        public Kısla()
        {
            resim = resim = (ImageSource)new BitmapImage(new Uri(@dir + "/resimler/ev.png"));
            binaTuru = binaTurleri.Uretim;
            uretimTuru = uretimTurleri.Asker;
            uretimHizi = 2;
            savunmaGucu = 2000;
            left = 0;
            top = 0;
            seviye = 1;
        }
     
        public override void uret()
        {
            throw new NotImplementedException();
        }

      
    }
}
