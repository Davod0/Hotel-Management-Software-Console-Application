namespace HotelManagementSoftware;



internal class Program
{
    private static void Main(string[] args)
    {

        DBContext newDB = new DBContext();
        HotelCatalogue k = new HotelCatalogue(newDB);


        // foreach (ISearchable x in k.GeAllDataFromHotel())
        // {
        //     if (x is Room r)
        //     {
        //         Console.WriteLine(r);
        //     }
        //     if (x is Customer c)
        //     {
        //         Console.WriteLine(c);
        //     }
        //     if (x is Reservation reservation)
        //     {
        //         Console.WriteLine(reservation);
        //     }
        // }



        foreach (ISearchable x in k.Search(103))
        {
            Console.WriteLine(x);
        }






        // Reservation res = new();
        // res.CheckIn = new DateTime(2023, 11, 10);
        // res.CheckOut = new DateTime(2023, 11, 30);
        // res.CustomerId = 1;
        // res.RoomId = 1;
        // res.TotalCost = 6000;


        // int bbbb = k.AddDataToHotel(res);

        // Console.WriteLine("___________________\n");
        // Console.WriteLine(bbbb);


        // int resId = newDB.AddData(res);

        // Console.WriteLine("___________________\n");
        // Console.WriteLine(resId);




    }
}
