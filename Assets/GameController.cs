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


    public Image[] Hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;

    private int currentScore;
    private int currentLives;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentLives = MaxLives;
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
            Debug.Log("Game Over!");
            // Vi legger til game over-skjerm senere
        }
        else
        {
            Invoke("SpawnBall", 1f); // Liten pause før respawn
        }
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
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (ScoreText != null)
            ScoreText.text = "Poeng: " + currentScore;
    }
}
