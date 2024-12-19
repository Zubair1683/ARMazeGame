using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using TMPro;
public class GameController : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    
    void Start()
    {
         float finalTime = TimerController.timeElapsed;
            if(finalTime > 40f && finalTime < 50f)
            {
                image2.SetActive(false);
            }
             else if(finalTime > 50f)
            {
                image2.SetActive(false);
                image3.SetActive(false);
            }
        finalTimeText.text = "Time: " + finalTime.ToString("F2") + "s";
    }
    // This method will be called when the Start button is pressed
    public void LoadGameScene()
    {
        // Replace "GameScene" with the actual name of your game scene
        SceneManager.LoadScene(1);
    }
    public void LoadStartScene()
    {
        // Load the Start Scene (assuming Scene 0 is the Start Scene)
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
{
    Application.Quit();
}

private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger is with the object tagged as "Exit"
        if (other.CompareTag("Exit"))
        {
           /* float finalTime = TimerController.timeElapsed;
            if(finalTime > 1f && finalTime < 50f)
            {
                Debug.Log("hi");
                image2.SetActive(false);
            }
             else if(finalTime > 50f)
            {
                image2.SetActive(false);
                image3.SetActive(false);
            }
            Debug.Log(finalTime);
            Debug.Log(finalTime > 1f);
            finalTimeText.text = "Time: " + finalTime.ToString("F2") + "s";*/
            SceneManager.LoadScene(2);
        }
    }
}
