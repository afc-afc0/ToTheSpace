using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour , IDragHandler , IEndDragHandler
{
    private Vector3 panelPosition;

    void Start()
    {
        panelPosition = transform.position;
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("OnDrag");
        float difference = data.pressPosition.x - data.position.x;
        Debug.Log(difference);
        transform.position = panelPosition - new Vector3(difference,0f,0f);
    }

    public void OnEndDrag(PointerEventData data)
    {
        panelPosition = transform.position;
    }


}
