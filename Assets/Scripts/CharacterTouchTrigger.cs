using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTouchTrigger : MonoBehaviour
{
    private int score = 0;
    private int highScore = 2;
    public Door doorScript;
    public Animation a;
    public AudioSource death;
    public AudioSource collect;
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
        Time.timeScale = 1;
        highScore = GameObject.FindGameObjectsWithTag("Collectables").Length;
        scoreCounter.SetText("Keys Aquired: 0/" + highScore);
    }

    public void Update()
    {
        if (transform.position.y < -100)
        {
            kill();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    private void incrementScore()
    {
        collect.Play();
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
        
        death.Play();
        float timeDelay = 0.3F;
        Invoke("ReloadScene", timeDelay);
        Time.timeScale = 0.1F;

        
    }

    private void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
