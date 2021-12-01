using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ywis
{
    class Mokytojas:Person
    {
        Isimti temp = new Isimti();
        Tikrinti temp2 = new Tikrinti();
        public Mokytojas(string kodas)
        {
            SetKodas(kodas);
            SetVardas(temp.IsimtiVarda("destytojai", kodas));
            SetPavarde(temp.IsimtiPavarde("destytojai", kodas));
        }
        public override DataTable Dalykai()
        {
            return temp.Dalykai(GetKodas(), "destomidalykai", "destytojai_kodas");
        }
        public override bool PridetiDalyka(string ka)
        {
            if (temp2.ArYraDalykas("destomidalykai",ka, "destytojai_Kodas", GetKodas()) != true)
            {
                temp2.PridetiDalyka(GetKodas(), ka, "destomidalykai", "destytojai_Kodas", "pavadinimas");
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool SalintiDalyka(string ka)
        {
            if (temp2.ArYraDalykas("destomidalykai", ka, "destytojai_Kodas", GetKodas()) == true)
            {
                temp2.SalintiDalyka("destomidalykai","destytojai_Kodas",GetKodas(), ka);
                return true;
            }
            else
            {
                return false;
            }
        }
        public override DataTable Grupe(string pav)
        {
            return temp.Lentele3("Pavadinimas","destymogrupe", "destytojai_kodas2",GetKodas(), "destomidalykai", pav);
        }
        public override bool PridetiGrupe(string pav,string dalykas)
        {
            if (temp2.ArYraGrupe("destymogrupe",pav,"destytojai_kodas2",GetKodas(),"destomidalykai",dalykas)!=true)
            {
                temp2.Prideti3(GetKodas(),dalykas,pav,"destymogrupe", "destytojai_Kodas2", "destomidalykai", "pavadinimas");
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool SalintiGrupe(string pav, string dalykas)
        {
            if (temp2.ArYraGrupe("destymogrupe", pav, "destytojai_kodas2", GetKodas(), "destomidalykai", dalykas) == true)
            {
                temp2.Salinti3("destymogrupe", "destytojai_Kodas2", GetKodas(),"destomidalykai",dalykas,"pavadinimas",pav);
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool SalintiPazimi(string stud, string dest, string dal, string paz, string data)
        {
            temp2.Salinti5("vertinimas", "studentas_Kodas", stud, "destytojai_Kodas", dest, "paskaitos_pavadinimas", dal, "Data", data, "Pazimys", paz);
            return true;
        }
        public override DataTable RezultataiPazymys(string stud, string pask)
        {
            
            return temp.GautiPazymiai(stud, GetKodas(), pask);
        }
        public override DataTable RezultataiPazymiu(string grupe, string dalykas)
        {

            return temp.GautasPazimys(GetKodas(),"destytojai_Kodas",grupe, "pazimys, Vardas, Data");
            
        }
    }
}
