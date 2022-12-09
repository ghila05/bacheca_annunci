using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bacheca_annunci
{
    public class Annuncio
    {
        private int _id;
        private string _text;
        private string _data;
        private float _prezzo;

        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if (value >= 0)
                {
                    _id = value;
                }
                else
                {
                    throw new Exception("invalid id");
                }
            }
        }


        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value != "")
                {
                    _text = value;
                }
                else
                {
                    throw new Exception("invalid text");
                }
            }
        }

        public string Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (value != "")
                {
                    _data = value;
                }
                else
                {
                    throw new Exception("invalid data");
                }
            }
        }

        public float Prezzo
        {
            get
            {
                return _prezzo;
            }
            set
            {
                if (value > 0)
                {
                    _prezzo = value;
                }
                else
                {
                    throw new Exception("invalid price");
                }
            }
        }

        public Annuncio()
        {

        }

        public Annuncio(int id, string text, string data, float prezzo)
        {
            Id = id;
            Text = text;
            Data = data;
            Prezzo = prezzo;
        }


    }
}
