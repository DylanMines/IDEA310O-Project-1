using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTouchTrigger : MonoBehaviour
{
    private int score = 0;
    public int highScore = 1;
    public string nextScene = "";
    public TextMeshProUGUI scoreCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectables"))
        {
            incrementScore();
            Destroy(other.gameObject);
        }
    }

    public void Start()
    {
        scoreCounter.SetText("Keys Aquired: 0/" + highScore);
    }
    private void incrementScore()
    {
        score++;
        scoreCounter.SetText("Keys Aquired: " + score + "/" + highScore);
        if (score == highScore)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
