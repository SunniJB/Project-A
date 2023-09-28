using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas, title, subtitle;
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
        Time.timeScale = 0;
        title.GetComponent<TextMeshProUGUI>().text = "Game paused";
        subtitle.SetActive(true);
    }

    public void Unpause()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void ChangeObjective(string newObjective)
    {
        objectiveTextBox.GetComponent<TextMeshProUGUI>().text = newObjective;
    }
}
