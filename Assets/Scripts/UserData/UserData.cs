[System.Serializable]
public class UserData 
{
    public ShipControlData shipControlData;
    public ShipDatas shipDatas;
    public PlayerData playerData;
    public LevelHandleData levelData;
    
    public UserData()
    {
        shipControlData = new ShipControlData();
        shipDatas = new ShipDatas();
        playerData = new PlayerData();
        levelData = new LevelHandleData();
    }
}
