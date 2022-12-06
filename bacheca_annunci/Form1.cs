using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bacheca_annunci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Bacheca b;
        public Annuncio a;
        public int count=1;

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("TEXT", 180);
            listView1.Columns.Add("DATA", 100);
            listView1.Columns.Add("PREZZO", 80);

            b = new Bacheca("1");

        }

        public void riempi(Annuncio v)
        {
            listView1.Items.Add(Convert.ToString(v.Id));
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(v.Text);
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(v.Data);
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(Convert.ToString(v.Prezzo)+"€");

        }
        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            a = new Annuncio(count, textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
            b.Aggiungi(a);
            riempi(a);
            count++;
            Clear();


        }
    }
}
