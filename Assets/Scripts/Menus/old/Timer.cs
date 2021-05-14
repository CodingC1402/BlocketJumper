using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int minute = 0;
    public int seconds = 0;
    public float counter = 0;

    void Update()
    {
        counter += Time.deltaTime;
        if (seconds != (int)counter)
        {
            UpdateText();
        }
    }

    void UpdateText()
    {
        seconds = (int)counter;
        if (seconds >= 60)
        {
            seconds -= 60;
            counter -= 60;
            minute += 1;
        }

        if (minute > 60)
        {
            minute = 60;
        }

        string sMinute = $"{minute}";
        string sSecond = $"{seconds}";
        sMinute = sMinute.PadLeft(2, '0');
        sSecond = sSecond.PadLeft(2, '0');

        text.text = $"{sMinute}:{sSecond}";
    }
}
