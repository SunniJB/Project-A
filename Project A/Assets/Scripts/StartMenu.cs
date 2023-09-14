using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject soundManager;

    public void PlaySounds(string name)
    {
        soundManager.GetComponent<SoundManager>().PlaySound(name);
    }

    public void StartButton()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Start");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
