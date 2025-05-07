using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace Svedocanstvo
{
    public partial class Osoba : Form
    {
        public Osoba()
        {
            InitializeComponent();
        }

        int brojReda = 0;
        DataTable podaci = new DataTable();

        //string connectionString = @"Server=your_server_name; Database=your_database_name; Integrated Security=True;";

        private void Osoba_Load(object sender, EventArgs e)
        {

            string connectionString = "Server=DESKTOP-OGGEBNA\\SQLEXPRESS; database=ednevnik; integrated Security=SSPI;";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("select * from osoba", connection);

            adapter.Fill(podaci);
            PopuniText();
        }

        void PopuniText()
        {


            id.Text = ((int)podaci.Rows[brojReda][0]).ToString();
            ime.Text = (string)podaci.Rows[brojReda][1];
            prezime.Text = (string)podaci.Rows[brojReda][2];
            adresa.Text = (string)podaci.Rows[brojReda][3];
            jmbg.Text = (string)podaci.Rows[brojReda][4];
            email.Text = (string)podaci.Rows[brojReda][5];
            password.Text = (string)podaci.Rows[brojReda][6];
            uloga.Text = ((int)podaci.Rows[brojReda][7]).ToString();

            if(brojReda == 0)
            {
                button2.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button1.Enabled = true;
            }

            if(brojReda == podaci.Rows.Count - 1)
            {
                btnSledeci.Enabled = false;
                btnPoslednji.Enabled = false;
            }
            else
            {
                btnSledeci.Enabled = true;
                btnPoslednji.Enabled = true;
            }
        }

        private void btnSledeci_Click(object sender, EventArgs e)
        {
            brojReda++;
            PopuniText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            brojReda--;
            PopuniText();
        }

        private void btnPoslednji_Click(object sender, EventArgs e)
        {
            brojReda = podaci.Rows.Count - 1;
            PopuniText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brojReda = 0;
            PopuniText();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string naredba = $"insert into osoba(ime, prezime, adresa, jmbg, email, password, uloga) values ('{ime.Text}', '{prezime.Text}', '{adresa.Text}', '{jmbg.Text}', '{email.Text}', '{password.Text}')";
        }
    }
}
