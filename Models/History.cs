namespace CoincapTask.Models
{
    public class History
    {
        public decimal? PriceUsd { get; set; }
        public long Time { get; set; }
        public decimal? CirculatingSupply { get; set; }
        public DateTime Date { get; set; }
    }
}