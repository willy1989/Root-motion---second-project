using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunJumpState : StateMachineBehaviour
{
    private AnimationManager animationManager;
    private TransformManager transformManager;
    private InputManager inputManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManager = animator.gameObject.GetComponent<AnimationManager>();
        transformManager = animator.gameObject.GetComponent<TransformManager>();
        inputManager = animator.gameObject.GetComponent<InputManager>();

        animationManager.PlayAnimation("RunningJumping");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformManager.ResetXPosition();

        transformManager.ResetYPosition();
    }

    private void CheckCondition(Animator animator)
    {
        if (animationManager.IsCurrentAnimationRunning() == false && transformManager.CharacterOnGround() == false)
        {
            animator.SetTrigger("Fall");
        }

        else if (animationManager.IsCurrentAnimationRunning() == false && inputManager.MoveRightButton() == true && inputManager.Shift() == true)
        {
            animator.SetTrigger("Run");
        }

        else if (animationManager.IsCurrentAnimationRunning() == false && inputManager.MoveLeftButton() == true && inputManager.Shift() == true)
        {
            animator.SetTrigger("Run");
        }

        else if (animationManager.IsCurrentAnimationRunning() == false && inputManager.MoveRightButton() == true)
        {
            animator.SetTrigger("Walk");
        }

        else if (animationManager.IsCurrentAnimationRunning() == false && inputManager.MoveLeftButton() == true)
        {
            animator.SetTrigger("Walk");
        }

        else if (animationManager.IsCurrentAnimationRunning() == false && transformManager.CharacterOnGround() == true)
        {
            animator.SetTrigger("Idle");
        }
    }
}
