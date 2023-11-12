namespace HotelManagementSoftware;


using System.Data;
using System.Data.SqlClient;
using Dapper;


public class DBContext : ISQLRepository
{
    private static IDbConnection connection = new SqlConnection("Server=localhost,1433;User=sa;Password=apA123!#!;Database=HotellManagementSoftware;");
    public static string sql;


    // En metod som kontrollerar om connection med databasen är öppet annars öppnar denna metod kontakten med databasen geonm funktionen open().
    public void OpenDBConnection()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    public IEnumerable<ISearchable> GetRooms()
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


    //_________________________________________________________________________________________________



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


        }
        if (x is Reservation _reservation)
        {

        }
        return 0;
    }


}



