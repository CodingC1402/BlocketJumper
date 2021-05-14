using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragHandle : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    public Vector2 currentPos;
    private RectTransform rt;
    private CanvasGroup cvg;

    private bool firstTime = true;
    public void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        cvg = gameObject.GetComponent<CanvasGroup>();
    }

    public void Update()
    {
        currentPos = RectTransformUtility.WorldToScreenPoint(new Camera(), transform.position);
        currentPos.x = Mathf.Clamp(currentPos.x, ((rt.rect.width * rt.localScale.x) / 2) * Setting.ratioRes, Screen.width - ((rt.rect.width * rt.localScale.x) / 2) * Setting.ratioRes);
        currentPos.y = Mathf.Clamp(currentPos.y, ((rt.rect.height * rt.localScale.y) / 2) * Setting.ratioRes, Screen.height - ((rt.rect.height * rt.localScale.y) / 2) * Setting.ratioRes);
        transform.position = currentPos;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonSetting buttonSetting = gameObject.GetComponent<buttonSetting>();
        if (buttonSetting != null)
        {
            buttonSetting.CurrentPos = currentPos;
        }
    }
}
