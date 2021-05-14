using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class settingPanel : MonoBehaviour
{
    public TextMeshProUGUI tText;
    public TextMeshProUGUI sText;
    public Slider transparency;
    public Slider size;

    public buttonSetting currentSetting;

    public void Select(buttonSetting selectButton)
    {
        if (currentSetting == selectButton)
            return;

        currentSetting = selectButton;
        transparency.value = currentSetting.Transparency;
        size.value = currentSetting.Size;
        SetText();
    }

    public void SetTransparency(float value)
    {
        if (currentSetting == null)
            return;

        currentSetting.SetTransparence((int)value);
        SetText();
    }
    public void SetSize(float value)
    {
        if (currentSetting == null)
            return;

        currentSetting.SetSize((int)value);
        SetText();
    }
    private void SetText()
    {
        if (currentSetting == null)
            return;

        tText.text = $"{currentSetting.Transparency}%";
        sText.text = $"{currentSetting.Size}%";
    }
}
