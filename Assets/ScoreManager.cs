using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI References")]
    public Text player1Text;
    public Text player2Text;

    private int player1Score = 0;
    private int player2Score = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int playerId, int amount)
    {
        if (playerId == 1)
            player1Score += amount;
        else if (playerId == 2)
            player2Score += amount;

        UpdateUI();
    }

    void UpdateUI()
    {
        player1Text.text = "Player 1: " + player1Score;
        player2Text.text = "Player 2: " + player2Score;
    }
}