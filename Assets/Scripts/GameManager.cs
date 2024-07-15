using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake() {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play() {
        SetScore(0);

        gameOver.SetActive(false);
        Unpause();

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    private void Pause() {
        Time.timeScale = 0f;
        playButton.SetActive(true);
        player.enabled = false;
    }

    private void Unpause() {
        Time.timeScale = 1f;
        playButton.SetActive(false);
        player.enabled = true;
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore() {
        SetScore(score + 1);
    }

    private void SetScore(int newScore) {
        this.score = newScore;
        scoreText.text = this.score.ToString();
    }
}
