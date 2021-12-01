using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ywis
{
    abstract class AsmensDalykai
    {
        public abstract DataTable Dalykai();
        public abstract bool PridetiDalyka(string ka);
        public abstract bool SalintiDalyka(string ka);
        public abstract DataTable Grupe(string pav);
        public abstract bool PridetiGrupe(string pav, string dalykas);
        public abstract bool SalintiGrupe(string pav, string dalykas);
        public abstract DataTable RezultataiPazymys(string stud, string pask);
        public abstract DataTable RezultataiPazymiu(string grupe, string dalykas);
        public abstract bool SalintiPazimi(string stud, string dest, string dal, string paz, string data);
    }
}
