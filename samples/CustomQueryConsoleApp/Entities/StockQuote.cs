namespace CustomQueryConsoleApp.Entities;

public class StockQuote
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public Stock Stock { get; set; }
}
