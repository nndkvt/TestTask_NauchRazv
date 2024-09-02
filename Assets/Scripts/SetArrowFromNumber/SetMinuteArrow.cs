using UnityEngine;

public class SetMinuteArrow : SetArrowFromNumber
{
    protected override Vector3 CalculateEulerAngles(int inputValue)
    {
        Vector3 returnVector = new Vector3(0, 0, -30 * ((float)inputValue / 5));
        return returnVector;
    }
}
