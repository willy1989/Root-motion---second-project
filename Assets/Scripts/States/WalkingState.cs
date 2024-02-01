using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : StateMachineBehaviour
{
    private AnimationManager animationManager;
    private InputManager inputManager;
    private CharacterTransformManager transformManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManager = animator.gameObject.GetComponent<AnimationManager>();
        inputManager = animator.gameObject.GetComponent<InputManager>();
        transformManager = animator.gameObject.GetComponent<CharacterTransformManager>();

        animationManager.PlayAnimation("Walking");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);

        transformManager.ResetXPosition();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformManager.ResetXPosition();
    }

    private void CheckCondition(Animator animator)
    {
        if (transformManager.CharacterOnGround() == false)
        {
            animator.SetTrigger("Fall");
        }

        else if (inputManager.SpaceDown() == true)
        {
            animator.SetTrigger("Jump");
        }

        else if (transformManager.CharacterLookingRight() == true && inputManager.MoveRightButton() == true && inputManager.Shift() == true)
        {
            animator.SetTrigger("Run");
        }

        else if (transformManager.CharacterLookingLeft() == true && inputManager.MoveLeftButton() == true && inputManager.Shift() == true)
        {
            animator.SetTrigger("Run");
        }

        else if (inputManager.MoveRightButtonUp() == true || inputManager.MoveLeftButtonUp() == true)
        {
            animator.SetTrigger("Idle");
        }
    }
}
