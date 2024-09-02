public class SetMinutesValue : SetNumberFromArrow
{
    protected override int CalculateInputFieldValue()
    {
        return (int)((transform.eulerAngles.z - 360) * 5f / -30f);
    }
}
