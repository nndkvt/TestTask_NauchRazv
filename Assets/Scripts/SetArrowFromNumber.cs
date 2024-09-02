using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_InputField))]
public abstract class SetArrowFromNumber : MonoBehaviour
{
    [SerializeField] protected Image _assignedArrow;
    [SerializeField] protected TMP_Text _errorText;
    [SerializeField] protected float _errorMessageTime = 5;
    [SerializeField] protected int _maxValue;

    protected TMP_InputField _inputField;

    protected void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();

        _inputField.onEndEdit.AddListener(UpdateArrowRotation);
    }

    protected void OnDisable()
    {
        _inputField.onEndEdit.RemoveAllListeners();
    }

    public void UpdateArrowRotation(string inputValue)
    {
        if (!IsInputValid(inputValue, out int inputInt) && inputValue != "")
        {
            _inputField.text = "";
            StartCoroutine(DisplayErrorMessage());
            return;
        }

        FormatInput(inputValue);
        _assignedArrow.transform.eulerAngles = CalculateEulerAngles(inputInt);
    }

    protected bool IsInputValid(string inputValue, out int returnInt)
    {
        if (int.TryParse(inputValue, out int inputInt))
        {
            returnInt = inputInt;

            return (inputValue.Length <= 2 &&
                    inputInt <= _maxValue &&
                    inputInt >= 0);
        }

        returnInt = 0;
        return false;
    }

    protected IEnumerator DisplayErrorMessage()
    {
        _errorText.gameObject.SetActive(true);

        yield return new WaitForSeconds(_errorMessageTime);

        _errorText.gameObject.SetActive(false);
    }

    public virtual void FormatInput(string inputValue)
    {
        if (inputValue.Length == 1)
        {
            inputValue = "0" + inputValue;
        }

        _inputField.text = inputValue;
    }

    protected abstract Vector3 CalculateEulerAngles(int inputValue);
}
