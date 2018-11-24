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
        public void UpdateQuality_ForAgedBrieAfter30Days_QualityShouldBeEqualTo30()
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
            Enumerable.Range(0, 30).ForEach(x => app.UpdateQuality());

            // Assert
            Assert.AreEqual(30, agedBrie.Quality);
        }
    }
}
