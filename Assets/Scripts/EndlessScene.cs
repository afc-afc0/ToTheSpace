using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScene : MonoBehaviour
{
    #region Singleton

    private static EndlessScene instance;

    public static EndlessScene Instance
    {
        get
        {
            return instance;
        }
    }

    #endregion

    #region Tower Names
    private string basicTurret = "BasicTurret";
    private string laserTurret = "LaserTurret";
    private string missileTurret = "MissileTurret";
    private string beeTurret = "BeeTurret";
    private string iceTurret = "IceTurret";
    private string tripleFireTurret = "TripleFireTurret";
    private string boltTurret = "BoltTurret";
    private string canonTurret = "CanonTurret";
    private string sniperTurret = "SniperTurret";
    #endregion

    public List<BuildPosition> buildPositions;
    private string positionTag = "TurretPosition";

    private int currentBaseDamage;//damage and health will increase depending on time
    private int currentBaseHealth;//
    private int buildTimer;
    private int positionSize;
    private int timer;
    private BuildPosition buildPosition;

    #region TOWER CONTROL
    [Header("TOWER CONTROL")]
    private float towerCountIncreaseTimer;
    private int baseTowerCount;//tower count will increase depending on time ()
    private int currentTowerCount;
    #endregion

    private void Awake()
    {
        instance = this;
        buildPositions = new List<BuildPosition>();
    }

    private void Start()
    {
        buildTimer = 12;
        baseTowerCount = 5;
        timer = 12;
        currentBaseDamage = 12;
        currentBaseHealth = 100;
        INITPositions();
        InvokeRepeating("TowerControl", 0f,12f);
        InvokeRepeating("IncreaseTurretCount", 12f, 12f);
    }

    private void INITPositions()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(positionTag);

        for(int i = 0; i < objects.Length;i++)
        {
            buildPositions.Add(new BuildPosition());
        }

        for(int i = 0;i < objects.Length;i++)
        {
            buildPositions[i].position = objects[i].transform.position;
            buildPositions[i].isBuilded = false;
        }

        positionSize = buildPositions.Count;//position size changed so we update the positionsize
    }

    private void IncreaseTurretCount()
    {
        Debug.Log("increaseing base tower count");
        baseTowerCount++; 
    }

    private void TowerControl()//yapılanları yaz 
    {
        Debug.Log("tower Control Base Tower Count : " + baseTowerCount);
        Debug.Log("current Tower count : " + currentTowerCount);

        int turretCount = currentTowerCount;
        for(int i = 0; i < baseTowerCount - turretCount;i++)
        {
            BuildTower();
            Debug.Log("instantiating turret");
        }
        
    }

    private void BuildTower()
    {
        GameObject turret = GetTower();
        TurretBase turretBase = turret.GetComponent<TurretBase>();
        turretBase.SetHealth(GetTurretHealth()); 
        //turretBase.SetDamage(GetTurretDamage());
        Debug.Log("Uncomment olcak yer");
        //turretBase.SetFireRate(GetTurretFireRate(turretBase.GetFireRate())); uncomment olcak
        turret.transform.position = GetTurretPosition().position;
        turret.SetActive(true);
        currentTowerCount++;
    }

    private int GetTurretHealth()
    {
        return currentBaseHealth + (int)(Time.timeSinceLevelLoad / timer);//increase health eve (int) seconds
    }

    private int GetTurretDamage()
    {
        return currentBaseDamage + (int)(Time.timeSinceLevelLoad / timer);//increase damage every (int) seconds
    }

    private float GetTurretFireRate(float _fireRate)
    {
        if(_fireRate > 0.7f)
        {
            return _fireRate - (int)(Time.timeSinceLevelLoad / timer) * 0.005f;
        }
        else if (_fireRate > 0.5f)
        {
            return _fireRate - (int)(Time.timeSinceLevelLoad / timer) * 0.004f;
        }
        else if(_fireRate > 0.3f)
        {
            return _fireRate - (int)(Time.timeSinceLevelLoad / timer) * 0.002f;
        }
        else
        {
            return _fireRate - (int)(Time.timeSinceLevelLoad / timer) * 0.001f;
        }
    }
    
    private GameObject GetTower()
    {
        float num = Random.Range(0,90f);
        if(num < 10f)
        {
            return ObjectPooler.Instance.GetPoolObject(basicTurret);
        }
        else if(num < 20f)
        {
            return ObjectPooler.Instance.GetPoolObject(canonTurret);
        }
        else if(num < 30f)
        {
            return ObjectPooler.Instance.GetPoolObject(sniperTurret);
        }
        else if(num < 40f)
        {
            return ObjectPooler.Instance.GetPoolObject(laserTurret);
        }
        else if(num < 50f)
        {
            return ObjectPooler.Instance.GetPoolObject(boltTurret);
        }
        else if(num < 60f)
        {
            return ObjectPooler.Instance.GetPoolObject(beeTurret);
        }
        else if(num < 70f)
        {
            return ObjectPooler.Instance.GetPoolObject(tripleFireTurret);
        }
        else if(num < 80f)
        {
            return ObjectPooler.Instance.GetPoolObject(missileTurret);
        }
        else if(num <= 90f)
        {
            return ObjectPooler.Instance.GetPoolObject(iceTurret);
        }
        else
        {
            Debug.LogError("Not in valid range");
            return null;
        }
    }

    private BuildPosition GetTurretPosition()
    {
        buildPosition = buildPositions[(int)(Random.Range(0f, positionSize - 0.01f))];
        while (buildPosition.isBuilded == true)
        {
            buildPosition = buildPositions[(int)(Random.Range(0f, positionSize - 0.01f))];
        }
        return buildPosition;
    }

    public void OnTurretDestroy()
    {
        currentTowerCount--;
        Debug.Log("current tower count : " + currentTowerCount);
        if (currentTowerCount == 1)
        {
            currentBaseDamage += 20;
            currentBaseHealth += 20;
            TowerControl();
        }
    }


}


public class BuildPosition
{
    public bool isBuilded;
    public Vector2 position;

    public BuildPosition()
    {
        position = new Vector2(0f,0f);
        isBuilded = false;
    }
}
