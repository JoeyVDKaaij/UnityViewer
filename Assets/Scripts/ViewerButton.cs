using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ViewerButton : MonoBehaviour
{
    private VideoButtonPreset _currentVideoPreset;
    private CategoryButtonPreset _currentCategoryPreset;
    [SerializeField]
    private ViewerButtonType currentButtonType;

    private void Awake()
    {
        ViewerSetter.OnPresetChanged += SetVideoPreset;
        
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void SetVideoPreset(VideoButtonPreset pPreset)
    {
        _currentVideoPreset = pPreset;
    }

    private void SetCategoryPreset(CategoryButtonPreset pPreset)
    {
        _currentCategoryPreset = pPreset;
    }

    private void OnButtonClick()
    {
        if (currentButtonType == ViewerButtonType.Stop ||
            currentButtonType == ViewerButtonType.Category)
        {
            SetCategory();
        }
        else SetClip();
    }

    private void SetClip()
    {
        switch (currentButtonType)
        {
            case ViewerButtonType.Next:
                ViewerSetter.SetVideoPreset(_currentVideoPreset.nextPreset);
                break;
            case ViewerButtonType.Previous:
                ViewerSetter.SetVideoPreset(_currentVideoPreset.previousPreset);
                break;
        }
    }

    private void SetCategory()
    {
        
    }
}
