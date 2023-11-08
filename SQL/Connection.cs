namespace HotelManagementSoftware;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;




public class DBContext
{
    private static IDbConnection connection = new SqlConnection("Server=localhost,1433;User=sa;Password=apA123!#!;Database=HotellManagementSoftware;");
    public static string sql;


    public static IEnumerable<Room> GetRooms()  // Denna metod ska användas/anropas i klassen HotelService som ska ligga i BackendLogic mappen för att sedan hantera data som hämtas från databasen.
    {
        sql = "SELECT id, roomNumber, type, price FROM Room;";
        IEnumerable<Room> rooms = connection.Query<Room>(sql);
        return rooms;
    }

    public static IEnumerable<Customer> GetCustomers()
    {
        sql = "SELECT id, name, email, phoneNumber FROM customer;";
        IEnumerable<Customer> customers = connection.Query<Customer>(sql);
        return customers;
    }


}




public class Room
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class Reservation
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int TotalCost { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }
}



