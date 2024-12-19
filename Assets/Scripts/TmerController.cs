using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer'ı gösterecek Text
    public static float timeElapsed; // Geçen süre
    private bool isRunning; // Timer çalışıyor mu?

    void Start()
    {
        timeElapsed = 0f;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime; // Zamanı artır
            timerText.text = "Time: " + timeElapsed.ToString("F2") + "s";
        }
    }

    public void StopTimer()
    {
        isRunning = false; // Timer'ı durdur
    }

    public void ResetTimer()
    {
        timeElapsed = 0f; // Zamanı sıfırla
        timerText.text = "Time: 0.00s";
        isRunning = true;
    }

    public float GetElapsedTime()
    {
        return timeElapsed; // Geçen süreyi döndür
    }
}
