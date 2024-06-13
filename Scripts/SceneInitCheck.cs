using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public GameObject pauseMenuPrefab; // Reference to the pause menu prefab

    private static GameObject pauseMenuInstance; // Static instance to ensure only one instance exists

    private void Start()
    {
        Debug.Log("SceneInitializer Start called.");
        
        // Initialize GameManager if it exists
        if (GameManager.Instance != null)
        {
            Debug.Log("Calling FindScoreText from SceneInitializer.");
            GameManager.Instance.FindScoreText();
            GameManager.Instance.ResetScore(); // Ensure score starts at 0
        }
        else
        {
            Debug.LogError("GameManager instance is null in SceneInitializer.");
        }

        // Initialize Pause Menu if it doesn't exist
        if (pauseMenuInstance == null && pauseMenuPrefab != null)
        {
            Debug.Log("Instantiating Pause Menu.");
            pauseMenuInstance = Instantiate(pauseMenuPrefab);
            DontDestroyOnLoad(pauseMenuInstance);
        }
    }
}
