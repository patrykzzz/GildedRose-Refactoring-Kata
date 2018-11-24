using System.Collections.Generic;

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
            foreach (var item in Items)
            {
                if (!IsItemAgedBrie(item) && !IsItemBackstagePass(item))
                {
                    if (item.Quality > 0)
                    {
                        if (!IsItemSulfuras(item))
                        {
                            item.Quality = item.Quality - 1;
                            if(item.Name == "Conjured Mana Cake")
                            {
                                if (item.Quality > 0)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (IsItemBackstagePass(item))
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!IsItemSulfuras(item))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!IsItemAgedBrie(item))
                    {
                        if (!IsItemBackstagePass(item))
                        {
                            if (item.Quality > 0)
                            {
                                if (!IsItemSulfuras(item))
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
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
    }
}
