using System;
using UnityEngine;

public class ViewerSetter : MonoBehaviour
{
    [SerializeField, Tooltip("Sets the default video preset when the Viewer gets activated without a video preset.")]
    private VideoButtonPreset defaultVideoPreset;
    
    [SerializeField, Tooltip("The category viewer.")]
    private CategorySetter categoryViewer;

    private static VideoButtonPreset _videoPreset;

    public static Action<VideoButtonPreset> OnPresetChanged;

    private void Start()
    {
        if (_videoPreset == null)
        {
            SetVideoPreset(defaultVideoPreset);
        }
    }

    public static void SetVideoPreset(VideoButtonPreset pPreset)
    {
        if (_videoPreset == pPreset || pPreset == null) return;

        _videoPreset = pPreset;
        
        AudioManager.instance.UpdateSourceClip(_videoPreset.musicClip, AudioType.Music);
        AudioManager.instance.UpdateSourceClip(_videoPreset.voiceClip, AudioType.Voice);
        AudioManager.instance.ReplayClip(AudioType.Voice);
        
        OnPresetChanged?.Invoke(pPreset);
    }

    public void ChangeToCategoryView(CategoryButtonPreset categoryButtonPreset)
    {
        categoryViewer.gameObject.SetActive(true);
        categoryViewer = categoryViewer.CreateNewCategory(categoryButtonPreset);
        categoryViewer.SetViewerSetter(this);
    }
}
