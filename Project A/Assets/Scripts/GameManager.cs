using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas, title, subtitle, winCanvas, loseCanvas, soundManager;
    public GameObject objectiveTextBox;
    private bool paused = false;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused == false) { Pause(); paused = !paused; return; }
            if (paused == true) { Unpause(); paused = !paused; return; }
            
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
    }
    public void Lose()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
