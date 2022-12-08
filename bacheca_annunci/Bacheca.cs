using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bacheca_annunci
{
    public class Bacheca
    {
        private string _id;
        private const int MAXann = 999;
        private int lung;
        private Annuncio[] ann = new Annuncio[MAXann];


        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if (value != "")
                {
                    _id = value;
                }
                else
                {
                    throw new Exception("invalid id");
                }

            }
        }

        public Bacheca()
        {

        }

        public Bacheca(string id)
        {
            Id = id;
        }

        public void Aggiungi(Annuncio a)
        {
            if (lung == MAXann)
            {
                throw new Exception("bacheca piena");
            }
            if (a != null)
            {
                ann[lung] = a;
                lung++;
            }

        }
    
        public void Modifica(Annuncio n)
        {
            if (n != null)
            {
                for (int i =0; i < lung; i++)
                {
                    if (ann[i].Id == n.Id)
                    {
                        ann[i] = n;
                    }
                }
            }
            else
            {
                throw new Exception("inserire annuncio valido");
            }
        }

        public int Remove(int p)
        {
            if (p != -1)
            {
                for (int i = p; i < ann.Length - 1; i++)
                    ann[i] = ann[i + 1];

                ann[ann.Length - 1] = null;

                lung--;

                return p;
            }
            else
                throw new Exception("Product not found");
        }




        public void OrdinaP()
        {
            for (int i =0; i< lung; i++)
            {
                for (int j = 1; j < lung - i; j++)
                {
                    if (ann[j - 1].Prezzo > ann[j].Prezzo)
                    {
                        Annuncio temp = ann[j - 1];
                        ann[j - 1] = ann[j];
                        ann[j] = temp;
                    }
                }
            }

        }

        public float Costotot()
        {
            float tot=0;

            for ( int i =0; i < lung; i++)
            {
                tot = tot + ann[i].Prezzo;
            }

            return tot;

        }

        public void visualizza()
        {
            for (int i=0; i < lung; i++)
            {
                MessageBox.Show(ann[i].Text);
            }
        }
 

    }
}
