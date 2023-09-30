using UnityEngine;

public class GoThroughDoor : MonoBehaviour
{
    [SerializeField] GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.Win();
        }
    }
}
