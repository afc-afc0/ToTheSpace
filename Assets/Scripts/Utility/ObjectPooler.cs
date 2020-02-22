using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{
    public GameObject poolObject;
    public int amountToPool;
    public bool isExpending;
    public string tagOfObject;

    public PooledObject(GameObject prefab,int amount,bool expending)
    {
        poolObject = prefab;
        tagOfObject = prefab.gameObject.tag;
        amountToPool = amount;
        isExpending = expending;
    }
};

public class ObjectPooler : MonoBehaviour
{

    private static ObjectPooler instance;

    public static ObjectPooler Instance
    {
        get
        {
            return instance;
        }
    }

    public List<PooledObject> itemsToPool;
    [SerializeField]Dictionary<string, List<GameObject>> pooledObjects; 

    void Awake()
    {
        instance = this;
        pooledObjects = new Dictionary<string , List<GameObject> >();
        PoolObjects();
    }

    private void Start()
    {
        
    }

    public GameObject GetPoolObject(string tag)
    {
        List<GameObject> Objects;
        Objects = pooledObjects[tag];

        if(Objects == null)
        {
            Debug.LogWarning("Cant find tag in dictionary : " + tag);
            return null;
        }


        for (int i = 0; i < Objects.Count; i++)
        {
            if (Objects[i].activeInHierarchy == false)
            {
                return Objects[i];
            }
        }

        for(int i = 0;i < itemsToPool.Count; i++)//if isExpending == true
        {
            if(itemsToPool[i].tagOfObject == tag && itemsToPool[i].isExpending == true)
            {
                GameObject obj = Instantiate(itemsToPool[i].poolObject);
                Objects.Add(obj);
                obj.gameObject.SetActive(false);
                return obj;
            }
        }



        return null;
    }

    public void AddPoolObject(GameObject prefab,int number,bool isExpanding)
    {

        if(prefab == null)
        {
            Debug.LogError("Prefab object was empty !!!!!" , prefab);
        }

        PooledObject obj = new PooledObject(prefab,number,isExpanding);
        itemsToPool.Add(obj);
        List<GameObject> objects = new List<GameObject>();

        for(int i = 0;i < number;i++)
        {
            GameObject poolObject = Instantiate(prefab);
            poolObject.SetActive(false);
            objects.Add(poolObject);
        }
        pooledObjects.Add(prefab.tag, objects);
    }

    private void PoolObjects()
    {
        foreach (PooledObject item in itemsToPool)
        {
            List<GameObject> Objects = new List<GameObject>();

            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = Instantiate(item.poolObject);
                obj.SetActive(false);
                Objects.Add(obj);
            }

            pooledObjects.Add(item.tagOfObject, Objects);

        }
    }

}
