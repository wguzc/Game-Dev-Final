using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";

    void Start()
    {
        ChangeAnimationState(currentState);
        //animationStateChanger.ChangeAnimationState("NewAnimationStateName", 1.0f);

    }


    void Update(){

    }

    public void ChangeAnimationState(string newAnimationState, float speed = 1)
    {
        animator.speed = speed;

        if(newAnimationState == currentState){
            return;
        }

        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }

}
