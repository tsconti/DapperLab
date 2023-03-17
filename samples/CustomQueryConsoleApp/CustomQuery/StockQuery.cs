using CustomQueryConsoleApp.Entities;
using DapperLab.CustomQuery;

namespace CustomQueryConsoleApp.CustomQuery;

public class StockQuery : DbCustomQuery
{
    public StockQuery(IDbSession session) : base(session)
    {
        Query = $@"SELECT TOP 5
                            STO.ID                   AS [{nameof(Stock.Id)}],
                            STO.NAME                 AS [{nameof(Stock.Ticker)}],
                            STO.IS_ACTIVE            AS [{nameof(Stock.Name)}],

                            SEC.ID                   AS [Sector_{nameof(Sector.Id)}],
                            SEC.NAME                 AS [Sector_{nameof(Sector.Name)}],
                            SEC.PRICE_FULL           AS [Sector_{nameof(Sector.IsActive)}]
                        FROM 
                            STOCK AS STO 
                            INNER JOIN SECTOR AS SEC ON SEC.ID = STO.SECTOR_ID
                        WHERE 
                            PM.ID = @Id
            ";
    }

    public async Task<IEnumerable<Stock>> ExecuteAsync(int id)
    {
        var parameters = new { Id = id };

        var result = await base.ExecuteAsync(parameters);

        var stockList = result.Select(i =>
        {
            Stock stock = new()
            {
                Id = i.Id,
                Name = i.Name,
                Ticker = i.Ticker,

                Sector = new Sector()
            };
            stock.Sector.Id = i.Sector_Id;
            stock.Sector.Name = i.Sector_Name;
            stock.Sector.IsActive = i.Sector_IsActive;

            return stock;
        });

        return stockList;

    }
}

//public class StockQueryB : GenericCustomQueryB<Stock, Sector>
//{
//    public StockQueryB(IDbSession session) : base(session)
//    {
//        Query = $@"SELECT TOP 5
//                            STO.ID                   AS [{nameof(Stock.Id)}],
//                            STO.NAME                 AS [{nameof(Stock.Ticker)}],
//                            STO.IS_ACTIVE            AS [{nameof(Stock.Name)}],

//                            SEC.ID                   AS [{nameof(Sector.Id)}],
//                            SEC.NAME                 AS [{nameof(Sector.Name)}],
//                            SEC.PRICE_FULL           AS [{nameof(Sector.IsActive)}]
//                        FROM 
//                            STOCK AS STO 
//                            INNER JOIN SECTOR AS SEC ON SEC.ID = STO.SECTOR_ID
//                       -- WHERE 
//                            --PM.ID = @Id
//            ";

//        Mapper = (stock, sector) =>
//        {
//            stock.Sector = sector;
//            return stock;
//        };
//    }

//    public async Task<IEnumerable<Stock>> ExecuteAsync()
//    {
//        return await base.ExecuteAsync(null);
//    }

//}
