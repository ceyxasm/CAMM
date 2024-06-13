using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("S1-IITJD"); // Replace "GameScene" with the name of your main game scene
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        #if UNITY_EDITOR
        // Stop playing the scene in the Unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
