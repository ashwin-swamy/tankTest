using System.Collections;
using UnityEngine;
using TMPro;

public class GameMenu : MonoBehaviour
{
    private const float alpha0 = 0.0f;
    private const float alpha1 = 1.0f;

    public delegate void Restart();

    [SerializeField]
    PlayerInput player1;
    [SerializeField]
    PlayerInput player2;

    [SerializeField]
    private CanvasGroup startPage;
    [SerializeField]
    private CanvasGroup endPage;
    [SerializeField]
    private TextMeshProUGUI endText;

    public Restart RestartGame;

    public void StartGame()
    {
        PageActive(startPage, false);
        if (player1)
            player1.enabled = true;
        if (player2)
            player2.enabled = true;
    }

    public void EndGame(string loser)
    {
        if (loser.Equals("Player 2"))
            endText.text = "Player 1 Wins!";
        else
            endText.text = "Player 2 Wins!";

        if (player1)
            player1.enabled = false;
        if (player2)
            player2.enabled = false;

        PageActive(endPage, true);
        endPage.interactable = true;
    }

    public void PlayAgain()
    {
        RestartGame();
        if (player1)
            player1.enabled = true;
        if (player2)
            player2.enabled = true;

        PageActive(endPage, false);
        endPage.interactable = false;
    }

    private void PageActive(CanvasGroup page, bool active)
    {
        page.alpha = active ? alpha1 : alpha0;
        page.blocksRaycasts = active;
    }
}