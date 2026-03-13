using UnityEngine;

public class TankMobileFireAdapter : MonoBehaviour
{
    private TankShooting shooting;

    private bool mobileHeld;

    void Awake()
    {
        shooting = GetComponent<TankShooting>();
    }

    void Update()
    {
        if (mobileHeld)
        {
            shooting.SendMessage("MobileButtonDown", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnFireButtonDown()
    {
        mobileHeld = true;
        shooting.MobileButtonDown();
    }

    public void OnFireButtonUp()
    {
        mobileHeld = false;
        shooting.MobileButtonUp();
    }
}