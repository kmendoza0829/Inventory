using Dapper;
using Inventory.DataAccess.Entities;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Infrastructure.Models;
using Inventory.Domain.Infrastructure.Repositories.User;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Inventory.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IOptions<AppSettingsModel> settings;

        public UserRepository(IOptions<AppSettingsModel> settings)
        {
            this.settings = settings;
        }

        public async Task<bool> Add(UserManager userManager)
        {

            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string insertUserSQL = "INSERT INTO Users(UserId,Identification,Name,Username,Password,Status,Type,DateCreation) VALUES (@Id, @Identification, @Name, @Username, @Password, @Status,@Type, @DateCreation)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", userManager.UserId);
            dynamicParameters.Add("@Identification", userManager.Identification);
            dynamicParameters.Add("@Name", userManager.Name);
            dynamicParameters.Add("@Username", userManager.Username);
            dynamicParameters.Add("@Password", userManager.Password);
            dynamicParameters.Add("@Status", userManager.Status);
            dynamicParameters.Add("@Type", userManager.Type);
            dynamicParameters.Add("@DateCreation", userManager.DateCreation);
            int rowsInserted = await db.ExecuteAsync(insertUserSQL, dynamicParameters);
            if (rowsInserted > 0)
                return true;
            return false;
        }

        public async Task<bool> ExistsUsername(string username)
        {
            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string usernameSQL = @"SELECT * FROM Users WHERE Username = @Username";
            User user = await db.QueryFirstOrDefaultAsync<User>(usernameSQL, new { Username = username });
            if (user == null)
                return false;
            return true;
        }

        public async Task<bool> ExistsIdentification(string identification)
        {
            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string usernameSQL = @"SELECT * FROM Users WHERE Identification = @Identification";
            User user = await db.QueryFirstOrDefaultAsync<User>(usernameSQL, new { Identification = identification });
            if (user == null)
                return false;
            return true;
        }

        public async Task<UserManager> GetById(Guid id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
                string usernameSQL = @"SELECT * FROM Users WHERE UserId = @Id";
                return await db.QueryFirstOrDefaultAsync<UserManager>(usernameSQL, new { Id = id });
            }
            catch (Exception)
            {

                throw;
            }
                      
        }

        public List<UserManager> GetUsers()
        {
            List<UserManager> users = new();
            using (IDbConnection db = new SqlConnection(settings.Value.DefaultConnection))
            {
                string usernameSQL = @"SELECT * FROM Users ";
                using (var reader = db.ExecuteReader(usernameSQL))
                {
                    var parser = reader.GetRowParser<UserManager>();
                    while (reader.Read())
                    {
                        UserManager userParser = parser(reader);
                        users.Add(userParser);
                    }
                }
            };
            return users;
        }

        public async Task<bool> UpdateStatus(Guid id, bool status)
        {

            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string updateUserSQL = "UPDATE Users SET Status = @Status WHERE UserId = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Status", status);
            dynamicParameters.Add("@Id", id);
            int rowsInserted = await db.ExecuteAsync(updateUserSQL, dynamicParameters);
            if (rowsInserted > 0)
                return true;
            return false;
        }

        public async Task<bool> Update(UserManager userManager)
        {

            using IDbConnection db = new SqlConnection(settings.Value.DefaultConnection);
            string insertUserSQL = "UPDATE Users SET Identification = @Identificacion ,Name = @Name ,Password = @password WHERE UserId = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Identificacion", userManager.Identification);
            dynamicParameters.Add("@Name", userManager.Name);
            dynamicParameters.Add("@Password", userManager.Password);
            dynamicParameters.Add("@Id", userManager.UserId);
            int rowsInserted = await db.ExecuteAsync(insertUserSQL, dynamicParameters);
            if (rowsInserted > 0)
                return true;
            return false;
        }

    }
}
