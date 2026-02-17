using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public string[] correctOrder = { "Tube_Red", "Tube_Blue", "Tube_Green" };
    public string[] currentPlacedTubes = new string[3];
    
    private int correctCount = 0;

	public GameObject leftDoor;
	public GameObject rightDoor;
	public float openDistance = 1.5f;
	public Light roomLight;
	public AudioSource doorAudio;

	private bool isWinTriggered = false;

    void Update() {
        CheckWinCondition();
    }

    void CheckWinCondition() {
		if (isWinTriggered) return;

        int matchCount = 0;

        for (int i = 0; i < correctOrder.Length; i++) {
            if (!string.IsNullOrEmpty(currentPlacedTubes[i]) && currentPlacedTubes[i].Contains(correctOrder[i])) {
                matchCount++;
            }
        }

        correctCount = matchCount;
        scoreText.text = "Score Progress:\n" + correctCount + "/3";

        if (correctCount == 3) {
			isWinTriggered = true;
			WinGame();
		}
    }

    void WinGame() {
        Debug.Log("Escape Unlocked!");
		// TODO: Open the door with confetti and Load a "Win" scene
		if (doorAudio != null) {
        	doorAudio.Play();
    	}

		if (leftDoor != null && rightDoor != null) {
			leftDoor.transform.position += new Vector3(-openDistance, 0, 0);
			rightDoor.transform.position += new Vector3(openDistance, 0, 0);
    	}

		if (roomLight != null) {
        	roomLight.color = Color.green;
    	}

		this.enabled = false;
    }
}