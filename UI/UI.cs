
namespace HotelManagementSoftware;

public class UI
{

    IUserInterface iUserInterface;

    public UI(IUserInterface _iUserInterface)
    {
        iUserInterface = _iUserInterface;
    }

    public List<HotelItem> GetAllDataFromLogic()
    {
        return iUserInterface.Get();
    }
    public int AddDataToLogic(HotelItem x)
    {
        return iUserInterface.Add(x);
    }
    public int UpdateLogicData(HotelItem x)
    {
        return iUserInterface.Update(x);
    }
    public int DeleteDataFromLogic(HotelItem x)
    {
        return iUserInterface.Delete(x);
    }
    public List<HotelItem> GetAvailableRoomFromLogic(DateTime x)
    {
        return iUserInterface.GetAvailable(x);
    }

    public List<HotelItem> SearchItem(string stringValue)
    {
        return iUserInterface.Search(stringValue);
    }
    public List<HotelItem> SearchItem(int intValue)
    {
        return iUserInterface.Search(intValue);
    }

}



public interface IUserInterface
{
    List<HotelItem> Get();
    int Add(HotelItem x);
    int Update(HotelItem x);
    int Delete(HotelItem x);
    List<HotelItem> GetAvailable(DateTime checkIn);
    List<HotelItem> Search(int intValue);
    List<HotelItem> Search(string stringValue);

}