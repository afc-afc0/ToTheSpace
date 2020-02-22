using UnityEngine.SceneManagement;
using UnityEngine;

public class SwipeButtons : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;

    [SerializeField] private GameObject swipeObject;
    [SerializeField] private string objectTag;

    private Vector3 difference;
    private int swipeObjectCount;
    private int currentIndex;

    private void Start()
    {
        if(string.IsNullOrEmpty(objectTag))
        {
            Debug.LogError("you have to initilize object tag");
        }

        swipeObjectCount = GameObject.FindGameObjectsWithTag(objectTag).Length;
        currentIndex = 0;
        difference = panel1.transform.position - panel2.transform.position;
    }

    public void SwipeRight()
    {

        if (currentIndex + 1 < swipeObjectCount)
        {
            swipeObject.transform.position += difference;
            currentIndex++;
        }
    }

    public void SwipeLeft()
    {
        if (currentIndex - 1 >= 0)
        {
            swipeObject.transform.position -= difference;
            currentIndex--;
        }
        else if(currentIndex - 1 == -1)
        {
            SceneManager.LoadScene(0);
        }
    }

}
