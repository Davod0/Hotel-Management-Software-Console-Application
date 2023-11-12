namespace HotelManagementSoftware;



internal class Program
{
    private static void Main(string[] args)
    {
        DBContext newDB = new DBContext();

        HotelCatalogue k = new HotelCatalogue(newDB);




        foreach (ISearchable x in k.GetAllData())
        {
            if (x is Room r)
            {
                Console.WriteLine($"rum id: {r.Id}, Rum nummmer: {r.Price}, rum typ {r.Type}");
            }
            if (x is Customer c)
            {
                Console.WriteLine($"kund id: {c.Id}, kund namn: {c.Name}, kund telefon: {c.PhoneNumber} ");
            }
            if (x is Reservation res)
            {
                Console.WriteLine($"Reservation id: {res.Id}, total kostand för reservation: {res.TotalCost}, check out datum: {res.CheckOut} ");
            }
        }



        // Customer k = new();
        // k.Name = "Alex Fergosson";
        // k.Email = "alexfergosson@gmail.com";
        // k.PhoneNumber = "07655332211";

        // int s = newDB.AddCustomer(k);

        // Console.WriteLine("___________________\n");
        // Console.WriteLine(s);


    }
}
