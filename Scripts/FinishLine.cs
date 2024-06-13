using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string nextSceneName;
    public int requiredScore = 10; // Set the required score to transition to the next scene

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.GetScore() >= requiredScore)
            {
                Debug.Log("Score meets the required threshold. Starting scene transition.");
                StartCoroutine(LoadNextScene());
            }
            else
            {
                Debug.Log("Score does not meet the required threshold. Transition denied.");
                // Optionally, you can provide feedback to the player here.
            }
        }
    }

    private IEnumerator LoadNextScene()
    {
        Debug.Log("Loading next scene: " + nextSceneName);
        yield return SceneManager.LoadSceneAsync(nextSceneName);
        yield return new WaitForSeconds(0.1f); // Small delay to ensure all objects are initialized

        if (GameManager.Instance != null)
        {
            Debug.Log("Calling FindScoreText from FinishLine.");
            GameManager.Instance.FindScoreText();
            GameManager.Instance.ResetScore(); // Reset score for the new scene
        }
        else
        {
            Debug.LogError("GameManager instance is null after scene load.");
        }
    }
}
