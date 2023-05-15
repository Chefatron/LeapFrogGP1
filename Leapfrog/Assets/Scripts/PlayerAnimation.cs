using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private string AnimationState;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeAnimationState(string _NewState)
    {
        if (AnimationState == _NewState)
        {
            return;
        }
        else
        {
            animator.Play(_NewState);
            AnimationState = _NewState;
        }
    }
}
