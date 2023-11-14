namespace HotelManagementSoftware;


using System.Data;
using System.Data.SqlClient;
using Dapper;


public class DBContext : ISQLRepository
{
    private static IDbConnection connection = new SqlConnection("Server=localhost,1433;User=sa;Password=apA123!#!;Database=HotellManagementSoftware;");
    public static string sql;



    public void OpenDBConnection()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    public IEnumerable<ISearchable> GetData()
    {
        List<ISearchable> searchables = new List<ISearchable>();

        OpenDBConnection();
        sql = "SELECT id, roomNumber, type, price FROM Room;";
        IEnumerable<Room> rooms = connection.Query<Room>(sql);
        searchables.AddRange(rooms);

        sql = "SELECT id, name, email, phoneNumber FROM Customer;";
        IEnumerable<Customer> customers = connection.Query<Customer>(sql);
        searchables.AddRange(customers);

        sql = "SELECT id, checkIn, checkOut, totalCost, customerId, roomId FROM Reservation;";
        IEnumerable<Reservation> reservations = connection.Query<Reservation>(sql);
        searchables.AddRange(reservations);

        return searchables;
    }


    public int AddData(ISearchable x)
    {
        if (x is Customer _customer)
        {
            // Customer _customer = (Customer)x;
            OpenDBConnection();
            sql = "INSERT INTO Customer(name, email, phoneNumber) VALUES (@Name, @Email, @PhoneNumber);SELECT SCOPE_IDENTITY();";
            int customerId = connection.QuerySingle<int>(sql, _customer);
            return customerId;
        }
        if (x is Room _room)
        {
            // Room _room = (Room)x;
            OpenDBConnection();
            sql = "UPDATE Room SET type = @Type, price = @Price OUTPUT INSERTED.id WHERE roomNumber = @RoomNumber;";
            int roomId = connection.QuerySingle<int>(sql, _room);
            return roomId;
        }
        if (x is Reservation _reservation)
        {
            // Reservation _reservation = (Reservation)x;
            sql = "INSERT INTO Reservation(checkIn, checkOut, totalCost, customerId, roomId) OUTPUT INSERTED.id VALUES( @CheckIn, @CheckOut, @TotalCost, @CustomerId, @RoomId)";
            int reservationId = connection.QuerySingle<int>(sql, _reservation);
            return reservationId;
        }
        return 0;
    }


}


//___________________________________________________________________________________________________________________________________________

// förtsa metoder att hämta och skicka data til databasen.
/*  public IEnumerable<ISearchable> GetRooms()
    {
        OpenDBConnection();
        sql = "SELECT id, roomNumber, type, price FROM Room;";
        IEnumerable<Room> rooms = connection.Query<Room>(sql);
        return rooms;
    }

    public IEnumerable<ISearchable> GetCustomers()
    {
        OpenDBConnection();
        sql = "SELECT id, name, email, phoneNumber FROM Customer;";
        IEnumerable<Customer> customers = connection.Query<Customer>(sql);
        return customers;
    }

    public IEnumerable<ISearchable> GetReservations()
    {
        OpenDBConnection();
        sql = "SELECT id, checkIn, checkOut, totalCost, customerId, roomId FROM Reservation;";
        IEnumerable<Reservation> reservations = connection.Query<Reservation>(sql);
        return reservations;
    }


    public int AddCustomer(ISearchable x)
    {
        Customer _customer = (Customer)x;
        OpenDBConnection();
        sql = "INSERT INTO Customer(name, email, phoneNumber) VALUES (@Name, @Email, @PhoneNumber);SELECT SCOPE_IDENTITY();";
        int customerId = connection.QuerySingle<int>(sql, _customer);
        return customerId;
    }

    public void AddReservation(DateTime checkIn, DateTime checkOut, int totalCost, int customerId, int roomId)
    {
        OpenDBConnection();
        connection.Execute($"INSERT INTO Reservation(checkIn, checkOut, totalCost, customerId, roomId) VALUES('{checkIn}', '{checkOut}', {totalCost}, {customerId}, {roomId})");
    }

    public void UpdateRoomInfo(int roomNumber, string type, int price)
    {
        OpenDBConnection();
        connection.Execute($"UPDATE Room SET type = '{type}', price = {price} WHERE roomNumber = {roomNumber};");
    }
 */


