using Unity.VisualScripting;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public int controlScheme;
    public Animator keysAnimator;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeControlScheme()
    {
        if (controlScheme == 0) 
        { 
            controlScheme = 1;
            if (keysAnimator != null)
            {
                keysAnimator.SetInteger("ControlScheme", controlScheme);
            }
            return; 
        }
        else if (controlScheme == 1) 
        { 
            controlScheme = 0;
            if (keysAnimator != null)
            {
                keysAnimator.SetInteger("ControlScheme", controlScheme);
            }
            return; 
        }
    }

}
