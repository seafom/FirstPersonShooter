using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 

    public Text scoreText; 

    private int score = 0; // Current score

    private void Awake()
    {
        // Set up singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int amount)
    {
        score += amount; // Update the score
        scoreText.text = "Score: " + score.ToString(); // Update the score text on the UI
    }
}