namespace HotelManagementSoftware;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (Room x in DBContext.GetRooms())
        {
            Console.WriteLine($"Rum id: {x.Id} , Rum nummer: {x.Price} , Rum typ {x.Type}");
        }
    }
}
