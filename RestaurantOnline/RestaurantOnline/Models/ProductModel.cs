using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.Services;

namespace RestaurantOnline.Models
{
    public class ProductModel
    {
        private int _id;
        private string _nume;
        private double _pret;
        private string _unitateDeMasura;
        private int _cantitatePortie;
        private int _cantitateTotala;
        private int _fkCategorie;
        private string _categorie;
        private List<string> _alergeni;
        private bool _valabilitate;
        private string _cantitateAfisata;
        private string _pretAfisat;
        private string _imagineCurenta;
        private List<string> _listaImagini;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nume
        {
            get { return _nume; }
            set { _nume = value; }
        }
        public double Pret
        {
            get { return _pret; }
            set { _pret = value; }
        }
        public string UnitateDeMasura
        {
            get { return _unitateDeMasura; }
            set { _unitateDeMasura = value; }
        }
        public int CantitatePortie
        {
            get { return _cantitatePortie; }
            set { _cantitatePortie = value; }
        }
        public int CantitateTotala
        {
            get { return _cantitateTotala; }
            set { _cantitateTotala = value; }
        }
        public int FkCategorie
        {
            get { return _fkCategorie; }
            set { _fkCategorie = value; }
        }
        public string Categorie
        {
            get { return _categorie; }
            set { _categorie = value; }
        }
        public List<string> Alergeni
        {
            get { return _alergeni; }
            set { _alergeni = value; }
        }
        public bool Valabilitate
        {
            get { return _valabilitate; }
            set { _valabilitate = value; }
        }
        public string CantitateAfisata
        {
            get { return _cantitateAfisata; }
            set { _cantitateAfisata = value; }
        }
        public string PretAfisat
        {
            get { return _pretAfisat; }
            set { _pretAfisat = value; }
        }
        public string ImagineCurenta
        {
            get { return _imagineCurenta; }
            set { _imagineCurenta = value; }
        }

        public ProductModel(int id, string nume, double pret, string unitateDeMasura, int cantitatePortie, int cantitateTotala, int fkCategorie, string categorie, List<string> alergeni )
        {
            Id = id;
            Nume = Utils.ChangeNameFormat(nume);
            Pret = pret;
            PretAfisat = pret + " Lei";
            UnitateDeMasura = unitateDeMasura;
            CantitatePortie = cantitatePortie;
            CantitateAfisata = cantitatePortie + unitateDeMasura;
            CantitateTotala = cantitateTotala;
            FkCategorie = fkCategorie;
            Categorie = categorie;
            Alergeni = alergeni;
            ImagineCurenta = Utils.GetProductFirstImagePath(nume);
        }

    }
}
