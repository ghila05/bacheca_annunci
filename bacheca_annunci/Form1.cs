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
        public Annuncio m;
        public int count=0;

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
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(Convert.ToString(v.Prezzo));

        }
        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        public void Eliminaitem()
        {
            for (int i = 0; i < count; i++)
            {
                listView1.Items.Remove(listView1.Items[0]);
            }

        }


        private void button1_Click(object sender, EventArgs e)// aggiungi
        {
            a = new Annuncio(count, textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
            b.Aggiungi(a);
            riempi(a);
            count++;
            Clear();
            label5.Text = ("Prezzo tot: "+Convert.ToString(b.Costotot()));


        }

        private void button2_Click(object sender, EventArgs e) //elimina
        {

            int prova = listView1.FocusedItem.Index;
            MessageBox.Show(Convert.ToString(prova));
            listView1.Items.Remove(listView1.SelectedItems[0]);
            b.Remove(prova);
            label5.Text = ("Prezzo tot: " + Convert.ToString(b.Costotot()));
            Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;

            }
  
        }

        private void button3_Click(object sender, EventArgs e) //modifica
        {
            string gino = listView1.SelectedItems[0].SubItems[0].Text; 
            //MessageBox.Show(gino);

            //MessageBox.Show(Convert.ToString(prova));
            m = new Annuncio(Convert.ToInt32(gino), textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
            //MessageBox.Show("id" + Convert.ToString(prova) + " text: " + m.Text+ " data: "+ m.Data+" prezzo: "+Convert.ToString(textBox3.Text));
            b.Modifica(m);
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[1].Text = m.Text;
                listView1.SelectedItems[0].SubItems[2].Text = m.Data;
                listView1.SelectedItems[0].SubItems[3].Text = Convert.ToString(m.Prezzo);

            }
            label5.Text = ("Prezzo tot: " + Convert.ToString(b.Costotot()));
            Clear();
        }



        private void button4_Click(object sender, EventArgs e)// ordina prezzo crescente
        {
            Annuncio[] a = new Annuncio[999];
            Eliminaitem();
            b.OrdinaP();
            a = b.prodotti(); // passa l'array ma il text e' sbagliato

            for (int i=0; i< count; i++)
            {
                riempi(a[i]);
            }
        }
    }
}
