namespace HotelManagementSoftware;



internal class Program
{
    private static void Main(string[] args)
    {
        // foreach (Room x in DBContext.GetRooms())
        // {
        //     Console.WriteLine($"Rum id: {x.Id} , Rum pris: {x.Price} , Rum typ {x.Type}");
        // }

        // foreach (Customer c in DBContext.GetCustomers())
        // {
        //     Console.WriteLine($"Namn: {c.Name} , telefon: {c.PhoneNumber} , email: {c.Email}");
        // }


        // DBContext.AddReservation(new DateTime(2023, 10, 1), new DateTime(2023, 11, 10), 3000, 1, 2);


        // foreach (Reservation r in DBContext.GetReservations())
        // {
        //     Console.WriteLine($"kund id : {r.Id} , pris: {r.TotalCost} , start tid: {r.CheckOut}");
        // }

        DBContext newDB = new DBContext();

        HotelCatalogue k = new HotelCatalogue(newDB);
        k.








    }
}
