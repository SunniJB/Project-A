using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas, title, subtitle, timerText, winCanvas, loseCanvas, soundManager;
    public GameObject objectiveTextBox;
    private bool paused = false;
    public float timer = 500f;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused == false) { Pause(); paused = !paused; return; }
            if (paused == true) { Unpause(); paused = !paused; return; }
            
        }

        if (!paused && SceneManager.GetActiveScene().buildIndex == 1)
        {
            timer = timer -= Time.deltaTime;
        }
        if (timer <= 0)
        { 
            Lose();
        }

        if (timerText == null)
        {
            timerText = GameObject.Find("TimeText");
        }
        if (timerText != null)
        {
            timerText.GetComponent<TextMeshProUGUI>().text = timer.ToString("F0");
        }
        
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        title.GetComponent<TextMeshProUGUI>().text = "Game paused";
        subtitle.SetActive(true);
    }

    public void Unpause()
    {
        pauseCanvas.SetActive(false);
    }

    public void ChangeObjective(string newObjective)
    {
        objectiveTextBox.GetComponent<TextMeshProUGUI>().text = newObjective;
    }

    public void Win()
    {
        winCanvas.SetActive(true);
        soundManager.GetComponent<SoundManager>().PlaySound("Win Sound");
        timer = 10000000f;
    }
    public void Lose()
    {
        loseCanvas.SetActive(true);
        soundManager.GetComponent<SoundManager>().PlaySound("Lose sound");
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        timer = 50;
    }
}
