using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ywis
{
    public partial class Form1 : Form
    {
        Person zmogus = new Person();
        public Form1(string kas,int flag)
        {
            InitializeComponent();
            if (flag == 1) 
            {
                zmogus = new Mokytojas(kas);
                VertinimoButton.Visible = false;
                RegistruotiButtom.Visible = false;
                SalintiButtom.Visible = false;
                RegistruotiMokini.Visible = false;
                SalintiMokini.Visible = false;
                VertintiButton.Visible = true;

            }
            else if(flag==2)
            {
                zmogus = new Studentai(kas);
                VertinimoButton.Visible = true;
                RegistruotiButtom.Visible = false;
                SalintiButtom.Visible = false;
                RegistruotiMokini.Visible = false;
                SalintiMokini.Visible = false;
                VertintiButton.Visible = false;
            }
            else
            {
                VertinimoButton.Visible = false;
                RegistruotiButtom.Visible = true;
                SalintiButtom.Visible = true;
                RegistruotiMokini.Visible = true;
                SalintiMokini.Visible = true;
                VertintiButton.Visible = false;
            }
            SetVardas.Text = zmogus.GetVardas() +" "+ zmogus.GetPavarde();
            
            pictureBox1.Cursor = Cursors.Hand;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            atsijuntiButton.Visible = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            atsijuntiButton.Visible = false;
        }

        private void atsijuntiButton_Click(object sender, EventArgs e)
        {
            new Prisijungti().Show();
            this.Hide();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProfilioButton_Click(object sender, EventArgs e)
        {
            atsijuntiButton.Visible = false;
        }

        private void VertinimoButton_Click(object sender, EventArgs e)
        {
            new Vertinimai(zmogus.GetKodas()).Show();
            this.Hide();
        }
        private void label_Clic(object sender, EventArgs e)
        {

        }

        private void RegistruotiButtom_Click(object sender, EventArgs e)
        {
            new Registruoti("destytojai",zmogus.GetKodas()).Show();
            this.Hide();
        }

        private void SalintiButtom_Click(object sender, EventArgs e)
        {
            new Salinti("destytojai",zmogus.GetKodas()).Show();
            this.Hide();
        }

        private void SalintiMokini_Click(object sender, EventArgs e)
        {
            new Salinti("studentas",zmogus.GetKodas()).Show();
            this.Hide();
        }

        private void RegistruotiMokini_Click(object sender, EventArgs e)
        {
            new Registruoti("studentas",zmogus.GetKodas()).Show();
            this.Hide();
        }

        private void VertintiButton_Click(object sender, EventArgs e)
        {
            new Vertinti(zmogus.GetKodas()).Show();
            this.Hide();
        }
    }
}
