
namespace HotelManagementSoftware;


public class HotelCatalogue : IUserInterface
{
    ISQLRepository sqlRepository;
    public HotelCatalogue(ISQLRepository _sqlRepository)
    {
        sqlRepository = _sqlRepository;
    }

    public List<HotelItem> GetAllDataFromHotel()
    {
        return sqlRepository.GetData().ToList();
    }

    public int AddDataToHotel(HotelItem x)
    {
        int id = sqlRepository.AddData(x);
        return id;
    }

    public int UpdateHotelData(HotelItem x)
    {
        return sqlRepository.UpdateData(x);
    }

    public int DeleteDataFromHotel(HotelItem x)
    {
        return sqlRepository.DeleteData(x);
    }

    public List<HotelItem> GetAvailableRoomFRomHotel(DateTime checkIn)
    {
        return sqlRepository.GetAvailableRoom(checkIn).ToList();
    }

    public List<HotelItem> SearchHotelItem(string stringValue)
    {
        List<HotelItem> foundData = new();
        foreach (HotelItem item in sqlRepository.GetData())
        {
            if (item.MyContains(stringValue)) foundData.Add(item);
        }
        return foundData;
    }

    public List<HotelItem> SearchHotelItem(int intValue)
    {
        List<HotelItem> foundData = new();
        foreach (HotelItem item in sqlRepository.GetData())
        {
            if (item.MyContains(intValue)) foundData.Add(item);
        }
        return foundData;
    }








    // Metoder från IUserInterface implementeras här
    public List<HotelItem> Get()
    {
        return GetAllDataFromHotel();
    }
    public int Add(HotelItem x)
    {
        return AddDataToHotel(x);
    }
    public int Update(HotelItem x)
    {
        return UpdateHotelData(x);
    }
    public int Delete(HotelItem x)
    {
        return DeleteDataFromHotel(x);
    }
    public List<HotelItem> GetAvailable(DateTime checkIn)
    {
        return GetAvailableRoomFRomHotel(checkIn);
    }
    public List<HotelItem> Search(string stringValue)
    {
        return SearchHotelItem(stringValue);
    }
    public List<HotelItem> Search(int intValue)
    {
        return SearchHotelItem(intValue);
    }




}

















public interface ISQLRepository
{
    IEnumerable<HotelItem> GetData();
    int AddData(HotelItem x);
    int UpdateData(HotelItem x);
    int DeleteData(HotelItem x);
    public IEnumerable<HotelItem> GetAvailableRoom(DateTime checkIn);
}








public interface ISearchable
{
    bool MyContains(int value);
    bool MyContains(string value);
}

public abstract class HotelItem : ISearchable
{
    public abstract bool MyContains(int value);
    public abstract bool MyContains(string value);

    public abstract override string ToString();
}










public class Room : HotelItem
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }


    // DENNA Konstruktor SKA FIXAS EFTERSOM NÄR VI HÄMTAR DATTA FRÅN DATABASEN DÅ FUNKAR DET INTR OM Konstruktor FINNS I KLASSEN!
    // Konstruktor 
    // public Room(int _roomNumber, string _type, int _price)
    // {
    //     RoomNumber = _roomNumber;
    //     Type = _type;
    //     Price = _price;
    // }
    // public Room(int _id, int _roomNumber, string _type, int _price) : this(_roomNumber, _type, _price)
    // {
    //     Id = _id;
    // }


    public override bool MyContains(int roomNumber)
    {
        if (RoomNumber.Equals(roomNumber))
        {
            return true;
        }
        return false;
    }

    public override bool MyContains(string typeOfRoom)
    {
        if (Type.Contains(typeOfRoom, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }


    public override string ToString()
    {
        return $"Rum id: {Id}, rum nummer: {RoomNumber}, rum typ: {Type}, rum pris: {Price}.";
    }
}


public class Reservation : HotelItem
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int TotalCost { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }


    //DENNA Konstruktor SKA FIXAS EFTERSOM NÄR VI HÄMTAR DATTA FRÅN DATABASEN DÅ FUNKAR DET INTR OM Konstruktor FINNS I KLASSEN!
    // Konstruktor
    // public Reservation(DateTime _checkIn, DateTime _checkOut, int _totalCost, int _customerId, int _roomId)
    // {
    //     CheckIn = _checkIn;
    //     CheckOut = _checkOut;
    //     TotalCost = _totalCost;
    //     CustomerId = _customerId;
    //     RoomId = _roomId;
    // }


    // Metod från ISearchable interfacet
    public override bool MyContains(int customerId)
    {
        if (CustomerId.Equals(customerId))
        {
            return true;
        }
        return false;
    }

    // En överlagring av metoden MyContains som tar emot reservationId i string form för att ge möjligheten att kunna hitta på reservationer genom id
    public override bool MyContains(string reservationId)
    {
        if (!int.TryParse(reservationId, out int result))
        {
            return false;
        }

        if (Id.Equals(result))
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Bokning id: {Id}, inchecknings datum: {CheckIn}, utchecknings datum: {CheckOut}, total kostnad {TotalCost}, kund id: {CustomerId}, rum id: {RoomId}.";
    }

}


public class Customer : HotelItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    //DENNA Konstruktor SKA FIXAS EFTERSOM NÄR VI HÄMTAR DATTA FRÅN DATABASEN DÅ FUNKAR DET INTR OM Konstruktor FINNS I KLASSEN!
    // Konstruktor
    // public Customer(string _name, string _email, string _phoneNumber)
    // {
    //     Name = _name;
    //     Email = _email;
    //     PhoneNumber = _phoneNumber;
    // }


    // Metod från ISearchable interfacet
    public override bool MyContains(int customerId)
    {
        if (Id.Equals(customerId))
        {
            return true;
        }
        return false;
    }

    // En  överlagring  av metoden MyContains som ger möjlighet att kunna hitta kunder även genom deras namn
    public override bool MyContains(string customerName)
    {
        if (Name.Contains(customerName, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"kund id: {Id}, kund namn: {Name}, kund email: {Email}, kund telefon nummer: {PhoneNumber}.";
    }

}

