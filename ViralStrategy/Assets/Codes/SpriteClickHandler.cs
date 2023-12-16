using UnityEngine;

public class SpriteClickHandler : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        // Check if isVisible is false
        {
            // Make the sprite invisible
            spriteRenderer.enabled = false;
        }
    }
}
