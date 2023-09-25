using UnityEngine;

public class Settings : MonoBehaviour
{
    public int controlScheme;
    public Animator keysAnimator;

    public void ChangeControlScheme()
    {
        if (keysAnimator == null)
        {
            Debug.Log("Keys animator is empty");
            keysAnimator = GameObject.Find("ControlKeys").GetComponent<Animator>();
        }
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
