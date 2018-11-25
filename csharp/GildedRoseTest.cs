using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_ForAgedBrieAfter1DaysAndSellInEquals1_QualityShouldIncreaseBy1()
        {
            // Arrange
            var agedBrie = new Item
            {
                Name = "Aged Brie",
                SellIn = 1,
                Quality = 0
            };
            var items = new List<Item>
            {
                agedBrie
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(1, agedBrie.Quality);
        }

        [Test]
        public void UpdateQuality_ForAgedBrieAfter1DaysAndSellInEquals0_QualityShouldIncreaseBy2()
        {
            // Arrange
            var agedBrie = new Item
            {
                Name = "Aged Brie",
                SellIn = 0,
                Quality = 0
            };
            var items = new List<Item>
            {
                agedBrie
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(2, agedBrie.Quality);
        }

        [Test]
        public void UpdateQuality_ForAgedBrieAfter1DaysAndQuantityEquals50_QualityShouldNotIncrease()
        {
            // Arrange
            var agedBrie = new Item
            {
                Name = "Aged Brie",
                SellIn = 0,
                Quality = 50
            };
            var items = new List<Item>
            {
                agedBrie
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(50, agedBrie.Quality);
        }

        [Test]
        public void UpdateQuality_ForStandardItemAfter1DayAndSellInHigherThen0_QualityShouldDecreases()
        {
            var item = new Item
            {
                Name = "Item",
                SellIn = 1,
                Quality = 50
            };
            var items = new List<Item>
            {
                item
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(49, item.Quality);
        }

        [Test]
        public void UpdateQuality_ForStandardItemAfter1DayAndSellInIsEqual0_QualityShouldDecreasesBy2()
        {
            var item = new Item
            {
                Name = "Item",
                SellIn = 0,
                Quality = 50
            };
            var items = new List<Item>
            {
                item
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(48, item.Quality);
        }

        [Test]
        public void UpdateQuality_ForStandardItemAfter1DayAndQualityEquals0_QualityShouldBeEqual0()
        {
            var item = new Item
            {
                Name = "Item",
                SellIn = 0,
                Quality = 0
            };
            var items = new List<Item>
            {
                item
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void UpdateQuality_ForSulfurasdItemAfter1DayAndSellInEquals0_QualityShouldNotChange()
        {
            var sulfurasdItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 123
            };
            var items = new List<Item>
            {
                sulfurasdItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(123, sulfurasdItem.Quality);
        }

        [Test]
        public void UpdateQuality_ForSulfurasdItemAfter1DayAndSellInHigherThen0_QuantityShouldNotChange()
        {
            var sulfurasdItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 1,
                Quality = 123
            };
            var items = new List<Item>
            {
                sulfurasdItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(123, sulfurasdItem.Quality);
        }

        public void UpdateQuality_ForSulfurasdItemAfter1DayAndSellInHigherThen0_SellInShouldNotChange()
        { 
            var sulfurasdItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 1,
                Quality = 123
            };
            var items = new List<Item>
            {
                sulfurasdItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(1, sulfurasdItem.SellIn);
        }

        [Test]
        public void UpdateQuality_ForSulfurasdItemAfter1DayAndSellInEquals0_SellInShouldNotChange()
        {
            var sulfurasdItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 123
            };
            var items = new List<Item>
            {
                sulfurasdItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, sulfurasdItem.SellIn);
        }

        [Test]
        public void UpdateQuality_ForBackStagePassAfter1DayAndSellInLessThen11_QualityShouldIncreaseBy2()
        {
            var backstagePassItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 10
            };
            var items = new List<Item>
            {
                backstagePassItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(12, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_ForBackStagePassAfter1DayAndSellInLessThen6_QualityShouldIncreaseBy3()
        {
            var backstagePassItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 10
            };
            var items = new List<Item>
            {
                backstagePassItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(13, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_ForBackStagePassAfter1DayAndSellInLessThen0_QualityShouldEquals0()
        {
            var backstagePassItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 10
            };
            var items = new List<Item>
            {
                backstagePassItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_ForConjuredItemAfter1DayAndSellInLessThen0AndQuantityIsGraterThen2_QualityShouldDecreasesBy4()
        {
            var backstagePassItem = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = -1,
                Quality = 10
            };
            var items = new List<Item>
            {
                backstagePassItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(6, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_ForConjuredItemAfter1DayAndSellInGreaterThen0AndQuantityIsGraterThen2_QualityShouldDecreasesBy2()
        {
            var backstagePassItem = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 3,
                Quality = 10
            };
            var items = new List<Item>
            {
                backstagePassItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(8, backstagePassItem.Quality);
        }

        [Test]
        public void UpdateQuality_ForConjuredItemAfter1DayAndSellInLessThen0AndQuantityIsEqual3_QualityShouldEquals0()
        {
            var backstagePassItem = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = -1,
                Quality = 3
            };

            var items = new List<Item>
            {
                backstagePassItem
            };

            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, backstagePassItem.Quality);
        }
    }
}
