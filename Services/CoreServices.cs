using KUSYS_Demo.Entities;
using Microsoft.Extensions.Configuration;
using NETCore.Encrypt.Extensions;

namespace KUSYS_Demo.Services
{
    public class CoreServices : BaseService
    {
        public CoreServices(DatabaseContext databaseContext, IConfiguration configuration) : base(databaseContext, configuration)
        {
        }

        public string EncryptPassword(string password)
        {
            try
            {
                //Hashing password with MD5 method using salt from appsettings.json
                string md5Salt_ = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword_ = password + md5Salt_;
                string encryptedPassword_ = saltedPassword_.MD5();

                return encryptedPassword_;
            }
            catch (Exception ex)
            {
                //Error log here.
                return string.Empty;
            }

        }
    }
}
