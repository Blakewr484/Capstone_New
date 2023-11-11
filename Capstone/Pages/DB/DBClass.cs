using Capstone.Pages.Data_Classes;
using Capstone.Pages.Events;
using System.Data.SqlClient;


namespace Capstone.Pages.DB
{
    public class DBClass
    {
        public static SqlConnection Lab1DBConn = new SqlConnection();
        public static readonly String Lab1DBConnString = "Server = Localhost;Database = Cap;Trusted_Connection = True";

        private readonly IConfiguration _configuration;

        public DBClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<NewEventModel> GetAllEvents()
        {
            var events = new List<NewEventModel>();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT EventID, Name, Description, Address, StartDate, EndDate, RegistrationCost FROM Event";
                var command = new SqlCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new Events
                        {
                            EventID = reader.GetInt32(reader.GetOrdinal("EventID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Location = reader.GetString(reader.GetOrdinal("Address")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                            RegistrationFee = reader.GetDecimal(reader.GetOrdinal("RegistrationCost"))
                        });
                    }
                }
            }

            return events;
        }

        public void InsertEvent(NewEventModel eventModel)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = @"INSERT INTO Event (Name, Description, Address, StartDate, EndDate, RegistrationCost) 
                            VALUES (@Name, @Description, @Address, @StartDate, @EndDate, @RegistrationCost)";
                var command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", eventModel.Name);
                command.Parameters.AddWithValue("@Description", eventModel.Description);
                command.Parameters.AddWithValue("@Address", eventModel.Address);
                command.Parameters.AddWithValue("@StartDate", eventModel.StartDate);
                command.Parameters.AddWithValue("@EndDate", eventModel.EndDate);
                command.Parameters.AddWithValue("@RegistrationCost", eventModel.RegistrationFee);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

