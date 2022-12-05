using KUSYS_Demo.Entities;

namespace KUSYS_Demo.Services
{
    public class BaseService
    {
        public DatabaseContext _databaseContext;
        public IConfiguration _configuration;

        public BaseService(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }
    }
}
