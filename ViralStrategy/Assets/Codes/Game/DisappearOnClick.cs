using UnityEngine;

public class DisappearOnClick : MonoBehaviour
{
    private bool Clickable = false;
    private int addscore = 1;
    void OnMouseDown()
    {
        if (Clickable == true){
            gameObject.SetActive(false);
        }
        // This will make the sprite invisible
    }
    public void SetClickable(bool value)
    {
        Clickable = value;
    }
}