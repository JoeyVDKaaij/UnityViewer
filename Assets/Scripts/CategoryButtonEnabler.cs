using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class CategoryButtonEnabler : MonoBehaviour, IButton
{
    [SerializeField, Tooltip("The video preset that plays when the button is pressed.")]
    private CategoryButtonPreset categoryPreset;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPress);

        SetupButton();
    }

    private void OnPress()
    {
        if (categoryPreset == null) return;

        CategorySetter.instance.CreateNewCategory(categoryPreset);
    }
    
    public void SetupButton()
    {
        if (TryGetComponent(out Image image) && categoryPreset != null)
            image.sprite = categoryPreset.Thumbnail;
    }

    public void SetupButton(CategoryButtonPreset preset)
    {
        categoryPreset = preset;
        
        SetupButton();
    }
}
