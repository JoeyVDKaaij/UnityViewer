using UnityEngine;

public class ButtonPreset : ScriptableObject
{
    [Header("Button Settings")]
    [SerializeField, Tooltip("Set the thumbnail of the button")]
    private Sprite thumbnail;
    public Sprite Thumbnail { get { return thumbnail; } }
}
