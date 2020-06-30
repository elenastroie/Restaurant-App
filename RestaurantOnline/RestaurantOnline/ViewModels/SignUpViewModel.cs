using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestaurantOnline.Commands;
using RestaurantOnline.Models;
using RestaurantOnline.Services;

namespace RestaurantOnline.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        private string _prenume;
        private string _nume;
        private string _email;
        private string _parola;
        private string _adresa;
        private string _telefon;
        private string _errorMessage;

        public string Prenume
        {
            get { return _prenume; }
            set
            {
                if (value != null)
                {
                    _prenume = value;
                    OnPropertyChanged("Prenume");
                }
            }
        }
        public string Nume
        {
            get { return _nume; }
            set
            {
                if (value != null)
                {
                    _nume = value;
                    OnPropertyChanged("Nume");
                }
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != null)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Parola
        {
            get { return _parola; }
            set
            {
                if (value != null)
                {
                    _parola = value;
                    OnPropertyChanged("Parola");
                }
            }
        }
        public string Adresa
        {
            get { return _adresa; }
            set
            {
                if (value != null)
                {
                    _adresa = value;
                    OnPropertyChanged("Adresa");
                }
            }
        }
        public string Telefon
        {
            get { return _telefon; }
            set
            {
                if (value != null)
                {
                    _telefon = value;
                    OnPropertyChanged("Telefon");
                }
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value != null)
                {
                    _errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        private ICommand _signInCommand;
        private ICommand _signUpCommand;

        public ICommand SignInCommand
        {
            get
            {
                if (_signInCommand == null)
                    _signInCommand = new RelayCommand(SignIn);
                return _signInCommand;
            }
        }
        public ICommand SignUpCommand
        {
            get
            {
                if (_signUpCommand == null)
                    _signUpCommand = new RelayCommand(SignUp);
                return _signUpCommand;
            }
        }

        public void SignIn(object sender)
        {
            WindowServices.SwitchToSignInUserControl();
            ClearData();
        }
        public void SignUp(object sender)
        {
            ErrorMessage = Utils.CheckErrors(Email, Parola, Nume, Prenume, Adresa, Telefon);
            if (ErrorMessage != "")
                MessageBox.Show(ErrorMessage);
            else
            {
                CurrentSession.activeUser = new ActiveUserModel(Prenume, Nume, Adresa, Telefon, false);
                UserServices.SignUp(new Utilizator
                {
                    prenume = Prenume,
                    nume = Nume,
                    email = Email,
                    parola = Parola,
                    adresa = Adresa,
                    telefon = Telefon,
                    angajat = false
                });

                WindowServices.SwitchToSignInUserControl();
                ClearData();

            }
        }

        public void ClearData()
        {
            Prenume = "";
            Nume = "";
            Email = "";
            Parola = "";
            Adresa = "";
            Telefon = "";
        }

    }
}
