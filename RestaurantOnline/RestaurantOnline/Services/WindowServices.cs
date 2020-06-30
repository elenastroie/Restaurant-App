using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RestaurantOnline.Views;

namespace RestaurantOnline.Services
{
    public static class WindowServices
    {
        public static MainWindow SignInWindow;
        public static RestaurantView RestaurantWindow;

        public static void SwitchToRestaurantWindow()
        {
            new RestaurantView().Show();
            if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();
        }

        public static void SwitchToStartUpWindow()
        {
            new MainWindow().Show();
            RestaurantWindow?.Close();
        }

        public static void SwitchToSignUpUserControl()
        {
            SignInWindow.SignInView.Visibility = Visibility.Hidden;
            SignInWindow.SignUpView.Visibility = Visibility.Visible;
        }

        public static void SwitchToSignInUserControl()
        {
            SignInWindow.SignInView.Visibility = Visibility.Visible;
            SignInWindow.SignUpView.Visibility = Visibility.Hidden;
        }
        public static void SwitchToMenuUserControl()
        {
            RestaurantWindow.MenuView.Visibility = Visibility.Visible;
            RestaurantWindow.ProductsView.Visibility = Visibility.Hidden;
            RestaurantWindow.OrdersView.Visibility = Visibility.Hidden;
            RestaurantWindow.MyCartView.Visibility = Visibility.Hidden;
            RestaurantWindow.AboutView.Visibility = Visibility.Hidden;
        }
        public static void SwitchToProductUserControl()
        {
            RestaurantWindow.MenuView.Visibility = Visibility.Hidden;
            RestaurantWindow.ProductsView.Visibility = Visibility.Visible;
            RestaurantWindow.OrdersView.Visibility = Visibility.Hidden;
            RestaurantWindow.MyCartView.Visibility = Visibility.Hidden;
            RestaurantWindow.AboutView.Visibility = Visibility.Hidden;
        }
        public static void SwitchToOrdersUserControl()
        {
            RestaurantWindow.MenuView.Visibility = Visibility.Hidden;
            RestaurantWindow.ProductsView.Visibility = Visibility.Hidden;
            RestaurantWindow.OrdersView.Visibility = Visibility.Visible;
            RestaurantWindow.OrdersView.OrderViewModel.updateOrdersList();
            RestaurantWindow.MyCartView.Visibility = Visibility.Hidden;
            RestaurantWindow.AboutView.Visibility = Visibility.Hidden;
        }
        public static void SwitchToMyCartUserControl()
        {
            RestaurantWindow.MenuView.Visibility = Visibility.Hidden;
            RestaurantWindow.ProductsView.Visibility = Visibility.Hidden;
            RestaurantWindow.OrdersView.Visibility = Visibility.Hidden;
            RestaurantWindow.MyCartView.CartViewModel.GetCurrentCart();
            RestaurantWindow.MyCartView.Visibility = Visibility.Visible;
            RestaurantWindow.AboutView.Visibility = Visibility.Hidden;
        }
        public static void SwitchToRestaurantUserControl()
        {
            RestaurantWindow.MenuView.Visibility = Visibility.Hidden;
            RestaurantWindow.ProductsView.Visibility = Visibility.Hidden;
            RestaurantWindow.OrdersView.Visibility = Visibility.Hidden;
            RestaurantWindow.MyCartView.Visibility = Visibility.Hidden;
            RestaurantWindow.AboutView.Visibility = Visibility.Visible;
        }
    }
}
