using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score =0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject GameOverUI;
    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("SavedScore"))
        {
            score = PlayerPrefs.GetInt("SavedScore");
            PlayerPrefs.DeleteKey("SavedScore");
        }

        UpdateScore();
        GameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0; 
        GameOverUI.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver=false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public void ExitGame()
    {
        Debug.Log("Thoát game...");
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
