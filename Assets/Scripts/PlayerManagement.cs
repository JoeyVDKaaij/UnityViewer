using System;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class PlayerManagement : MonoBehaviour
{
    public static PlayerManagement instance;

    private VideoPlayer _videoPlayer;
    public VideoPlayer VideoPlayer => _videoPlayer;

    private VideoButtonPreset _videoPreset;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.isLooping = true;
        ViewerSetter.OnPresetChanged += SetVideo;
        _videoPlayer.loopPointReached += delegate { OnEndOfVideo(); };
    }

    public void PlayVideo()
    {
        _videoPlayer.Play();
    }

    public void PauseVideo()
    {
        _videoPlayer.Pause();
    }

    public void StopVideo()
    {
        _videoPlayer.Stop();
    }

    public void SetVideo(VideoClip clip)
    {
        StopVideo();
        _videoPlayer.clip = clip;
        _videoPlayer.time = 0;
        PlayVideo();
    }

    private void SetVideo(VideoButtonPreset preset)
    {
        _videoPreset = preset;

        _videoPlayer.isLooping = preset.loopClip;
        
        SetVideo(preset.videoClip);
    }

    private void OnEndOfVideo()
    {
        if (_videoPlayer.isLooping)
        {
            AudioManager.instance.ReplayClip(AudioType.Voice);
            return;
        }
        
        ViewerSetter.SetVideoPreset(_videoPreset.nextPreset);
    }
}