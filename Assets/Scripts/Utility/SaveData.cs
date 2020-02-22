using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;


public static class SaveData
{
    public static string userPath = "/UserData.afc";

    public static void SaveUserData(UserData userData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + userPath;

        FileStream stream = new FileStream(path, FileMode.Create);
    
        formatter.Serialize(stream, userData);
        stream.Close();
    }

    public static UserData LoadUserData()
    {
        string path = Application.persistentDataPath + userPath;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserData userData = formatter.Deserialize(stream) as UserData;

            if(userData == null)
            {
                Debug.Log("user data is null");
            }

            stream.Close();

            return userData;
        }
        else
        {
            Debug.Log("User data creating in the path :" + path);
            SaveUserData(new UserData());
            return LoadUserData();
        }
    }



























    /*
    */

    /*public static void SaveSpaceShip(SpaceShip ship)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/spaceShip.afc";

        FileStream stream = new FileStream(path, FileMode.Create);
        SpaceShipData data = new SpaceShipData(ship);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveSpaceShipData(SpaceShipData data)
    {
        Debug.Log("Saving Spaceship dadta");

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/spaceShip.afc";

        FileStream stream = new FileStream(path,FileMode.Create);

        formatter.Serialize(stream,data);
        stream.Close();
    }

 
    public static SpaceShipData LoadSpaceShip()
    {
        string path = Application.persistentDataPath + "/spaceShip.afc";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SpaceShipData shipData = formatter.Deserialize(stream) as SpaceShipData;
            stream.Close();

            return shipData;
        }
        else
        {
            Debug.Log("Cant Find SpaceShip Data in the path opening new one " + path);
            SaveSpaceShipData(new SpaceShipData());
            return LoadSpaceShip();
        }
    }       
    

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerData.afc";

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SavePlayer(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerData.afc";

        FileStream stream = new FileStream(path , FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/PlayerData.afc";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            PlayerData player = formatter.Deserialize(file) as PlayerData;
            file.Close();

            return player;
        }
        else
        {
            Debug.Log("File doesnt exist loadPlayer");
            SavePlayer(new PlayerData());
            return LoadPlayer();
        }

    }

    public static void SaveLevel(LevelHandleData levelData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/LevelData.afc";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, levelData);
        stream.Close();
    }

    public static LevelHandleData LoadLevel()
    {
        string path = Application.persistentDataPath + "/LevelData.afc";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            LevelHandleData levelHandleData = formatter.Deserialize(file) as LevelHandleData;
            file.Close();

            return levelHandleData;
        }
        else
        {
            Debug.Log("couldnt find data opening level file");
            SaveLevel(new LevelHandleData());
            return LoadLevel();
        }

    }*/

}
