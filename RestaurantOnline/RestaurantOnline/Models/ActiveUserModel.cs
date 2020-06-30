using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace RestaurantOnline.Models
{
    public class ActiveUserModel
    {
        private int _id;
        private string _prenume;
        private string _nume;
        private string _adresa;
        private string _telefon;
        private bool _angajat;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Prenume
        {
            get { return _prenume; }
            set { _prenume = value; }
        }
        public string Nume
        {
            get { return _nume; }
            set { _nume = value; }
        }
        public string Adresa
        {
            get { return _adresa; }
            set { _adresa = value; }
        }
        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }
        public bool Angajat
        {
            get { return _angajat; }
            set { _angajat = value; }
        }

        public ActiveUserModel(int id, string prenume, string nume, string adresa, string telefon, bool angajat)
        {
            Id = id;
            Prenume = prenume;
            Nume = nume;
            Adresa = adresa;
            Telefon = telefon;
            Angajat = angajat;
        }

        public ActiveUserModel(string prenume, string nume, string adresa, string telefon, bool angajat)
        {
            Prenume = prenume;
            Nume = nume;
            Adresa = adresa;
            Telefon = telefon;
            Angajat = angajat;
        }

        public ActiveUserModel()
        {
            Id = 0;
            Prenume = "";
            Nume = "";
            Adresa = "";
            Telefon = "";
            Angajat = false;
        }
    }
}
