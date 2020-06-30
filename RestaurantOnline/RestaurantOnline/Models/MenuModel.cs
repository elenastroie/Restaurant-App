using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.Services;

namespace RestaurantOnline.Models
{
    public class MenuModel
    {
        private int _id;
        private string _nume;
        private int _fkCategorie;
        private string _categorie;
        private List<ProductModel> _preparateMeniu;
        private List<string> _preparateMeniuNumePlusCantitate;
        private List<string> _alergeniMeniu;
        private string _cantitateAfisata;
        private int _pretMeniu;
        private string _imagineCurenta;

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
        public List<ProductModel> PreparateMeniu
        {
            get { return _preparateMeniu; }
            set { _preparateMeniu = value; }
        }
        public List<string> PreparateMeniuNumePlusCantite
        {
            get { return _preparateMeniuNumePlusCantitate; }
            set { _preparateMeniuNumePlusCantitate = value; }
        }
        public List<string> AlergeniMeniu
        {
            get { return _alergeniMeniu; }
            set { _alergeniMeniu = value; }
        }
        public string CantitateAfisata
        {
            get { return _cantitateAfisata; }
            set { _cantitateAfisata = value; }
        }
        public int PretMeniu
        {
            get { return _pretMeniu; }
            set { _pretMeniu = value; }
        }
        public string ImagineCurenta
        {
            get { return _imagineCurenta; }
            set { _imagineCurenta = value; }
        }


        public void GetPretMeniu()
        {
            PretMeniu = 0;

            double pret = 0;

            foreach (var produs in PreparateMeniu)
            {
                pret += produs.Pret;
            }

            pret = pret - pret / 100 * Convert.ToInt32(Properties.Settings.Default.DiscountMeniu);

            PretMeniu = Convert.ToInt32(pret);

        }

        public void GetCantitate()
        {
            int cantitate = 0;
            foreach (var produs in PreparateMeniu)
            {
                cantitate += produs.CantitatePortie;
            }

            CantitateAfisata = cantitate + "g";
        }

        public MenuModel(int id, string nume, int fkCategorie, string categorie, List<ProductModel> preparateMeniu)
        {
            Id = id;
            Nume = Utils.ChangeNameFormat(nume);
            FkCategorie = fkCategorie;
            Categorie = categorie;
            PreparateMeniu = preparateMeniu;
            PreparateMeniuNumePlusCantite = new List<string>();
            AlergeniMeniu = new List<string>();
            ImagineCurenta = Utils.GetProductFirstImagePath(nume);

            foreach (var product in preparateMeniu)
            {
                var produs = product.Nume + " " + product.CantitateAfisata;
                PreparateMeniuNumePlusCantite.Add(produs);

                foreach (var alergen in product.Alergeni)
                    AlergeniMeniu.Add(alergen);
            }

            GetPretMeniu();
            GetCantitate();
        }
       

    }
}
