using CheckOutSystem.Model;
using System.Collections.Generic;

namespace CheckOutSystem
{
    public interface IBasket
    {
        void AddToBasket(BasketItem item);
        List<BasketItem> GetBasketItems();
        void CheckItemExistThenAddToBasket(BasketItem item);
        void DeleteFromBasket(BasketItem item);
        decimal TotalBasketValue();
    }
}
