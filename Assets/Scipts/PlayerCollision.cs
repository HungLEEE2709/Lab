using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameManager gameManager;
    private bool hasKey = false;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(1);
        }
        else if (collision.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("SavedScore", gameManager.score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level2");
            Debug.Log("Đã nhặt chìa khóa");
        }
        else if (collision.CompareTag("traps"))
        {
            gameManager.GameOver();
        }
    }
}
