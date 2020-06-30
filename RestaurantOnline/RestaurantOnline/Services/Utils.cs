using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;

namespace RestaurantOnline.Services
{ 
    public class Utils
    {
        public static bool VerifyEmailAddress(string email)
        {
            var rgx = 
                new Regex(@"^[a-zA-Z0-9]+[._-]{0,1}[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$");
            return rgx.IsMatch(email);
        }

        public static bool VerifyFirstLastName(string name)
        {
            var rgx = new Regex(@"^[A-Za-z]+[,.'-]*[A-Za-z]$");
            return rgx.IsMatch(name);
        }

        public static bool VerifyPhoneNumber(string phone)
        {
            var rgx = new Regex(@"^07[2-8]{1,1}[0-9]{7,7}$");
            return rgx.IsMatch(phone);
        }

        public static string CheckErrors(string email,string parola,string nume,string prenume,string adresa,string telefon)
        {
            var errorMessage = "";
            var count = 0;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(parola) ||
                string.IsNullOrEmpty(prenume) || string.IsNullOrEmpty(nume) ||
                string.IsNullOrEmpty(adresa) || string.IsNullOrEmpty(telefon))
            {
                errorMessage = "Field left empty!";
            }
            else
            {
                if (!VerifyEmailAddress(email))
                {
                    errorMessage = "Incorrect email entered!";
                    count += 1;
                }

                if (parola.Contains(" "))
                {
                    errorMessage = "Password can't contain spaces!";
                    count += 1;
                }

                if (!VerifyPhoneNumber(telefon))
                {
                    errorMessage = "Number is incorrect!";
                    count += 1;
                }

                if (!VerifyFirstLastName(nume) || !VerifyFirstLastName(prenume))
                {
                    errorMessage = "First/Last name is incorrect!";
                    count += 1;
                }

                if (count > 1)
                {
                    errorMessage = "Multiple fields are incorrect";
                }
            }

            return errorMessage;
        }

        public static string ChangeNameFormat(string dbName)
        {
            string name = null;
            var dbNameSplit = dbName.Split('_');
            for (var i = 0; i < dbNameSplit.Length; ++i)
            {
                if (i < dbNameSplit.Length - 1)
                {
                    name += char.ToUpper(dbNameSplit[i][0]) + dbNameSplit[i].Substring(1) + " ";
                }
                else
                {
                    name += char.ToUpper(dbNameSplit[i][0]) + dbNameSplit[i].Substring(1);
                }
            }
            
            return name;
        }

        public static string GetProjectPath()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        }

        public static string GetProductsImagesPath()
        {
            return GetProjectPath() + "\\Resources\\ProductsIcons\\";
        }

        public static string GetProductFirstImagePath(string nume)
        {
            var path =GetProductsImagesPath() + nume + ".jpg";
            if (!File.Exists(path))
            {
                path =GetProductsImagesPath() + nume + ".png";
            }
            return path;
        }

        public static List<string> GetProductImages(string productName)
        {
            var allpictures = Directory.GetFiles(GetProductsImagesPath(), "*.*");

            return allpictures.Where(pictureString => pictureString.Contains(productName)).ToList();
        }
    }
}
