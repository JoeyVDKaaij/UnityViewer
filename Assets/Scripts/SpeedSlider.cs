using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SpeedSlider : MonoBehaviour
{
    [SerializeField]
    private float minValue = 0.5f;
    [SerializeField]
    private float maxValue = 5;
    [SerializeField]
    private int amountOfDecimals = 2;
    [SerializeField]
    private TMP_Text valueDisplay;
    [SerializeField]
    private AudioMixer mixerGroup;
    [SerializeField]
    private string mixerParam;
    
    private Slider _slider;
    private PlayerManagement _PM => PlayerManagement.instance;
    
    void Start()
    {
        _slider = GetComponent<Slider>();
        
        _slider.minValue = minValue * GetDecimalsMultiplier();
        _slider.maxValue = maxValue * GetDecimalsMultiplier();
        
        _slider.value = 1 * Mathf.Pow(10, amountOfDecimals);
        
        _slider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    private void OnValueChanged()
    {
        if (_PM != null)
        {
            _PM.VideoPlayer.playbackSpeed = _slider.value / GetDecimalsMultiplier();
            
            if (mixerGroup != null && mixerParam != "")
                mixerGroup.SetFloat(mixerParam, _slider.value / GetDecimalsMultiplier());
        }
        
        if (valueDisplay != null)
            valueDisplay.SetText((_slider.value / GetDecimalsMultiplier()).ToString(GetFormat()));
    }

    private float GetDecimalsMultiplier()
    {
        return Mathf.Pow(10, amountOfDecimals);
    }

    private string GetFormat()
    {
        string format = "0";
        
        if (amountOfDecimals > 0)
        {
            format += ".";
            for (int i = 0; i < amountOfDecimals; i++) format += "0";
        }
        
        return format;
    }
}
