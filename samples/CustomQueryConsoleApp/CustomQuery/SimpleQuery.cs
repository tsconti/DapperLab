using CustomQueryConsoleApp.Entities;
using DapperLab.CustomQuery;

namespace CustomQueryConsoleApp.CustomQuery
{
    public class SimpleQuery : DbCustomQuery
    {
        public SimpleQuery(IDbSession session) : base(session)
        {
            Query = $@"SELECT
                            SEC.ID           AS [{nameof(Sector.Id)}],
                            SEC.NAME         AS [{nameof(Sector.Name)}]
                        FROM 
                            SECTOR AS SEC              
                        WHERE 
                            SEC.IS_ACTIVE = @IsActive
            ";
        }

        public async Task<IEnumerable<Sector>> ExecuteAsync(bool isActive)
        {
            var parameters = new { IsActive = true };

            var result = await base.ExecuteAsync(parameters);            

            return result.Select(i =>
            {
                Sector sector = new()
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsActive = i.IsActive
                };                

                return sector;
            });
        }
    }
}
