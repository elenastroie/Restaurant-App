using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.Models;

namespace RestaurantOnline.Services
{
    public class UserServices
    {
        private static readonly RestaurantEDM _context = new RestaurantEDM();

        public static Utilizator SignIn(string email, string password)
        {
            var loginResults = _context.spLogin(email, password).ToList();
            if (loginResults.Count != 1)
            {
                return null;
            }

            if (!loginResults.First().email.Equals(email) || !loginResults.First().parola.Equals(password))
            {
                return null;
            }

            return new Utilizator
            {
                id = loginResults.First().id,
                prenume = loginResults.First().prenume,
                nume = loginResults.First().nume,
                email = loginResults.First().email,
                parola = loginResults.First().parola,
                adresa = loginResults.First().adresa,
                telefon = loginResults.First().telefon,
                angajat = loginResults.First().angajat
            };

        }

        public static void SignUp(Utilizator user)
        {
            _context.spRegister(user.prenume, user.nume, user.email, user.parola, user.telefon, user.adresa);
            _context.SaveChanges();
        }

    }
}
