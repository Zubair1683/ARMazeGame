using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    // This method will be called when the Start button is pressed
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger is with the object tagged as "Exit"
        if (other.CompareTag("Exit"))
        {
            // Deactivate the first canvas
            canvas1.SetActive(false);

            // Activate the second canvas
            canvas2.SetActive(true);
        }
    }
}
