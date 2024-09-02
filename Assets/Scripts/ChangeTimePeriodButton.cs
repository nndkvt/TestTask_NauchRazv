using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeTimePeriodButton : MonoBehaviour
{
    private Button _button;

    private static bool _isDay = true;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SwitchTimePeriod);

        SwitchTimePeriod();
    }

    private void SwitchTimePeriod()
    {
        _isDay = !_isDay;

        if (_isDay)
        {
            _button.GetComponentInChildren<TMP_Text>().text = "AM";
        }
        else
        {
            _button.GetComponentInChildren<TMP_Text>().text = "PM";
        }
    }

    public void SwitchToNight()
    {
        _isDay = false;

        _button.GetComponentInChildren<TMP_Text>().text = "PM";
    }
}
