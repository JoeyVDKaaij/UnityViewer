using UnityEngine;

[CreateAssetMenu(fileName = "CategoryVideoButton", menuName = "Button Presets/Category Video Button")]
public class CategoryButtonPreset : ButtonPreset
{
    [SerializeField, Tooltip("Set up all the buttons present in this category.")]
    private VideoButtonPreset[] viewerButtonsPresets;
    [SerializeField, Tooltip("Set up all the buttons present in this category.")]
    private CategoryButtonPreset[] categoryButtonsPresets;
    public VideoButtonPreset[] ViewerButtonsPresets { get { return viewerButtonsPresets; } }
    public CategoryButtonPreset[] CategoryButtonsPresets { get { return categoryButtonsPresets; } }
    public AudioClip musicClip;
    public CategorySetter categoryEnv;
}
