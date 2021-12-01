using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ywis
{
    class DuomenuVeiksmai
    {
        protected string GetInfo(string command, string pav, int sk)
        {
            string temp = null;
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=ywis");
            MySqlCommand cmd = new MySqlCommand(command + pav + "'", conn);
            conn.Open();
            MySqlDataReader sda = cmd.ExecuteReader();
            while (sda.Read())
            {
                if (sk == 1)
                {

                    temp = sda.GetValue(1).ToString();
                }
                else if (sk == 2)
                {

                    temp = sda.GetValue(2).ToString();
                }
                else if (sk == 3)
                {

                    temp = sda.GetValue(3).ToString();
                }
                else if (sk == 0)
                {

                    temp=sda.GetValue(0).ToString();
                }
            }
            conn.Close();
            return temp;
        }
        protected bool ArYra(string command, string pav)
        {
            bool aryra = false;
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=ywis");
            MySqlCommand cmd = new MySqlCommand(command+pav+"'", conn);
            conn.Open();
            MySqlDataReader sda = cmd.ExecuteReader();
            while (sda.Read())
            {
                aryra = true;
            }
            conn.Close();
            return aryra;
        }
        public DataTable VisiEsantys(string command)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=ywis");
            MySqlCommand cmd = new MySqlCommand(command, conn);
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count != 0) return dt;
            else return null;
        }
        protected void Ideti3(string nulinis, string nuliniopav,string pirmas, string pirmopav, string antras, string antropav, string trecias, string treciopav,string ketvirtas, string ketvirtopav,string command)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=ywis");
            MySqlCommand cmd = new MySqlCommand(command, con);
            if (nulinis != null)
            {
                cmd.Parameters.AddWithValue(nuliniopav, nulinis);
            }
            if (pirmas != null)
            {

                cmd.Parameters.AddWithValue(pirmopav, pirmas);
            }
            if (antras != null)
            {

                cmd.Parameters.AddWithValue(antropav, antras);
            }
            if (trecias != null)
            {

                cmd.Parameters.AddWithValue(treciopav, trecias);
            }
            if(ketvirtas!=null)
            {
                cmd.Parameters.AddWithValue(ketvirtopav, ketvirtas);
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        protected void Salinti(string command)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=ywis");
            MySqlCommand cmd = new MySqlCommand(command, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
