using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonSetting : MonoBehaviour, IPointerDownHandler
{
    public settingPanel panel;
    public UISetting setting;
    private RectTransform rt;
    private CanvasGroup cvg;

    public int Transparency
    { 
        get
        {
            return setting.transparence;
        }
    }
    public int Size
    {
        get { return setting.size; }
    }
    public Vector2 CurrentPos
    { 
        get { return new Vector2(setting.currentPosX, setting.currentPosY); }
        set 
        { 
            setting.currentPosX = value.x;
            setting.currentPosY = value.y;
        }
    }

    public void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        cvg = gameObject.GetComponent<CanvasGroup>();

        if (setting != null)
        {
            gameObject.transform.position = CurrentPos;
            SetTransparence(Transparency);
            SetSize(Size);
        }
        else
        {
            Debug.Log("UI setting is null");
        }

    }
    public void SetSize(int size)
    {
        this.setting.size = size;
        Vector3 scale = rt.localScale;
        scale.x = 1 + (size - 50) / 56f;
        scale.y = 1 + (size - 50) / 56f;
        rt.localScale = scale;
    }
    public void SetTransparence(int percent)
    {
        setting.transparence = percent;
        cvg.alpha = percent / 100f;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (panel == null)
            return;

        panel.Select(this);
    }
}
