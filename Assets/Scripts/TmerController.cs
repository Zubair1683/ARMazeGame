using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public static float timeElapsed; 
    private bool isRunning; 

    void Start()
    {
        timeElapsed = 0f;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime; 
            timerText.text = "Time: " + timeElapsed.ToString("F2") + "s";
        }
    }

    public void StopTimer()
    {
        isRunning = false; 
    }

    public void ResetTimer()
    {
        timeElapsed = 0f; 
        timerText.text = "Time: 0.00s";
        isRunning = true;
    }

    public float GetElapsedTime()
    {
        return timeElapsed; 
    }
}
