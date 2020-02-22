using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button[] buttons;
    public RectTransform buyOrSelectButtonPosition;
    [SerializeField]private GameObject buyButton;
    [SerializeField]private GameObject selectButton;
    private Garage garage;

    private void Start()
    {
        if(buttons == null)
        {
            Debug.LogError("Buttons is null");
            return;
        }
        garage = GetComponentInParent<Garage>();
    }

    public void UpdateSpaceShipButtons()
    {
        if(GetComponentInParent<Garage>().GetShipData().isBought == false)
        {
            DeactivateButtons();
        }
        else
        {
            ActivateButtons();
        }
    }

    private void DeactivateButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }
    private void ActivateButtons()
    {
        foreach(Button button in buttons)
        {
            button.interactable = true;
        }
    }
}
