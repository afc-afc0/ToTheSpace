using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GarageUI : MonoBehaviour
{
    #region Singleton
    private static GarageUI instance;
    public static GarageUI Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField] private TextMeshProUGUI goldUI;
    [SerializeField] private TextMeshProUGUI diamondUI;




   

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();

    }

    public void UpdateUI()
    {
        goldUI.text = DataManager.Instance.userData.playerData.gold.ToString();
        diamondUI.text = DataManager.Instance.userData.playerData.diamond.ToString();
    }

}
