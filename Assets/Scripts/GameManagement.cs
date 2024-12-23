using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagement : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject canvas1;
    public GameObject canvas2;
    ARMazeMovement ARMaze;

    void Start()
    {
        ARMaze = FindObjectOfType<ARMazeMovement>();
    }

    void Update()
    {
        float finalTime = TimerController.timeElapsed;
        if (finalTime > 40f && finalTime < 50f)
        {
            image2.SetActive(false);
        }
        else if (finalTime > 50f)
        {
            image2.SetActive(false);
            image3.SetActive(false);
        }
        finalTimeText.text = "Time: " + finalTime.ToString("F2") + "s";
    }

    public void LoadTryAgainCanvas()
    {
        // Deactivate the first canvas
        canvas2.SetActive(false);
        TimerController.timeElapsed = 0f;
        ARMaze.ResetPlayerPosition();
        // Activate the second canvas
        canvas1.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
