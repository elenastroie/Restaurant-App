using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.Models;

namespace RestaurantOnline.Services
{
    public class ProductServices
    {
        private static readonly RestaurantEDM _context = new RestaurantEDM();

        public static List<ProductModel> GetProducts()
        {
            var productsResult = _context.spGetProducts().ToList();
            if (productsResult.Count <= 0)
            {
                return null;
            }
            var productList = productsResult.Select(product => new ProductModel(product.id, product.nume, product.pret,
                    product.unitate_masura, product.cantitate_per_portie, product.cantitate_totala,
                    product.fk_categorie, GetProductCategory(product.fk_categorie),GetProductAlergens(product.id)))
                .ToList();

            return productList;
        }

        public static string GetProductCategory(int id)
        {
            var category = _context.spGetProductCategory(id).ToList();
            return category.Count > 1 ? null : category.First();
        }

        public static List<string> GetProductAlergens(int id)
        {
            var alergensResult = _context.spGetProductAlergens(id).ToList();
            return alergensResult;
        }

        public static List<MenuModel> GetMenus()
        {
            var menusResult = _context.spGetMenus().ToList();
            if (menusResult.Count <= 0)
            {
                return null;
            }
            var menusList = menusResult.Select(menu => new MenuModel(menu.id, menu.nume, menu.fk_categorie, GetMenuCategory(menu.fk_categorie), GetMenuProducts(menu.id)))
                .ToList();

            return menusList;
        }

        public static string GetMenuCategory(int id)
        {
            var category = _context.spGetMenuCategory(id).ToList();
            return category.Count > 1 ? null : category.First();
        }

        public static List<ProductModel> GetMenuProducts(int id)
        {
            var menuProductsResult = _context.spGetMenuProducts(id).ToList();
            var menuProductstList = menuProductsResult.Select(product => new ProductModel(product.id, product.nume, product.pret,
                    product.unitate_masura, product.cantitate, product.cantitate_totala,
                    product.fk_categorie, GetProductCategory(product.fk_categorie), GetProductAlergens(product.id)))
                .ToList();

            return menuProductstList;
        }

        public static List<string> GetAlergensName()
        {
            var nameResults = _context.spGetAlergensName().ToList();
            return new List<string>(nameResults);
        }

        public static List<string> GetCategoriesName()
        {
            var nameResults = _context.spGetCategoriesName().ToList();
            return new List<string>(nameResults);
        }
    }
}
