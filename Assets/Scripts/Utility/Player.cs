using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region SINGLETON   
    private static Player instance;

    public static Player Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField] private UI levelUI;
    private int gold;
    private int diamond;

    #region PROPERTIES
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public int Diamond
    {
        get { return diamond; }
        set { diamond = value; }
    }
    #endregion



    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetValues();//get gold and diamond values from data
        
    }

    private void GetValues()
    {
        gold = DataManager.Instance.userData.playerData.gold;
        diamond = DataManager.Instance.userData.playerData.diamond;
    }

    public void TurretDestroy(int _gold,int _diamond)
    {
        gold += gold;
        diamond += diamond;
        levelUI.UpdateTexts();
    }

    public void OnLevelEnd()
    {
        Debug.Log("Player On Level End");
        
    }

    private void SetDataManagerValues()
    {
        
    }

    public void LevelEndedSuccesfully()
    {
        Debug.Log("level up fonksiyonu çalışmıyor level a toplu çözüm gerek!!!!!");
    }

}
