using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool isPressed = false;
    public Image coolDownOverlay;
    public float coolDownTime;
    public int degreeEachUpdate = 2;
    public bool IsDisabled
    {
        get { return isDisabled; }
        set
        {
            isDisabled = value;
            if (isDisabled)
            {
                coolDownOverlay.fillAmount = 1;
            }
            else
            {
                coolDownOverlay.fillAmount = 0;
            }
        }
    }


    bool isDisabled = false;
    float currentCoolDown;
    void Start()
    {
        coolDownOverlay.fillAmount = 0;
    }
    public void FixedUpdate()
    {
        if (isDisabled)
            return;

        if (coolDownOverlay.fillAmount > 0)
        {
            currentCoolDown += Time.deltaTime;
            coolDownOverlay.fillAmount = 1 - (currentCoolDown / coolDownTime);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (coolDownOverlay.fillAmount > 0)
            return;

        isPressed = true;
        coolDownOverlay.fillAmount = 1;

        currentCoolDown = 0;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}