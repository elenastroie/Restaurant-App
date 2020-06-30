using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RestaurantOnline.Commands;
using RestaurantOnline.Models;
using RestaurantOnline.Services;

namespace RestaurantOnline.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        private string _password;
        private string _email;
        private string _errorMessage;

        public string Password
        {
            get { return _password; }
            set
            {
                if (value != null)
                {
                    _password = value;
                    OnPropertyChanged("Password");
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
            var user = UserServices.SignIn(Email, Password);
            if (user == null)
            {
                MessageBox.Show("Incorrect email/password!");
            }
            else
            {
                CurrentSession.activeUser =
                    new ActiveUserModel(user.id, user.prenume, user.nume, user.adresa, user.telefon, user.angajat);
                WindowServices.SwitchToRestaurantWindow();
            }
        }
        public void SignUp(object sender)
        {
            WindowServices.SwitchToSignUpUserControl();
            ClearData();
        }

        public SignInViewModel()
        {
            Email = "";
            Password = "";
            ErrorMessage = "";
        }

        public void ClearData()
        {
            Email = "";
            Password = "";
            ErrorMessage = "";
        }
    }
}
