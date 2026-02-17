using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public string[] correctOrder = { "Tube_Red", "Tube_Blue", "Tube_Green" };
    public string[] currentPlacedTubes = new string[3];
    
    private int correctCount = 0;

    void Update() {
        CheckWinCondition();
    }

    void CheckWinCondition() {
        int matchCount = 0;

        for (int i = 0; i < correctOrder.Length; i++) {
            if (!string.IsNullOrEmpty(currentPlacedTubes[i]) && currentPlacedTubes[i].Contains(correctOrder[i])) {
                matchCount++;
            }
        }

        correctCount = matchCount;
        scoreText.text = "Score Progress:\n" + correctCount + "/3";

        if (correctCount == 3) {
            WinGame();
        }
    }

    void WinGame() {
        Debug.Log("Escape Unlocked!");
		// TODO: Open the door with confetti
		// TODO: Load a "Win" scene
    }
}