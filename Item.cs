namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public bool Conjured { get; set; } = false;

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }
}
