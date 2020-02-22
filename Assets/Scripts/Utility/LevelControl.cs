using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    #region SINGLETON

    private static LevelControl instance;

    public static LevelControl Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    public delegate void LevelEnded(bool isSuccessful);
    public static event LevelEnded levelEnd;

    bool isLevelEnded;

    private void Awake()
    {
        instance = this;
    }

    public void LevelSuccesful()
    {
        if (isLevelEnded == false)
        {
            isLevelEnded = true;
            levelEnd(true);
        }
    }

    public void LevelFailed()
    {
        if (isLevelEnded == false)
        {
            isLevelEnded = true;
            levelEnd(false);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

}
