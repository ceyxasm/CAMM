using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score = 0;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Preserve this GameObject across scenes
            Debug.Log("GameManager initialized and set to DontDestroyOnLoad.");
        }
        else
        {
            Debug.Log("GameManager instance already exists. Destroying duplicate.");
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Aura: " + score;
            Debug.Log("Score text updated: " + scoreText.text);
        }
        else
        {
            Debug.LogWarning("Score text reference is null.");
        }
    }

    public void FindScoreText()
    {
        Debug.Log("FindScoreText called.");
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("ScoreText object not found in the scene.");
        }
        UpdateScoreText();
        Debug.Log("Score text found and updated.");
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
