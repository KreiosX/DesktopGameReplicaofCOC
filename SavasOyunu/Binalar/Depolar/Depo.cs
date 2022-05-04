using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasOyunu

{
    public abstract class Depo : Bina
    {
        public enum DepoTurleri {Erzak, Altın};
        public double kapasite;
        public DepoTurleri depoTuru;
    }
}
