using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuyButton : MonoBehaviour
{
    private int shipPrice;
    [SerializeField]private TextMeshProUGUI text;
    private Garage garage;

    private void Start()
    {
        garage = GetComponentInParent<Garage>();
        shipPrice = garage.shipPrice;
        SetShipPriceText();
        AddListenerToButton();
    }

    private void AddListenerToButton()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => BuyButtonClicked());
    }

    private void SetShipPriceText()
    {
        text.text = shipPrice.ToString();
    }

    public void BuyButtonClicked()
    {
        if(DataManager.Instance.BuyShip(garage.GetShipData()) == true)
        {
            garage.BuyButtonClicked();       
        }
    }
}
