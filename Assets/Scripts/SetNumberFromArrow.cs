using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class SetNumberFromArrow : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] protected SetArrowFromNumber _inputField;

    protected Image _image;

    protected Vector3 startPosition;
    protected bool _isGettingMousePosition = false;

    protected void Awake()
    {
        _image = GetComponent<Image>();
        startPosition = _image.transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isGettingMousePosition = true;
    }

    protected void Update()
    {
        if (_isGettingMousePosition)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mouseDelta = Input.mousePosition - startPosition;
                Debug.Log(mouseDelta);

                float angle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg - 180;

                transform.eulerAngles = new Vector3(0, 0, angle + 90);

                string inputValue = CalculateInputFieldValue().ToString();
                _inputField.FormatInput(inputValue);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isGettingMousePosition = false;
            }
        }
    }

    protected abstract int CalculateInputFieldValue();
}