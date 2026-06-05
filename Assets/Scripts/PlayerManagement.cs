using System;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class PlayerManagement : MonoBehaviour
{
    public static PlayerManagement instance;

    private VideoPlayer _videoPlayer;
    public VideoPlayer VideoPlayer => _videoPlayer;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.isLooping = true;
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
    }
}