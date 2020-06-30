using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RestaurantOnline.Commands;
using RestaurantOnline.Services;

namespace RestaurantOnline.ViewModels
{
    class MenuBarViewModel
    {

        private ICommand switchToMenuCommand;
        private ICommand switchToProductCommand;
        private ICommand switchToOrderCommand;
        private ICommand switchToMyCartCommand;
        private ICommand switchToAboutCommand;

        private ICommand switchToMainWindowCommand;


        public ICommand SwitchToMenuCommand
        {
            get
            {
                if (switchToMenuCommand == null)
                    switchToMenuCommand = new RelayCommand(SwitchToMenuScreen);
                return switchToMenuCommand;
            }
        }

        public ICommand SwitchToProductCommand
        {
            get
            {
                if (switchToProductCommand == null)
                    switchToProductCommand = new RelayCommand(SwitchToProductScreen);
                return switchToProductCommand;
            }
        }
        public ICommand SwitchToOrderCommand
        {
            get
            {
                if (switchToOrderCommand == null)
                    switchToOrderCommand = new RelayCommand(SwitchToOrderScreen);
                return switchToOrderCommand;
            }
        }

        public ICommand SwitchToMyCartCommand
        {
            get
            {
                if (switchToMyCartCommand == null)
                    switchToMyCartCommand = new RelayCommand(SwitchToMyCartScreen);
                return switchToMyCartCommand;
            }
        }

        public ICommand SwitchToMainWindowCommand
        {
            get
            {
                if (switchToMainWindowCommand == null)
                    switchToMainWindowCommand = new RelayCommand(SwitchToMainWindowScreen);
                return switchToMainWindowCommand;
            }
        }

        public ICommand SwitchToAboutCommand
        {
            get
            {
                if (switchToAboutCommand == null)
                    switchToAboutCommand = new RelayCommand(SwitchToAboutScreen);
                return switchToAboutCommand;
            }
        }


        public void SwitchToMenuScreen(object sender)
        {
            WindowServices.SwitchToMenuUserControl();
        }

        public void SwitchToProductScreen(object sender)
        {
            WindowServices.SwitchToProductUserControl();
        }

        public void SwitchToOrderScreen(object sender)
        {
            WindowServices.SwitchToOrdersUserControl();
        }

        public void SwitchToMyCartScreen(object sender)
        {
            WindowServices.SwitchToMyCartUserControl();
        }

        public void SwitchToMainWindowScreen(object sender)
        {
            WindowServices.SwitchToStartUpWindow();
        }

        public void SwitchToAboutScreen(object sender)
        {
            WindowServices.SwitchToRestaurantUserControl();
        }

    }
}
