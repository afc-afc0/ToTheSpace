[System.Serializable]
public class ShipControlData 
{
    public string currentShipName;
    public int shipCount;//different kind of spaceships
    
    public ShipControlData()
    {
        currentShipName = "NormalShip";
        shipCount = 1;//how many ship does we have
    }

    public void SetCurrentShipName(string name)
    {
        currentShipName = name;
    }

    public void SetShipCount(int num)
    {
        shipCount = num;
    }

}
