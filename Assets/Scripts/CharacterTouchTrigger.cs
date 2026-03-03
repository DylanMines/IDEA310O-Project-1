using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTouchTrigger : MonoBehaviour
{
    private int score = 0;
    public int highScore = 2;
    public Animation a;
    public Door doorScript;
    public TextMeshProUGUI scoreCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectables"))
        {
            incrementScore();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("kill"))
        {
            kill();
        }
    }

    public void Start()
    {
        scoreCounter.SetText("Keys Aquired: 0/" + highScore);
    }

    public void Update()
    {
        if (transform.position.y < -200)
        {
            kill();
        }
    }
    private void incrementScore()
    {
        score++;
        scoreCounter.SetText("Keys Aquired: " + score + "/" + highScore);
        if (score == highScore)
        {
            a.Play();
            doorScript.levelComplete = true;
        }
    }

    private void kill()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
