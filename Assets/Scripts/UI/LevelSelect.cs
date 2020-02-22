using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelect : MonoBehaviour
{
    private static LevelSelect instance;

    public static LevelSelect Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]GameObject[] buttons;

    private int currentLevel;

    private string buttonTag = "LevelSelectButtons";

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentLevel = DataManager.Instance.userData.levelData.reachedLevel;
        INITButtonArray();
        DisableColliders();
    }

    public void LoadLevel(string name)
    {
       SceneManager.LoadScene(name);   
    }

    private void INITButtonArray()
    {
        Debug.Log(buttons.Length);
        for(int i = 0;i < buttons.Length;i++)
        {
            buttons[i] = GameObject.Find("Level" + (i + 1).ToString());
        }
    }

    void DisableColliders()
    { 
        for(int i = currentLevel;i < buttons.Length;i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }    
}
