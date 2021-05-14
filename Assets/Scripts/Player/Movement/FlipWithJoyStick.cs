using UnityEngine;

public class FlipWithJoyStick : MonoBehaviour
{
    public Joystick aimmingJoyStick;
    [HideInInspector]
    public bool isLocked = false;
    bool isFlipped = false;
    void Update()
    {
        if (isLocked)
            return;

        if (aimmingJoyStick.Direction.x > 0 && isFlipped == true)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            isFlipped = false;
        }
        else if (aimmingJoyStick.Direction.x < 0 && isFlipped == false)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
            isFlipped = true;
        }
    }
   
}
