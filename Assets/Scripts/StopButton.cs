using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StopButton : MonoBehaviour, IButton
{
    private Button _button;

    [SerializeField, Tooltip("What should pop up after stopping the video.")]
    private ButtonPreset buttonPreset;
    
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(StopVideo);
    }

    private void StopVideo()
    {
        PlayerManagement.instance.StopVideo();
    }

    public void SetupButton()
    {
        throw new System.NotImplementedException();
    }
}
