using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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
        PlayerManagement.instance.VideoPlayer.started += UpdateButtonSpriteOnStart;
    }

    private void TogglePlaying()
    {
        if (Paused)
        {
            PM.PlayVideo();
            AudioManager.instance.PlayClip(AudioType.Voice);
            _image.sprite = pauseSprite;
        }
        else
        {
            PM.PauseVideo();
            AudioManager.instance.PauseClip(AudioType.Voice);
            _image.sprite = playSprite;
        }
    }

    public void SetupButton()
    {
        throw new System.NotImplementedException();
    }

    private void UpdateButtonSpriteOnStart(VideoPlayer player)
    {
        _image.sprite = pauseSprite;
    }
}