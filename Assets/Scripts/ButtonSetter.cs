using UnityEngine;
using UnityEngine.Video;

public class ButtonSetter : MonoBehaviour
{
    
    private void Start()
    {
        ViewerSetter.OnPresetChanged += UpdateButtons;
    }

    private void UpdateButtons(VideoButtonPreset VBP)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            
            if (i >= VBP.categoryPresets.Length)
            {
                child.SetActive(false);
                continue;
            }
            
            child.SetActive(true);
            
            if (child.TryGetComponent(out StopButton stopButton))
            {
                stopButton.SetupButton(VBP.categoryPresets[i]);
            }
        }
    }
}
