using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SavasOyunu
{
    class Maden : Uretim
    {
        public Maden()
        {
            resim = resim = (ImageSource)new BitmapImage(new Uri(@dir + "/resimler/ev.png"));
            binaTuru = binaTurleri.Uretim;
            uretimTuru = uretimTurleri.Altın;
            uretimHizi = 100;
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
