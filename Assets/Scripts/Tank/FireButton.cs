using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private TankShooting tank;

    public void SetTank(TankShooting t)
    {
        tank = t;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (tank != null)
        {
            tank.SendMessage("OnFireButtonDown", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (tank != null)
        {
            tank.SendMessage("OnFireButtonUp", SendMessageOptions.DontRequireReceiver);
        }
    }
}