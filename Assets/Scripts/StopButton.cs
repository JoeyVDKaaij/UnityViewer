using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StopButton : MonoBehaviour, IButton
{
    private Button _button;

    [SerializeField, Tooltip("What should pop up after stopping the video.")]
    private CategoryButtonPreset categoryPreset;
    [SerializeField, Tooltip("The ViewerSetter.")]
    private ViewerSetter viewerSetter;

    [SerializeField] private bool useThumbnail;
    private Image _img;
    
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(StopVideo);
        ViewerSetter.OnPresetChanged += SetupButton;
        
        _img = GetComponent<Image>();
    }

    private void StopVideo()
    {
        PlayerManagement.instance.StopVideo();
        AudioManager.instance.StopClip(AudioType.Voice);
        viewerSetter.ChangeToCategoryView(categoryPreset);
    }

    public void SetupButton()
    {
        throw new System.NotImplementedException();
    }
    
    public void SetupButton(VideoButtonPreset buttonPreset)
    {
        categoryPreset = buttonPreset.stopCategoryPreset;
        if (useThumbnail) _img.sprite = categoryPreset.Thumbnail;
    }
    
    public void SetupButton(CategoryButtonPreset buttonPreset)
    {
        categoryPreset = buttonPreset;
        if (useThumbnail) _img.sprite = categoryPreset.Thumbnail;
    }
}
