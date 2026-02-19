using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    private int count = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddCollectible()
    {
        count++;
        scoreText.text = "Collectibles: " + count;
    }
}