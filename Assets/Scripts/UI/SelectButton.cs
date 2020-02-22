using UnityEngine;
using UnityEngine.UI;
public class SelectButton : MonoBehaviour
{
    private string shipName;
    private Button button;
    private Garage garage;

    private void Start()
    {
        button = GetComponent<Button>();
        garage = GetComponentInParent<Garage>();
        shipName = garage.GetShipName();
        AddListenerToButton();
    }

    public void SelectButtonClicked()
    {
        DataManager.Instance.SetCurrentShip(shipName);
    }

    private void AddListenerToButton()
    {
        button.onClick.AddListener(() => SelectButtonClicked());
    }

}
