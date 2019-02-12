using System.Collections.Generic;
using System.Linq;
using CheckOutSystem.Model;

namespace CheckOutSystem
{
    public class Basket : IBasket
    {
        private static List<BasketItem> basketItems = null;

        public Basket()
        {
            basketItems = new List<BasketItem>();
        }

        public void AddToBasket(BasketItem item)
        {
            basketItems.Add(item);
        }

        public void CheckItemExistThenAddToBasket(BasketItem item)
        {
            if (basketItems.Any(x => x.Name.Equals(item.Name)))
                basketItems.Where(x => x.Name.Equals(item.Name)).Select(x => { x.Qty = x.Qty + 1; x.Price = x.Price + x.Price; return x; }).ToList();
            else
            {
                AddToBasket(item);
            }
        }

        public void DeleteFromBasket(BasketItem item)
        {
            basketItems.Where(x => x.Name.Equals(item.Name)).Select(x => { x.Qty = x.Qty - 1; x.Price = x.Price + x.Price; return x; }).ToList();
        }

        public List<BasketItem> GetBasketItems()
        {
            return basketItems;
        }

        public decimal TotalBasketValue()
        {
            return basketItems.Sum(x=>x.Price);
        }
    }
}
