using UnityEngine;
using System.Collections;

public class RotateSprite : MonoBehaviour
{
    public float angle = 45.0f; // Max swing angle
    public float speed = 2.0f; // Speed of swing
    public float rotationSpeed = 120.0f; // Speed of rotation
    public bool rotateHorizontally = true; // Set to false for vertical rotation
    public float colorChangeDuration = 1.0f; // Duration for a complete color change cycle
    private DisappearOnClick disappearOnClick;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float colorChangeTimer;
    private float checkInterval = 1.0f; // Time interval in seconds for checking
    private float chanceToChange = 0.03f; // 3% chance
    private bool isRed = false;
    void Start()
    {
        StartCoroutine(PeriodicCheck());
        disappearOnClick = GetComponent<DisappearOnClick>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer ? spriteRenderer.color : Color.white;
    }

    void Update()
    {
        float rotationAngle = Mathf.Sin(Time.time * speed) * angle;
        if (rotateHorizontally)
        {
            transform.localRotation = Quaternion.Euler(0, rotationAngle, 0);
            isRed = false;
            GradualColorChange(isRed);
            disappearOnClick.SetClickable(false);
        }
        else
        {
            // Rotate around the x-axis
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            isRed = true;
            GradualColorChange(isRed);
            disappearOnClick.SetClickable(true);
        }
    }
    void GradualColorChange(bool isRed)
    {
        if (isRed == true){
            if (spriteRenderer != null)
        {
            // Increment timer
            colorChangeTimer += Time.deltaTime;

            // Calculate the proportion of the color change cycle completed
            float lerpFactor = Mathf.PingPong(colorChangeTimer, colorChangeDuration) / (colorChangeDuration * 2);

            // Smoothly transition color
            spriteRenderer.color = Color.Lerp(originalColor, Color.red, lerpFactor);
        }
        }
        else{
            if (spriteRenderer != null)
        {
            // Increment timer

            // Smoothly transition color
            spriteRenderer.color = originalColor;
        }
        }
    }
    
    IEnumerator PeriodicCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);

            if (Random.value < chanceToChange)
            {
                StartCoroutine(TemporaryStateChange());
            }
        }
    }

    IEnumerator TemporaryStateChange()
    {
        rotateHorizontally = false;
        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds
        rotateHorizontally = true;
    }
}
