using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Header("TEXT")]
    [SerializeField]private TextMeshProUGUI goldText;
    [SerializeField]private TextMeshProUGUI diamondText;

    [Header("UI")]
    [SerializeField]private GameObject levelWinCanvas;
    [SerializeField]private GameObject levelLoseCanvas;
    
    void Start()
    {
        UpdateTexts();
        Events();
    }

    private void Events()
    {
        LevelControl.levelEnd += LevelEnded;
    }

    public void UpdateTexts()
    {
        goldText.text = DataManager.Instance.userData.playerData.gold.ToString();
        diamondText.text = DataManager.Instance.userData.playerData.diamond.ToString();
    }

    public void LevelEnded(bool isSuccesful)
    {
        if(isSuccesful)
        {
            Instantiate(levelWinCanvas);
        }   
        else
        {
            Instantiate(levelLoseCanvas);
        }
        LevelControl.levelEnd -= LevelEnded;
    }
}
