using UnityEngine;
using UnityEngine.UI;

public class KeepFocusOnInput : MonoBehaviour
{
    public InputField inputField;

    void Update()
    {
        if (!inputField.isFocused)
        {
            inputField.ActivateInputField();
            inputField.Select();
        }
    }
}
