using UnityEngine;

[CreateAssetMenu(fileName = "CategoryVideoButton", menuName = "Button Presets/Category Video Button")]
public class CategoryButtonPreset : ButtonPreset
{
    [SerializeField, Tooltip("Set up all the buttons present in this category.")]
    private ButtonPreset[] buttonPresets;
    public ButtonPreset[] ButtonPresets { get { return buttonPresets; } }
}
