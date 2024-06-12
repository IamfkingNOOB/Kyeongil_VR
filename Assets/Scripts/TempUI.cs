using UnityEngine;
using UnityEngine.UI;

public class TempUI : MonoBehaviour
{
    [SerializeField] private Button _tempButton;
    [SerializeField] private Slider _tempSlider;

    private void OnEnable()
    {
        if (_tempButton != null)
        {
            _tempButton.onClick.AddListener(OnClick_TempButton);
        }

        if (_tempSlider != null)
        {
            _tempSlider.onValueChanged.AddListener(OnValueChanged_TempSlider);
        }
    }

    private void OnDisable()
    {
        if (_tempButton != null)
        {
            _tempButton.onClick.RemoveListener(OnClick_TempButton);
        }

        if (_tempSlider != null)
        {
            _tempSlider.onValueChanged.RemoveListener(OnValueChanged_TempSlider);
        }
    }

    private void OnClick_TempButton()
    {
        Debug.Log("Button is Clicked!");
    }

    private void OnValueChanged_TempSlider(float value)
    {
        Debug.Log($"Slider's Value is Changed! {value}");
    }

}
