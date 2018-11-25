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
    }
}
