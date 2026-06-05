using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class PauseButton : MonoBehaviour, IButton
{
    private Button _button;
    private Image _image;
    
    [SerializeField, Tooltip("Set Pause Sprite.")]
    private Sprite pauseSprite;
    [SerializeField, Tooltip("Set Play Sprite.")]
    private Sprite playSprite;

    private PlayerManagement PM => PlayerManagement.instance;
    private bool Paused => PlayerManagement.instance.VideoPlayer.isPaused;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TogglePlaying);
        
        _image = GetComponent<Image>();
    }

    private void TogglePlaying()
    {
        if (Paused)
        {
            PM.PlayVideo();
            _image.sprite = pauseSprite;
        }
        else
        {
            PM.PauseVideo();
            _image.sprite = playSprite;
        }
    }

    public void SetupButton()
    {
        throw new System.NotImplementedException();
    }
}