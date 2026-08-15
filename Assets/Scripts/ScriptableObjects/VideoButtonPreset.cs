using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoButtonPreset", menuName = "Button Presets/Video Button Preset")]
public class VideoButtonPreset : ButtonPreset
{
    public VideoClip videoClip;
    public VideoButtonPreset nextPreset;
    public VideoButtonPreset previousPreset;
    public CategoryButtonPreset stopCategoryPreset;
    public CategoryButtonPreset[] categoryPresets;
    public AudioClip voiceClip;
    public AudioClip musicClip;

    public bool loopClip = true;
}
