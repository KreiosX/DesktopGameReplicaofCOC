using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasOyunu
{
  public abstract  class Uretim:Bina
    {
        public enum uretimTurleri {Asker, Erzak, Altın };
       public double uretimHizi;
        public uretimTurleri uretimTuru;
        public abstract void uret();
     
    }
}
