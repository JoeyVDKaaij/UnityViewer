using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class ViewerButtonEnabler : MonoBehaviour, IButton
{
    [SerializeField, Tooltip("The video preset that plays when the button is pressed.")]
    private VideoButtonPreset videoPreset;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPress);

        SetupButton();
    }

    private void OnPress()
    {
        if (videoPreset == null) return;
        
        CategorySetter.instance.EnableViewer(videoPreset);
    }
    
    public void SetupButton()
    {
        if (TryGetComponent(out Image image) && videoPreset != null)
            image.sprite = videoPreset.Thumbnail;
    }

    public void SetupButton(VideoButtonPreset preset)
    {
        videoPreset = preset;
        
        SetupButton();
    }
}
