using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Garage : MonoBehaviour
{
    [SerializeField]private string shipName;
    [SerializeField]private SpaceShipData spaceShipData;
    [SerializeField] private ButtonControl buttonControl;


    [Header("SHIP PRICE")]
    public int shipPrice;

    [Header("SPACESHİP DATA")]
    [SerializeField]private TextMeshProUGUI currentDamage;
    [SerializeField]private TextMeshProUGUI currentFireRate;
    [SerializeField]private TextMeshProUGUI currentHealth;
    [SerializeField]private TextMeshProUGUI currentShield;
    [SerializeField]private TextMeshProUGUI upgradeDamageText;
    [SerializeField]private TextMeshProUGUI upgradeHealthText;
    [SerializeField]private TextMeshProUGUI upgradeFireRateText;
    [SerializeField]private TextMeshProUGUI upgradeShieldText;


    [Header("ADD")]
    public int AddDamage = 1;
    public float AddFireRate = -0.02f;
    public int AddHealth = 10;
    public int addShield = 1;

    [Header("UPGRADE MULTİPLİER")]
    [SerializeField] private int damageMultiplier;
    [SerializeField] private int healthMultiplier;
    [SerializeField] private int fireRateMultiplier;
    [SerializeField] private int defensMultiplier;

    private int upgradeDamageAmount = 100;
    private int upgradeFireRateAmount = 100;
    private int upgradaHealthAmount = 100;
    private int upgradeShieldAmount = 100;

    [Header("BASE UPGRADE AMOUNT")]
    [SerializeField]private int baseDamageUpgradeAmount;
    [SerializeField]private int baseHealthUpgradeAmount;
    [SerializeField]private int baseFireRateUpgradeAmount;
    [SerializeField]private int baseShieldUpgradeAmount;

    [Header("BUY AND SELECT BUTTON")]
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject selectButton;
    [SerializeField] private Transform buttonPosition;

    void Start()
    {
        spaceShipData = DataManager.Instance.GetShipByName(shipName);
        if (shipName == null)
            Debug.LogError("ship name is null");
        if (buttonControl == null)
            Debug.LogError("Button control not initiliazed");
        if (shipName == null)
            Debug.LogError("ship name is null");


        SetAmounts();
        SetAmountTexts(); 
        GetSpaceShipStates();
        UpdateButtons();
        SetBuyOrSelectButton();
    }   

    void UpdateButtons()
    {
        buttonControl.UpdateSpaceShipButtons();
    }


    void SetAmounts()
    {
        upgradeDamageAmount = baseDamageUpgradeAmount + (spaceShipData.damage - 10) * damageMultiplier;
        upgradaHealthAmount = baseHealthUpgradeAmount + ((spaceShipData.health - 100) / 10) * healthMultiplier;
        upgradeFireRateAmount = baseFireRateUpgradeAmount + (int)(-(spaceShipData.fireRate - 0.66f) / 0.02f) * fireRateMultiplier;
        upgradeShieldAmount = baseShieldUpgradeAmount + (spaceShipData.defense) * defensMultiplier;
    }


    void SetAmountTexts()
    {
        upgradeDamageText.text = upgradeDamageAmount.ToString();
        upgradeFireRateText.text = upgradeFireRateAmount.ToString();
        upgradeHealthText.text = upgradaHealthAmount.ToString();
        upgradeShieldText.text = upgradeShieldAmount.ToString();
    }

    public void GetSpaceShipStates()
    {
        currentDamage.text =  spaceShipData.damage.ToString();
        currentHealth.text = spaceShipData.health.ToString();
        currentFireRate.SetText(string.Format("{0:0.00}", spaceShipData.fireRate) + "s");
        currentShield.text = spaceShipData.defense.ToString(); 
    }

    public void UpgradeDamageSpaceShip()
    {
        if(DataManager.Instance.userData.playerData.gold >= upgradeDamageAmount)
        {
            spaceShipData.AddDamage(1);
            DataManager.Instance.userData.playerData.gold -= upgradeDamageAmount;
            DataManager.Instance.SaveUserData();
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    public void UpgradeHealthSpaceShip()
    {
        if (DataManager.Instance.userData.playerData.gold >= upgradaHealthAmount)
        {
            spaceShipData.AddHealth(10);
            DataManager.Instance.userData.playerData.gold -= upgradaHealthAmount;
            DataManager.Instance.SaveUserData();
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    public void UpgradeFireRateSpaceShip()
    {

        if (DataManager.Instance.userData.playerData.gold >= upgradeFireRateAmount && spaceShipData.fireRate > 0.2f)
        {
            spaceShipData.AddFireRate(0.04f);
            DataManager.Instance.userData.playerData.gold -= upgradeFireRateAmount;
            DataManager.Instance.SaveUserData();
            UpdateUI();
        }
        else
        {
            return;
        }
    }

    public void UpgradeShield()
    {
        if (DataManager.Instance.userData.playerData.gold >= upgradeShieldAmount && spaceShipData.defense < 8)
        {
            spaceShipData.AddDefense(1);
            DataManager.Instance.userData.playerData.gold -= upgradeShieldAmount;
            DataManager.Instance.SaveUserData();
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    public void SetBuyOrSelectButton()
    {
        if (spaceShipData.isBought == true)
        {
            selectButton = Instantiate(selectButton,buttonPosition);
        }
        else
        {
            buyButton = Instantiate(buyButton,buttonPosition);
        }
    }

    public void BuyButtonClicked()
    {
        Destroy(buyButton);
        selectButton = Instantiate(selectButton,buttonPosition);
        UpdateButtons();
    }

    private void UpdateUI()
    {
        SetAmounts();
        SetAmountTexts();
        GetSpaceShipStates();
        GarageUI.Instance.UpdateUI();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public string GetShipName()
    {
        return shipName;
    }

    public SpaceShipData GetShipData()
    {
        return spaceShipData;
    }

}
