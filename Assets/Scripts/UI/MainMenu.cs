using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string LevelSelectSceneName = "LevelSelect";
    private string GarageSceneName = "Garage";

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(LevelSelectSceneName);
    }

    public void LoadGarageScene()
    {
        SceneManager.LoadScene(GarageSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
