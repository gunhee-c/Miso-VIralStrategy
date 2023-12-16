using UnityEngine;
using System.Collections;
using System.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public string CurrentTargetString { get; private set; }
    //난이도 조절
    private float timerDuration = 10f;
    //난이도 조절
    private int min_object = 2;
    private int max_objet = 4;

    private float currentTimer;
    private string characters = "qwe"; // Characters to use in the string

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ResetTimer();
        GenerateNewTargetString();
    }

    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else
        {
            ResetTimer();
            GenerateNewTargetString();
        }
    }

    public void ResetTimer()
    {
        currentTimer = timerDuration;
    }

    public float GetTimeRemainingNormalized()
    {
        return currentTimer / timerDuration;
    }

    public void GenerateNewTargetString()
    {
        CurrentTargetString = GenerateRandomString();
    }

    string GenerateRandomString()
    {
        int stringLength = Random.Range(min_object, max_objet); // Random string length between 5 and 10
        StringBuilder stringBuilder = new StringBuilder(stringLength);

        char lastChar = '\0'; // Initialize with a character that won't be in your string

        for (int i = 0; i < stringLength; i++)
        {
            char newChar = characters[Random.Range(0, characters.Length)];

            // Ensure the new character is different from the last character
            while (newChar == lastChar)
            {
                newChar = characters[Random.Range(0, characters.Length)];
            }

            stringBuilder.Append(newChar);
            lastChar = newChar; // Update the last character
        }

        return stringBuilder.ToString();
    }
}
