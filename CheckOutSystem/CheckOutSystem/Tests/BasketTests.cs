using CheckOutSystem.Builder;
using CheckOutSystem.Model;
using NUnit.Framework;
using System.Linq;

namespace CheckOutSystem.Tests
{
    [TestFixture]
    public class BasketTests
    {
        private IBasket _shoppingBasket;

        [SetUp]
        public void SetUp()
        {
            _shoppingBasket = new Basket();
        }

        [Test]
        public void ShouldBeAbleToAddToBasket()
        {
            var apple1 = new BasketItemBuilder (Fruits.apples, (decimal)Fruits.apples, 1).Build();

            _shoppingBasket.AddToBasket(apple1);

            Assert.AreEqual(_shoppingBasket.GetBasketItems().Count, 1);
        }

        [Test]
        public void ShouldBeAbleToAddToBasketMultipleItems()
        {
            var apple1 = new BasketItemBuilder(Fruits.apples, (decimal)Fruits.apples, 1).Build();
            var orange1 = new BasketItemBuilder(Fruits.oranges, (decimal)Fruits.oranges, 1).Build();

            _shoppingBasket.AddToBasket(apple1);
            _shoppingBasket.AddToBasket(orange1);

            Assert.AreEqual(_shoppingBasket.GetBasketItems().Count, 2);
        }

        [Test]
        public void ShouldBeAbleToIncrementWhenAddTheSameItem()
        {
            var apple1 = new BasketItemBuilder(Fruits.apples, (decimal)Fruits.apples, 1).Build();
            var apple2 = new BasketItemBuilder(Fruits.apples, (decimal)Fruits.apples, 1).Build();


            _shoppingBasket.CheckItemExistThenAddToBasket(apple1);
            _shoppingBasket.CheckItemExistThenAddToBasket(apple2);

            Assert.AreEqual(_shoppingBasket.GetBasketItems().Count, 1);
            Assert.True(_shoppingBasket.GetBasketItems().All(x=>x.Qty.Equals(2)));
        }

        [Test]
        public void ShouldBeAbleToDeleteFromBasket()
        {
            var apple1 = new BasketItemBuilder(Fruits.apples, (decimal)Fruits.apples, 1).Build();
            var apple2 = new BasketItemBuilder(Fruits.apples, (decimal)Fruits.apples, 1).Build();


            _shoppingBasket.CheckItemExistThenAddToBasket(apple1);
            _shoppingBasket.CheckItemExistThenAddToBasket(apple2);
            _shoppingBasket.DeleteFromBasket(apple2);

            Assert.AreEqual(_shoppingBasket.GetBasketItems().Count, 1);
            Assert.True(_shoppingBasket.GetBasketItems().All(x => x.Qty.Equals(1)));
        }
        [Test]
        public void BasketTotal()
        {
            var apple1 = new BasketItemBuilder(Fruits.apples, (decimal)Fruits.apples, 1).Build();
            var apple2 = new BasketItemBuilder(Fruits.apples, (decimal)Fruits.apples, 1).Build();
            var oranges1 = new BasketItemBuilder(Fruits.oranges, (decimal)Fruits.oranges, 1).Build();


            _shoppingBasket.CheckItemExistThenAddToBasket(apple1);
            _shoppingBasket.CheckItemExistThenAddToBasket(apple2);
            _shoppingBasket.CheckItemExistThenAddToBasket(oranges1);

            Assert.AreEqual(_shoppingBasket.TotalBasketValue(), 1.45);
        }
    }
}
