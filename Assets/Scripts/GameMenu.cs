using UnityEngine;
using TMPro;

public class GameMenu : MonoBehaviour
{
    // Save Alpha Values
    private const float alpha0 = 0.0f;
    private const float alpha1 = 1.0f;

    // Delegate to Restart Game
    public delegate void Restart();

    [Header("Players")]
    [SerializeField]
    PlayerInput player1;
    [SerializeField]
    PlayerInput player2;

    [Header("Start")]
    [SerializeField]
    private CanvasGroup startPage;

    [Header("Health Bars")]
    [SerializeField]
    private CanvasGroup playerHealthBars;

    [Header("End")]
    [SerializeField]
    private CanvasGroup endPage;
    [SerializeField]
    private TextMeshProUGUI endText;

    // Instance of Delegate
    public Restart RestartGame;

    // Play Button
    public void StartGame()
    {
        // Enable Players
        playerHealthBars.alpha = alpha1;
        if (player1)
            player1.enabled = true;
        if (player2)
            player2.enabled = true;

        // Disable Start Page
        PageActive(startPage, false);
    }

    // End the Game
    public void EndGame(string loser)
    {
        // Disable Players
        playerHealthBars.alpha = alpha0;
        if (player1)
            player1.enabled = false;
        if (player2)
            player2.enabled = false;

        // Update End Text
        if (loser.Equals("Player 2"))
            endText.text = "Player 1 Wins!";
        else
            endText.text = "Player 2 Wins!";

        // Show End Page
        PageActive(endPage, true);
        endPage.interactable = true;
    }

    // Restart The Game
    public void PlayAgain()
    {
        // Enable Players
        playerHealthBars.alpha = alpha1;
        if (player1)
            player1.enabled = true;
        if (player2)
            player2.enabled = true;

        // Run Restart Game Delegate
        RestartGame();

        // Disable End Page
        PageActive(endPage, false);
        endPage.interactable = false;
    }

    // Set Page UI Page Active and Inactive
    private void PageActive(CanvasGroup page, bool active)
    {
        page.alpha = active ? alpha1 : alpha0;
        page.blocksRaycasts = active;
    }
}