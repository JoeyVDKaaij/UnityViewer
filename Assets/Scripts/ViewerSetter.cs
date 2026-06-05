using System;
using UnityEngine;

public class ViewerSetter : MonoBehaviour
{
    private VideoButtonPreset defaultVideoPreset;

    private VideoButtonPreset _videoPreset;

    private void Start()
    {
        if (_videoPreset == null)
        {
            SetVideoPreset(defaultVideoPreset);
        }
    }

    public void SetVideoPreset(VideoButtonPreset pPreset)
    {
        if (pPreset == null) return;
    }
}
