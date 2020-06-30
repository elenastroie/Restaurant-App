using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.Models;

namespace RestaurantOnline.Services
{
    public static class OrderServices
    {
        private static readonly RestaurantEDM _context = new RestaurantEDM();

        public static void AddOrder(List<CartModel> cart, double pretTotal)
        {
            double discountComanda = 0;
            var pretTransport = Properties.Settings.Default.Transport;
            if (pretTotal >= Properties.Settings.Default.PretPentruTransportGratuit)
            {
                pretTransport = Properties.Settings.Default.TransportGratuit;
            }
            if (pretTotal >= Properties.Settings.Default.PretPentruDiscount)
            {
                discountComanda = Properties.Settings.Default.DiscountComanda;
            }

            var comanda = new Comanda
            {
                fk_utilizator = CurrentSession.activeUser.Id,
                stare = "Inregistrata",
                timp_inregistrare = DateTime.Now,
                discount = discountComanda,
                cost_transport = pretTransport,
                pret_total = pretTotal
            };
            _context.Comandas.Add(comanda);

            foreach (var product in cart)
            {
                if (product.IsMeniu == true)
                {
                    comanda.ComandaMenius.Add(new ComandaMeniu()
                    {
                        Meniu = (from m in _context.Menius
                            where m.id == product.IdProdus
                            select m).First(),
                        Comanda = comanda,
                        cantitate = product.CantitateProdus
                    });
                }
                else
                {
                    comanda.ComandaPreparats.Add(new ComandaPreparat()
                    {
                        Preparat = (from d in _context.Preparats
                            where d.id == product.IdProdus
                            select d).First(),
                        Comanda = comanda,
                        cantitate = product.CantitateProdus
                    });
                }
            }

            _context.SaveChanges();
        }

        public static List<OrderModel> GetOrders()
        {
            var orders = _context.spGetOrders(CurrentSession.activeUser.Id).ToList();
            if (orders.Count < 1)
            {
                return null;
            }

            return orders.Select(order => new OrderModel
                {
                    Id = order.id,
                    IdUtilizator = order.fk_utilizator,
                    Stare = order.stare,
                    DataPlasare = order.timp_inregistrare,
                    Discount = order.discount,
                    CostTransport = order.cost_transport,
                    PretTotal = order.pret_total
                })
                .ToList();
        }
    }
}
