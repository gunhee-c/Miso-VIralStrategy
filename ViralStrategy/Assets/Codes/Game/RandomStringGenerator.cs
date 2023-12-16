using UnityEngine;
using UnityEngine.UI;

public class RandomStringGenerator : MonoBehaviour
{
    public Text displayText;

    void Update()
    {
        displayText.text = GameManager.Instance.CurrentTargetString;
    }
}
