using UnityEngine;

public class SetHourArrow : SetArrowFromNumber
{
    [SerializeField] private ChangeTimePeriodButton _amPmButton;

    protected override Vector3 CalculateEulerAngles(int inputValue)
    {
        Vector3 returnVector = new Vector3(0, 0, -30 * inputValue);
        return returnVector;
    }

    public override void FormatInput(string inputValue)
    {
        if (inputValue == "24")
        {
            inputValue = "00";
        }

        if (int.Parse(inputValue) >= 12)
        {
            inputValue = (int.Parse(inputValue) - 12).ToString();

            _amPmButton.SwitchToNight();
        }

        base.FormatInput(inputValue);
    }
}
