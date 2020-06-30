using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.ViewModels;

namespace RestaurantOnline.Models
{
    public class CartModel: BaseViewModel
    {
        private int _idProdus;
        private string _numeProdus;
        private double _pretProdus;
        private int _cantitateProdus;
        private double _pretTotalProdus;
        private bool _isMeniu;
        private string _cantitateAfisata;
        private string _pretProdusAfisat;


        public int IdProdus
        {
            get { return _idProdus; }
            set { _idProdus = value; }
        }
        public string NumeProdus
        {
            get { return _numeProdus; }
            set { _numeProdus = value; }
        }
        public double PretProdus
        {
            get { return _pretProdus; }
            set { _pretProdus = value; }
        }
        public int CantitateProdus
        {
            get { return _cantitateProdus; }
            set
            {
                _cantitateProdus = value;
                CantitateAfisata = "Cantitate: " + CantitateProdus.ToString() + " buc.";
            }
        }
        public string CantitateAfisata
        {
            get { return _cantitateAfisata; }
            set
            {
                _cantitateAfisata = value;
                OnPropertyChanged("CantitateAfisata");
            }
        }
        public double PretTotalProdus
        {
            get { return _pretTotalProdus; }
            set
            {
                _pretTotalProdus = value;
                PretProdusAfisat = "Pret: " + (PretTotalProdus).ToString();
            }
        }
        public string PretProdusAfisat
        {
            get { return _pretProdusAfisat; }
            set
            {
                _pretProdusAfisat = value;
                OnPropertyChanged("PretProdusAfisat");
            }
        }
        public bool IsMeniu
        {
            get { return _isMeniu; }
            set
            {
                _isMeniu = value;
            }
        }

        public CartModel(int idProdus, string numeProdus, double pretProdus, bool isMeniu)
        {
            IdProdus = idProdus;
            NumeProdus = numeProdus;
            PretProdus = pretProdus;
            CantitateProdus = 1;
            PretTotalProdus = pretProdus;
            IsMeniu = isMeniu;

        }
    }
}
