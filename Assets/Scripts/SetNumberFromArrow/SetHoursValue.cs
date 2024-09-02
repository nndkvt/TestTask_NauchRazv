public class SetHoursValue : SetNumberFromArrow
{
    protected override int CalculateInputFieldValue()
    {
        return (int)((transform.eulerAngles.z - 360) / -30f);
    }
}
