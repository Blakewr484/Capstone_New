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

        public List<Event> GetAllEvents()
        {
            var events = new List<Event>();
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
                        events.Add(new Event
                        {
                            EventID = reader.GetInt32(reader.GetOrdinal("EventID")),
                            EventName = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                            RegistrationCost = reader.GetDecimal(reader.GetOrdinal("RegistrationCost")),
                            EventType = reader.GetString(reader.GetOrdinal("EventType")),
                            EstimatedAttendance = reader.GetInt32(reader.GetOrdinal("EstimatedAttendance"))
                        });
                    }
                }
            }

            return events;
        }

        public void InsertEvent(Event eventModel)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = @"INSERT INTO Event (Name, Description, Address, StartDate, EndDate, RegistrationCost) 
                            VALUES (@Name, @Description, @Address, @StartDate, @EndDate, @RegistrationCost)";
                var command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", eventModel.EventName);
                command.Parameters.AddWithValue("@Description", eventModel.Description);
                command.Parameters.AddWithValue("@Address", eventModel.Address);
                command.Parameters.AddWithValue("@StartDate", eventModel.StartDate);
                command.Parameters.AddWithValue("@EndDate", eventModel.EndDate);
                command.Parameters.AddWithValue("@RegistrationCost", eventModel.RegistrationCost);
                command.Parameters.AddWithValue("@EventType", eventModel.EventType);
                command.Parameters.AddWithValue("@EstimatedAttendance", eventModel.EstimatedAttendance);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

