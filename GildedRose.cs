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
            for (var i = 0; i < Items.Count; i++)
            {
      
                var switch_on = Items[i].Name;
                switch ( switch_on)
                {
                    case "Aged Brie":
                        Items[i] = UpdateBrie(Items[i]);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        Items[i] = UpdateConcert(Items[i]);
                        break;

                    default:
                        Items[i] = UpdateDefault(Items[i]); 
                        break;
                }
                
            }
        }
        
        public Item UpdateBrie(Item aged_Brie)
        {
            if(aged_Brie.SellIn > 0 && aged_Brie.Quality < 50)
            {
                aged_Brie.Quality += 1;
            }
            else if (aged_Brie.Quality <49)
            {
                aged_Brie.Quality += 2;
            }
            aged_Brie.SellIn -= 1;
            return aged_Brie;   
        }
        public Item UpdateConcert(Item concert)
        {
            if (concert.SellIn <= 0 && concert.Quality >= 0)
            {
                concert.Quality = 0;
            }
            else{
                if(concert.SellIn > 10 && concert.Quality < 50)
                {
                    concert.Quality += 1;
                }
                else if(concert.SellIn > 5 && concert.Quality < 49)
                {
                    concert.Quality += 2;
                }
                else if(concert.SellIn > 0 && concert.Quality < 48)
                {
                    concert.Quality += 3;
                }
                else
                {
                    concert.Quality = 50;
                }
            }
            concert.SellIn -= 1;
        
            return concert;
        }

        public Item UpdateConjured(Item conjured)
        {

            if(conjured.Quality == 1 || conjured.Quality <= 0)
            {
                conjured.Quality = 0;
            }
            else
            {
                conjured.Quality -= 2;
            }
            conjured.SellIn -= 1;
            
            return conjured;
        }

        public Item UpdateDefault(Item item)
        {
            if(item.Conjured == true)
            {
                item = UpdateConjured(item);
            }

            if(item.Quality > 1)
            {
                if(item.SellIn > 0)
                {
                    item.Quality -= 1;
                }
                else
                {
                    item.Quality -= 2;
                }
            }
            else
            {
                item.Quality = 0;
            }
            item.SellIn -= 1;

            return item;
        }
    }
}
