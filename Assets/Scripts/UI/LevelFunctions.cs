using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelFunctions : MonoBehaviour
{

    private string garageName = "Garage";

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadGarage()
    {
        SceneManager.LoadScene(garageName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
