using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EuropaiUnio
{
    class EUtagallamok
    {
        public string EutagallamNeve;
        public string CsatlakozasDatum;
        public string Ev;
        public string Honap;
        public string Nap;

        public EUtagallamok(string sor)
        {
            var dbok = sor.Split(';');
            this.EutagallamNeve = dbok[0];
            this.CsatlakozasDatum = dbok[1];
            var dbok2 = CsatlakozasDatum.Split('.');
            this.Ev = dbok2[0];
            this.Honap= dbok2[1];
            this.Nap = dbok2[2];
        }
    }
}
