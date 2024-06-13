using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationTrigger : MonoBehaviour
{
    public string[] conversationLines;
    public GameObject conversationPanel;
    public TextMeshProUGUI conversationText; // Use TextMeshProUGUI instead of Text

    private int currentLineIndex = 0;
    private bool isConversationActive = false;

    void Start()
    {
        // Hide the conversation panel at the start
        conversationPanel.SetActive(false);
    }

    void Update()
    {
        // Check for player input to advance the conversation
        if (isConversationActive && Input.GetKeyDown(KeyCode.Return))
        {
            AdvanceConversation();
        }
    }

    private void OnCollisionEnter2D( Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Assuming your main character has the tag "Player"
        {
            StartConversation();
        }
    }


    void StartConversation()
    {
        isConversationActive = true;
        conversationPanel.SetActive(true);
        currentLineIndex = 0;
        ShowCurrentLine();
    }

    void AdvanceConversation()
    {
        currentLineIndex++;
        if (currentLineIndex < conversationLines.Length)
        {
            ShowCurrentLine();
        }
        else
        {
            EndConversation();
        }
    }

    void ShowCurrentLine()
    {
        conversationText.text = conversationLines[currentLineIndex];
    }

    void EndConversation()
    {
        isConversationActive = false;
        conversationPanel.SetActive(false);
    }
}
