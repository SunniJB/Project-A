using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
