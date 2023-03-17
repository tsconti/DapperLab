namespace CustomQueryConsoleApp.Entities;

public class Stock
{
    public int Id { get; set; }
    public string? Ticker { get; set; }
    public string? Name { get; set; }
    public Sector? Sector { get; set; }

    // Navigation
    public int? SectorId { get; set; }
}
