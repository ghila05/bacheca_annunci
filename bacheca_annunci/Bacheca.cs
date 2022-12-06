using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bacheca_annunci
{
    class Bacheca
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


        public void Elimina(Annuncio e)
        {
            if (e != null)
            {
                for ( int i=0; i < lung; i++)
                {
                    if (ann[i].Id == e.Id)
                    {
                        ann[i] = null;
                    }
                }
            }
            else
            {
                throw new Exception("inserire annuncio valido");
            }
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

    }
}
