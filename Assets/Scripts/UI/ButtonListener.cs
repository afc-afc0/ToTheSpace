using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    Button button;

    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => LevelSelect.Instance.LoadLevel(gameObject.name));
    }

}
