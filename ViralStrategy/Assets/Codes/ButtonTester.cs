using UnityEngine;
using UnityEngine.UI;

public class ButtonTester : MonoBehaviour
{
    public static int count = 0;
    public Text buttonText; // Assign a UI Text element to show the count

    public void OnButtonClick()
    {
        ButtonTextChanger.clickCount = 0;
        count = (count + 1) % 7; // Increment count and loop from 0 to 6
        if (count == 0){
            ContentController.currentSceneNumber = 0;
            ContentController.currentBranchNumber = 0;
        }
                if (count == 1){
            ContentController.currentSceneNumber = 1;
            ContentController.currentBranchNumber = 0;
        }
                if (count == 2){
            ContentController.currentSceneNumber = 1;
            ContentController.currentBranchNumber = 1;
        }
                if (count == 3){
            ContentController.currentSceneNumber = 1;
            ContentController.currentBranchNumber = 2;
        }
                if (count == 4){
            ContentController.currentSceneNumber = 2;
            ContentController.currentBranchNumber = 1;
        }
                if (count == 5){
            ContentController.currentSceneNumber = 2;
            ContentController.currentBranchNumber = 2;
        }
                if (count == 6){
            ContentController.currentSceneNumber = 2;
            ContentController.currentBranchNumber = 3;
        }

        // Update the button text to show the current count
        if (buttonText != null)
        {
            buttonText.text = "Count: " + count;
        }
    }
}
