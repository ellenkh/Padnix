using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject BallPrefab;
    public Transform BallSpawnPoint;
    public int MaxLives = 3;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverPanel;
    public TextMeshProUGUI FinalScoreText;
    public GameObject WinPanel;
    public TextMeshProUGUI WinScoreText;

    public Image[] Hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;

    private int currentScore;
    private int currentLives;
    private int currentCombo;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentLives = MaxLives;
        currentCombo = 0;
        currentScore = 0;
        UpdateScoreUI();
        UpdateHeartsUI();
        SpawnBall();
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke("SpawnBall", 1f); // Liten pause før respawn
        }
    }
    public void IncrementCombo()
    {
        currentCombo++;
    }

    public void ResetCombo()
    {
        currentCombo = 0;
    }

    public int GetCombo()
    {
        return currentCombo;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
    public void CheckWin()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            WinPanel.SetActive(true);
            WinScoreText.text = "Score: " + currentScore;
        }
    }
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreUI();
        Invoke("CheckWin", 0.1f);
    }
    void GameOver()
    {
        GameOverPanel.SetActive(true);
        FinalScoreText.text = "Score: " + currentScore;
    }
    void SpawnBall()
    {
        Instantiate(BallPrefab, BallSpawnPoint.position, Quaternion.identity);
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < currentLives)
                Hearts[i].sprite = HeartFull;
            else
                Hearts[i].sprite = HeartEmpty;
        }
    }

    void UpdateScoreUI()
    {
        if (ScoreText != null)
            ScoreText.text = "Poeng: " + currentScore;
    }
}
