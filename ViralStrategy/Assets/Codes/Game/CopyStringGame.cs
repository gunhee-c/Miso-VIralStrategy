using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CopyStringGame : MonoBehaviour
{
    public Text textToCopy;
    public InputField inputField;
    public Text timerText;

    private string currentString = "";
    private float timeLimit = 5f; // 5 seconds for each round
    private float timer;

    void Start()
    {
        StartCoroutine(StartNewRound());
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();
            CheckUserInput();
        }
        else
        {
            StartCoroutine(StartNewRound());
        }
    }

    IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds before starting a new round
        currentString = GenerateRandomString();
        textToCopy.text = currentString;
        inputField.text = "";
        timer = timeLimit;
    }

    void CheckUserInput()
    {
        if (inputField.text.Equals(currentString))
        {
            // User successfully copied the string
            // Implement success logic here
            StartCoroutine(StartNewRound());
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
            timerText.text = "Time left: " + timer.ToString("F2");
    }

    string GenerateRandomString()
    {
        // Implement your string generation logic here
        // This is a placeholder for the random string generation
        return "RandomString";
    }
}
