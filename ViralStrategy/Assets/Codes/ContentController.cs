using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class ContentController : MonoBehaviour
{
    public static int currentSceneNumber = 0; // Fixed integer value
    public static int currentBranchNumber = 0;
    public Button myButton; // Reference to the button
    public Image backgroundImage; // Reference to the background image
    public SceneFader sceneFader;
    void Start(){
        sceneFader.FadeIn();
    }
    void Update()
    {

        if (ButtonTextChanger.clickCount >= ButtonTextChanger.clickMaxCount)
        {
            // Change to the other scene
            
            StartCoroutine(LoadSceneAfterFadeOut());
        }
    }
    
    private IEnumerator LoadSceneAfterFadeOut()
    {
        sceneFader.FadeOut();
        yield return new WaitForSeconds(1); // Wait for 1 second
        SceneManager.LoadScene("GameScene"); // Replace with your scene name
    }
    private void UpdateContentBasedOnValue()
    {
        // Example logic: Change button color based on the fixed value
        if (ButtonTextChanger.clickCount > 5)
        {
            myButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            myButton.GetComponent<Image>().color = Color.green;
        }

        // Example logic: Change background image opacity based on the fixed value
        //Color bgColor = backgroundImage.color;
        //backgroundImage.color = new Color(bgColor.r, bgColor.g, bgColor.b, currentSceneNumber / 10.0f);
    }
}
