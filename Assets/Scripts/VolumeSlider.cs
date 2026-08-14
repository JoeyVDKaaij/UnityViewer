using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField]
    private AudioMixer mixerGroup;
    [SerializeField]
    private string mixerParam;

    private float _minDB = -80;
    private float _range = 80;
    private float _exp = 0.5f;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = 100;
        _slider.onValueChanged.AddListener(delegate { OnChangedValue(); });
    }

    private void OnEnable()
    {
        mixerGroup.GetFloat(mixerParam, out float value);
        _slider.value = Mathf.Pow((value + -_minDB) / _range, 1/_exp) * 100;
    }

    private void OnChangedValue()
    {
        if (mixerGroup == null || mixerParam == "") return;

        // Calculate the decibels from a percentage based on a formula.
        float db = _minDB;
        if (_slider.value != 0)
        {
            float percentage = _slider.value / 100;
            db = _minDB + _range * Mathf.Pow(percentage, _exp);
        }
        
        mixerGroup.SetFloat(mixerParam, db);
    }
}
