using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource voiceSource;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void UpdateSourceClip(AudioClip clip, AudioType audioType)
    {
        if (clip == null) return;
        
        AudioSource chosenSource = GetSource(audioType);

        if (chosenSource.clip == clip) return;
        
        chosenSource.Stop();
        chosenSource.clip = clip;
        chosenSource.Play();
    }

    public void PauseClip(AudioType audioType)
    {
        AudioSource chosenSource = GetSource(audioType);
        
        if (chosenSource == null) return;
        
        chosenSource.Pause();
    }

    public void StopClip(AudioType audioType)
    {
        AudioSource chosenSource = GetSource(audioType);
        
        if (chosenSource == null) return;
        
        chosenSource.Stop();
    }

    public void PlayClip(AudioType audioType)
    {
        AudioSource chosenSource = GetSource(audioType);
        
        if (chosenSource == null) return;
        
        chosenSource.Play();
    }

    private AudioSource GetSource(AudioType audioType)
    {
        AudioSource chosenSource = musicSource;

        switch (audioType)
        {
            case AudioType.Sound:
                chosenSource = soundSource;
                break;
            case AudioType.Voice:
                chosenSource = voiceSource;
                break;
            case AudioType.Music:
                chosenSource = musicSource;
                break;
        }
        
        return chosenSource;
    }
}

public enum AudioType
{
    Sound,
    Voice,
    Music
}
