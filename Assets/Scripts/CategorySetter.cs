using System;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Serialization;

public class CategorySetter : MonoBehaviour
{
    public static CategorySetter instance;
    
    [SerializeField, Tooltip("Set the default Category Button Preset.")]
    private CategoryButtonPreset defaultCategoryButtonPreset;
    
    [SerializeField, Tooltip("The viewer that gets enabled when a video button is pressed.")]
    private ViewerSetter viewerSetter;
    
    [SerializeField, Tooltip("The transform holding all the video buttons.")]
    private Transform viewerButtons;
    [SerializeField, Tooltip("The transform holding all the category buttons.")]
    private Transform categoryButtons;
    [SerializeField, Tooltip("The template used for video buttons.")]
    private ViewerButtonEnabler viewerButtonEnablerTemplate;
    [SerializeField, Tooltip("The template used for category buttons.")]
    private CategoryButtonEnabler categoryButtonEnablerTemplate;

    private CategoryButtonPreset _currentCategoryButtonPreset;

    private void OnEnable()
    {
        if (instance != null) Destroy(gameObject);
        
        instance = this;
    }

    private void Start()
    {
        if (_currentCategoryButtonPreset == null) SetupCategory(defaultCategoryButtonPreset);
    }

    public void EnableViewer(VideoButtonPreset preset)
    {
        viewerSetter.gameObject.SetActive(true);
        ViewerSetter.SetVideoPreset(preset);
        
        instance = null;
        gameObject.SetActive(false);
    }

    public void SetupCategory(CategoryButtonPreset preset)
    {
        _currentCategoryButtonPreset = preset;
        
        if (_currentCategoryButtonPreset.ViewerButtonsPresets.Length > 0 && viewerButtons != null && viewerButtonEnablerTemplate != null)
            SetupViewerButtons(_currentCategoryButtonPreset.ViewerButtonsPresets);
        
        if (_currentCategoryButtonPreset.CategoryButtonsPresets.Length > 0 && categoryButtons != null && categoryButtonEnablerTemplate != null)
            SetupCategoryButtons(_currentCategoryButtonPreset.CategoryButtonsPresets);
        
        if (_currentCategoryButtonPreset.musicClip != null)
            AudioManager.instance.UpdateSourceClip(preset.musicClip, AudioType.Music);
    }

    private void SetupViewerButtons(VideoButtonPreset[] presets)
    {
        for (int i = 0; i < presets.Length; i++)
        {
            if (i < viewerButtons.childCount && viewerButtons.GetChild(i).TryGetComponent(out ViewerButtonEnabler existingVBE))
            {
                viewerButtons.GetChild(i).gameObject.SetActive(true);
                existingVBE.SetupButton(presets[i]);
                continue;
            }
            
            ViewerButtonEnabler newVBE = Instantiate(viewerButtonEnablerTemplate, viewerButtons);
            newVBE.SetupButton(presets[i]);
        }

        for (int i = presets.Length; i < viewerButtons.childCount; i++)
        {
            viewerButtons.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void SetupCategoryButtons(CategoryButtonPreset[] presets)
    {
        for (int i = 0; i < presets.Length; i++)
        {
            if (i < categoryButtons.childCount && categoryButtons.GetChild(i).TryGetComponent(out CategoryButtonEnabler existingCBE))
            {
                categoryButtons.GetChild(i).gameObject.SetActive(true);
                existingCBE.SetupButton(presets[i]);
                continue;
            }
            
            CategoryButtonEnabler newCBE = Instantiate(categoryButtonEnablerTemplate, categoryButtons);
            newCBE.SetupButton(presets[i]);
        }

        for (int i = presets.Length; i < categoryButtons.childCount; i++)
        {
            categoryButtons.GetChild(i).gameObject.SetActive(false);
        }
    }

    public CategorySetter CreateNewCategory(CategoryButtonPreset preset)
    {
        instance = null;
        Destroy(gameObject);
        
        CategorySetter newInstance = Instantiate(preset.categoryEnv);
        newInstance.SetViewerSetter(viewerSetter);
        newInstance.SetupCategory(preset);

        return newInstance;
    }

    public void SetViewerSetter(ViewerSetter VS)
    {
        viewerSetter = VS;
    }
}
