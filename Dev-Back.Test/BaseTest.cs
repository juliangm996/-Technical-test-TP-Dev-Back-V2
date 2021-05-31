using Dev_Back.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Dev_Back.Test
{
    public class BaseTest
    {
        protected DataContext BuildContext(string dbName)
        {

            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(dbName).Options;

            DataContext dbContext = new DataContext(options);
            return dbContext;
        }
    }
}
