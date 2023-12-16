using UnityEngine;
using UnityEngine.UI;

public class InputValidator : MonoBehaviour
{
    public InputField userInputField;
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        userInputField.onValueChanged.AddListener(delegate { ValidateInput(); });
        // Activate the input field at the start
        userInputField.ActivateInputField();
        userInputField.Select();
    }

    void ValidateInput()
    {
        string currentInput = userInputField.text;

        if (GameManager.Instance.CurrentTargetString.StartsWith(currentInput))
        {
            // If the input is a correct starting substring, check for complete match
            if (currentInput.Equals(GameManager.Instance.CurrentTargetString))
            {
                int pointsEarned = currentInput.Length;
                score += pointsEarned;
                UpdateScoreDisplay();
                GameManager.Instance.GenerateNewTargetString();
                Debug.Log("Correct! You earned " + score + " points.");
                //yield return new WaitForSeconds(2.0f);
                GameManager.Instance.ResetTimer(); // Notify GameManager to reset the timer
                userInputField.text = ""; // Clear the input field after a correct answer
            }
        }
        else
        {
            // Reset the input field if it's not a correct starting substring
            userInputField.text = "";
        }
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
