
using System.Runtime.CompilerServices;

namespace HotelManagementSoftware;



internal class Program
{
    private static void Main(string[] args)
    {

        // UI ui = new(k);

        DBContext newDB = new DBContext();
        HotelCatalogue k = new HotelCatalogue(newDB);

        UI ui = new UI(k);


        // Room rrmm = new Room();
        // rrmm.Id = 2003;

        // int vvv = ui.DeleteDataFromLogic(rrmm);

        foreach (HotelItem xxx in ui.GetAllDataFromLogic())
        {
            Console.WriteLine(xxx);
        }




        // Console.WriteLine("______________________________________________________");
        // Console.WriteLine(vvv);






        //Test kod för metoden GetAvailableRoom()
        // DateTime ress = new DateTime(2023, 12, 01);

        // foreach (Room qq in newDB.GetAvailableRoom(ress))
        // {
        //     Console.WriteLine(qq);
        // }






        // Room rm = new Room();
        // rm.Id = 300;
        // // rm.RoomNumber = 101;
        // // rm.Price = 200;
        // // rm.Type = "Single";


        // int sss = k.DeleteDataFromHotel(rm);

        // foreach (HotelItem x in k.GetAllDataFromHotel())
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



        // Console.WriteLine("______________________________________________________");
        // Console.WriteLine(sss);








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
