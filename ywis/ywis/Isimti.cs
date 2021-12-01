using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ywis
{
    class Isimti : DuomenuVeiksmai
    {
        public string IsimtiPavarde(string kur,string kodas)
        {
            return GetInfo("Select * from " + kur + " where Kodas= '", kodas, 2);
        }
        public string IsimtiPavarde2(string kur, string vardas)
        {
            return GetInfo("Select * from " + kur + " where Vardas= '", vardas, 2);
        }
        public string IsimtiVarda(string kur, string kodas)
        { 
            return GetInfo("Select * from " + kur + " where Kodas= '", kodas, 1);
        }
        public string IsimtiVarda2(string kur, string pavarde)
        {
            return GetInfo("Select * from " + kur + " where pavarde= '", pavarde, 1);
        }
        public string IsimtiKoda(string kur, string kodas)
        {
            return GetInfo("Select * from " + kur + " where Kodas= '", kodas, 0);
        }
        public string IsimtiKoda2(string kur, string vardas, string pavarde)
        {
            return GetInfo("Select * from " + kur + " where Vardas= '"+vardas+"' AND Pavarde= '", pavarde, 0);
        }
        public string IsimtiKoda3(string kur, string vardas, string slaptazodis)
        {
            return GetInfo("Select * from " + kur + " where Prisijungimas= '" + vardas + "' AND Slaptazodis= '", slaptazodis, 0);
        }
        public string IsimtiKoda3(string kur, string pavarde)
        {
            return GetInfo("Select * from " + kur + " where pavarde= '", pavarde, 0);
        }
        public string IsimtiKoda4(string kur, string vardas)
        {
            return GetInfo("Select * from " + kur + " where vardas= '", vardas, 0);
        }
        public DataTable GautiPazymiai(string stud,string dest,string pask)
        {
            return VisiEsantys("select Pazimys,Data from vertinimas WHERE studentas_Kodas='" + stud + "' AND destytojai_Kodas= '"+dest+"' AND paskaitos_pavadinimas= '"+pask+"'");
        }
        public DataTable GautasPazimys(string kodas,string pask,string grupe, string ka)
        {
            return VisiEsantys("select "+ka+" from vertinimas,studentas,paskaitosgrupe WHERE Kodas=studentas_kodas2 AND destytojai_Kodas= '"+kodas+ "'AND Pavadinimas=paskaitos_Pavadinimas AND Pavadinimas='"+grupe+"' AND paskaitos_pavadinimas='" + pask + "' GROUP BY Data");

        }
        public DataTable GautasPazimys2(string kodas, string pask, string ka)
        {
            return VisiEsantys("select "+ka+" FROM vertinimas,destytojai WHERE studentas_Kodas='" + kodas + "'AND destytojai_Kodas=Kodas AND paskaitos_pavadinimas='"+pask+"'");
        }
        public DataTable GautiPazymiai2(string kodas)
        {

            return VisiEsantys("select Pazimys,Data,Paskaitos_Pavadinimas,Vardas,Pavarde FROM vertinimas,destytojai WHERE studentas_Kodas= '" + kodas + "' AND Kodas=destytojai_Kodas");
        }
        public DataTable ZmoniuLentele(string vardas,string pavarde,string kur)
        {
            
            if (vardas!=null && pavarde!= null)
            {
                return VisiEsantys("select Kodas,Vardas,Pavarde from "+kur+" WHERE vardas= '" + vardas + "'AND pavarde='" + pavarde + "'");
            }
            else if(vardas==null  && pavarde!= null)
            {
                return VisiEsantys("select Kodas,Vardas,Pavarde from "+kur+" WHERE pavarde='" + pavarde + "'");
            }
            else if(vardas!=null && pavarde==null)
            {
                return VisiEsantys("select Kodas,Vardas,Pavarde from " + kur + " WHERE vardas='" + vardas + "'");
            }
            else 
            {
                return VisiEsantys("select Kodas,Vardas,Pavarde from " + kur + "");
            }
            
        }
        public DataTable Dalykai(string kodas,string kur,string kas)
        {
            return VisiEsantys("select Pavadinimas from "+kur+" WHERE "+kas+"='" + kodas + "'");
        }
        public DataTable Lentele3(string ka, string kur, string despav, string des,string dalpav,string dal)
        {
            return VisiEsantys("select "+ka+" from " + kur + " WHERE " + despav + "= '" + des + "' AND "+dalpav+ "= '"+dal+"'");
        }
        public int KiekYraDuomenu(DataTable lentele)
        {
            if (lentele == null)
            {
                return 0;
            }
            else
            {
                return lentele.Rows.Count;
            }
        }

    }
}
