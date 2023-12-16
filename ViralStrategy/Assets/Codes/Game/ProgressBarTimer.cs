using UnityEngine;
using UnityEngine.UI;

public class ProgressBarTimer : MonoBehaviour
{
    public Slider timeSlider;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            timeSlider.value = GameManager.Instance.GetTimeRemainingNormalized();
        }
    }
}
