using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var regularItems = Items.Where(x => !IsItemAgedBrie(x) && !IsItemBackstagePass(x) && !IsItemSulfuras(x))
                .Where(x => x.Quality > 0)
                .ToList();

            regularItems.ForEach(DecreaseItemQuality);
            regularItems.Where(x => x.SellIn <= 0)
                .ToList()
                .ForEach(DecreaseItemQuality);

            regularItems.Where(IsItemConjured)
                .ToList()
                .ForEach(DecreaseItemQuality);

            var specialItems = Items.Where(x => IsItemAgedBrie(x) || IsItemBackstagePass(x))
                .Where(x => x.Quality < 50)
                .ToList();

            specialItems.ForEach(IncreaseItemQuality);

            var backstagePasses = specialItems.Where(IsItemBackstagePass);

            var backstagePassesWithHighSellIn = backstagePasses
                .Where(x => x.SellIn < 11 && x.Quality < 50)
                .ToList();

            backstagePassesWithHighSellIn.ForEach(IncreaseItemQuality);

            backstagePassesWithHighSellIn
                .Where(x => x.SellIn < 6)
                .ToList()
                .ForEach(IncreaseItemQuality);

            Items.Where(x => !IsItemSulfuras(x))
                .ToList()
                .ForEach(DecreaseSellIn);

            var itemsWithNegativeSellIn = Items.Where(x => x.SellIn < 0);

            itemsWithNegativeSellIn.Where(IsItemConjured)
                .Where(x => x.Quality > 0)
                .ToList()
                .ForEach(DecreaseItemQuality);

            itemsWithNegativeSellIn.Where(IsItemBackstagePass)
                .ToList()
                .ForEach(x => x.Quality = 0);

            itemsWithNegativeSellIn.Where(IsItemAgedBrie)
                .Where(x => x.Quality < 50)
                .ToList()
                .ForEach(IncreaseItemQuality);
        }

        private static bool IsItemSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool IsItemAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool IsItemBackstagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsItemConjured(Item item)
        {
            return item.Name == "Conjured Mana Cake";
        }

        private static void IncreaseItemQuality(Item item)
        {
            item.Quality++;
        }

        private static void DecreaseItemQuality(Item item)
        {
            item.Quality--;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
