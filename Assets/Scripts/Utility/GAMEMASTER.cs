using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEMASTER : MonoBehaviour
{
    #region Singleton
    private static GAMEMASTER instance;
    public static GAMEMASTER Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField] private UI levelUI;

    private int currentTowerCount;
    private string turretTag = "Turret";
    
    private void Awake()
    {
        instance = this;
        InstantiateCurrentSpaceShip();
    }

    public void InstantiateCurrentSpaceShip()
    {
        
    }

    void Start()
    {
        currentTowerCount = GameObject.FindGameObjectsWithTag(turretTag).Length;
    }

}
