using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    #region SINGLETON   
    private static TowerControl instance;

    public static TowerControl Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField] private UI uı;
    public int currentTowerCount;
    private string TurretTag;
    
    private void Awake()
    {
        instance = this;
        TurretTag = "Turret";
    }

    private void Start()
    {
        currentTowerCount = GameObject.FindGameObjectsWithTag(TurretTag).Length;
    }

    public void OnTowerDestroy(int turretGold, int turretDiamond)
    {
        currentTowerCount--;
        DataManager.Instance.OnTurretDestroy(turretGold,turretDiamond);
        uı.UpdateTexts();
        if (currentTowerCount != 0)
        {
            AudioManager.Instance.Play("GoldSound");
        }
        else
        {
            LevelControl.Instance.LevelSuccesful();
        }
    }

    private void LevelEnd(bool isSuccessful)
    {
        GameObject[] turret = GameObject.FindGameObjectsWithTag("Turret");
        
        for(int i = 0;i < turret.Length;i++)
        {
            turret[i].gameObject.SetActive(false);
        }
    }


}
