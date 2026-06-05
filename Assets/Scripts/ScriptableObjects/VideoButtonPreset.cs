using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoButtonPreset", menuName = "Button Presets/Video Button Preset")]
public class VideoButtonPreset : ButtonPreset
{
    public VideoClip VideoClip;
    public Sprite Thumbnail;
    public VideoButtonPreset nextPreset;
    public VideoButtonPreset previousPreset;
    public CategoryButtonPreset categoryPreset;
}
