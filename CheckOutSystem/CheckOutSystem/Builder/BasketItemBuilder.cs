using CheckOutSystem.Model;

namespace CheckOutSystem.Builder
{
    public class BasketItemBuilder
    {
        private BasketItem _basketItem = new BasketItem();

        public BasketItemBuilder(Fruits name, decimal price, int qty)
        {
            _basketItem.Name = name;
            _basketItem.Price = price/100;
            _basketItem.Qty = qty;
        }

        public BasketItem Build()
        {
            return _basketItem;
        }

    }
}
