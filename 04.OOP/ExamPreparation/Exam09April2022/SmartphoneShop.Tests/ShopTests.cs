using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class ShopTests
    {
        private Shop shop;
        private Smartphone smartphone;
        private int capacity;

        [SetUp]
        public void SetUp() 
        {
            capacity = 5;
            shop = new Shop(capacity);
            smartphone = new Smartphone("iPhone", 100);
            shop.Add(smartphone);
        }

        [Test]
        public void Constructor_MakeNewShopProperly()
        {
            capacity = 10;
            shop = new Shop(capacity);

            Assert.AreEqual(capacity, shop.Capacity);
        }

        [Test]
        public void CapacityProperty_ReturnCapacityOfTheShop()
        {
            Assert.AreEqual(capacity, shop.Capacity);
        }

        [Test]
        public void CapacityProperty_IfValueIsBelow0ShouldThrowException()
        {
            capacity = -10;

            Assert.Throws<ArgumentException>(() => shop = new Shop(capacity));
        }
        
        [Test]
        public void AddMethod_AddSmartphoneToTheShop()
        {
            Assert.AreEqual(1, shop.Count);
        }
        
        [Test]
        public void AddMethod_TryingToAddExistingPhoneShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }
        
        [Test]
        public void AddMethod_TryingToAddPhoneToFullShopShouldThrowException()
        {
            capacity = 1;
            shop = new Shop(capacity);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }
        
        [Test]
        public void RemoveMethod_DecreaseTheShopCount()
        {
            shop.Remove("iPhone");

            Assert.AreEqual(0, shop.Count);
        }
        
        [Test]
        public void RemoveMethod_IfTryToRemoveNonExistingPhoneShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Samsung"));
        }
        
        [Test]
        public void TestPhoneMethod_IfTryToRemoveNonExistingPhoneShouldThrowException()
        {
            shop.TestPhone("iPhone", 50);

            Assert.AreEqual(50, smartphone.CurrentBateryCharge);
        }
        
        [Test]
        public void TestPhoneMethod_IfTryToTestNonExistingPhoneShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", 50));
        }
        
        [Test]
        public void TestPhoneMethod_IfTryToTestPhoneWithCurrentBatteryChargeLowerThanBatteryUsageShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("iPhone", 150));
        }

        [Test]
        public void ChargePhoneMethod_IncreaseCurrentBatteryChargeToMaximumBatteryCharge()
        {
            shop.TestPhone("iPhone", 50);
            shop.ChargePhone("iPhone");

            Assert.AreEqual(smartphone.MaximumBatteryCharge, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneMethod_IfTryToChargeNonExistingPhoneShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Samsung"));
        }
    }
}