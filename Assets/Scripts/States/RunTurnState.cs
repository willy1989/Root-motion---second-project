using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTurnState : StateMachineBehaviour
{
    private AnimationManager animationManager;
    private TransformManager transformManager;
    private InputManager inputManager;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManager = animator.gameObject.GetComponent<AnimationManager>();

        transformManager = animator.gameObject.GetComponent<TransformManager>();

        inputManager = animator.gameObject.GetComponent<InputManager>();

        animationManager.PlayAnimation("RunningTurning");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformManager.SetRotation();
    }

    private void CheckCondition(Animator animator)
    {
        if (animationManager.IsCurrentAnimationRunning() == false && (inputManager.MoveRightButton() == true || inputManager.MoveLeftButton() == true)  && inputManager.ShiftDown() == true)
        {
            animator.SetTrigger("Run");
        }

        else if(animationManager.IsCurrentAnimationRunning() == false && (inputManager.MoveRightButton() == true || inputManager.MoveLeftButton() == true))
        {
            animator.SetTrigger("Walk");
        }

        else if (animationManager.IsCurrentAnimationRunning() == false)
        {
            animator.SetTrigger("Idle");
        }
    }
}
