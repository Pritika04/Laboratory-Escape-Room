using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public partial class LossTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        if (timeRemaining >= 0) {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
        } else {
            timeRemaining = 0;
            isGameOver = true;
            TriggerGameOver();
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TriggerGameOver()
    {
        Debug.Log("Time is up! You lose.");
        SceneManager.LoadScene("EndGame");
    }
}