using UnityEngine.SceneManagement;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    #region Singleton
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion 


    [SerializeField] private bool instantiateShip;
    public UserData userData;
    public SpaceShipData currentShipData;

    [Header("SHIP NAMES")]
    private int shipCount;
    private readonly string shipUITag = "ShipUI";
    private readonly string normalShipName = "NormalShip";
    private readonly string doubleFireName = "DoubleFire";
    private readonly string tripleFireName = "TripleFire";
    private readonly string missileShipName = "MissileShip";
    private readonly string laserShipName = "LaserShip";

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
        userData = SaveData.LoadUserData();
        currentShipData = GetCurrentShipData();
        InstantiateShip();
    }

    private void Start()
    {
        shipCount = GameObject.FindGameObjectsWithTag(shipUITag).Length;
        Events();
    }

    private void Events()
    {
        LevelControl.levelEnd += LevelEnd;
    }

    public void ChangePlayerData(int gold,int diamond)
    {
        userData.playerData.ChangeGold(gold);
        userData.playerData.ChangeDiamond(diamond);
    }
     
    public SpaceShipData GetShipData()
    {
        return currentShipData;
    }

    public SpaceShipData GetCurrentShipData()
    {
        Debug.Log("Current ship name : " + userData.shipControlData.currentShipName);
        if(userData.shipControlData.currentShipName == userData.shipDatas.normalShip.shipName)
        {
            return userData.shipDatas.normalShip;
        }
        else if(userData.shipControlData.currentShipName == userData.shipDatas.doubleFire.shipName)
        {
            return userData.shipDatas.doubleFire;
        }
        else if(userData.shipControlData.currentShipName == userData.shipDatas.tripleFire.shipName)
        {
            return userData.shipDatas.tripleFire;
        }
        else if(userData.shipControlData.currentShipName == userData.shipDatas.missileShip.shipName)
        {
            return userData.shipDatas.missileShip;
        }
        else if(userData.shipControlData.currentShipName == userData.shipDatas.laserShip.shipName)
        {
            return userData.shipDatas.laserShip;
        }
        else
        {
            Debug.LogError("wrong shipname :" + userData.shipControlData.currentShipName + "returning null");
            return null;
        }
    }

    void InstantiateShip()
    {
        if (instantiateShip == false)
            return;

        if(currentShipData.shipName == normalShipName)
        {
            Instantiate(Resources.Load(normalShipName),new Vector3(0f,-4f,-1f),new Quaternion(0f,0f,0f,0f));
        }
        else if(currentShipData.shipName == doubleFireName)
        {
            Instantiate(Resources.Load(doubleFireName),new Vector3(0f, -4f, -1f), new Quaternion(0f, 0f, 0f, 0f));
        }
        else if(currentShipData.shipName == tripleFireName)
        {
            Instantiate(Resources.Load(tripleFireName), new Vector3(0f, -4f, -1f), new Quaternion(0f, 0f, 0f, 0f));
        }
        else if(currentShipData.shipName == missileShipName)
        {
            Instantiate(Resources.Load(missileShipName), new Vector3(0f, -4f, -1f), new Quaternion(0f, 0f, 0f, 0f));
        }
        else if(currentShipData.shipName == laserShipName)
        {
            Instantiate(Resources.Load(laserShipName), new Vector3(0f, -4f, -1f), new Quaternion(0f,0f,0f,0f));
        }
        else
        {
            Debug.LogError("wrong ship name ship is not instantiating");
        }
    }


    public PlayerData GetPlayerData()
    {
        return userData.playerData;
    }

    public LevelHandleData GetLevelHandleData()
    {
        return userData.levelData;
    }

    public void SaveUserData()
    {
        SaveData.SaveUserData(userData);
    }

    public void SetCurrentShip(string shipName)
    {
        userData.shipControlData.SetCurrentShipName(shipName);
        SaveData.SaveUserData(userData);
    }
    
    public SpaceShipData GetShipByName(string shipName)
    {
        if(shipName == normalShipName)
        {
            return userData.shipDatas.normalShip;
        }
        else if(shipName == doubleFireName)
        {
            return userData.shipDatas.doubleFire;
        }
        else if(shipName == tripleFireName)
        {
            return userData.shipDatas.tripleFire;
        }
        else if(shipName == missileShipName)
        {
            return userData.shipDatas.missileShip;
        }
        else if(shipName == laserShipName)
        {
            return userData.shipDatas.laserShip; 
        }
        else
        {
            Debug.LogError("Wrong ship name!!! : " + shipName);
            return null;
        }
    }

    public bool BuyShip(SpaceShipData shipData)
    {

        if(shipData.shipPrice <= userData.playerData.diamond)
        {
            //buy ship and return true

            userData.playerData.ChangeDiamond(-shipData.shipPrice);
            userData.shipControlData.SetCurrentShipName(shipData.shipName);
            shipData.isBought = true;

            SaveUserData();
            
            return true;
        }
        return false;
    }

    private void LevelEnd(bool isSuccesful)
    {
        
        if (isSuccesful && SceneManager.GetActiveScene().buildIndex == userData.levelData.reachedLevel)
            userData.levelData.reachedLevel++;

        LevelControl.levelEnd -= LevelEnd;
        SaveUserData();
    }

    public void OnTurretDestroy(int gold,int diamond)
    {
        userData.playerData.ChangeGold(gold);
        userData.playerData.ChangeDiamond(diamond);
    }

    private void OnDisable()
    {
        SaveUserData();
    }

}
