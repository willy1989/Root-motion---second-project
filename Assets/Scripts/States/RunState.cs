using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateMachineBehaviour
{
    private AnimationManager animationManager;
    private TransformManager transformManager;
    private InputManager inputManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManager = animator.gameObject.GetComponent<AnimationManager>();
        inputManager = animator.gameObject.GetComponent<InputManager>();
        transformManager = animator.gameObject.GetComponent<TransformManager>();

        animationManager.PlayAnimation("Running");
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
            animator.SetTrigger("RunJump");
        }

        else if (inputManager.MoveRightButtonUp() == true || inputManager.MoveLeftButtonUp() == true)
        {
            animator.SetTrigger("Idle");
        }

        else if (transformManager.CharacterLookingRight() == true && inputManager.MoveLeftButtonDown() == true)
        {
            animator.SetTrigger("RunTurn");
        }

        else if (transformManager.CharacterLookingLeft() == true && inputManager.MoveRightButtonDown() == true)
        {
            animator.SetTrigger("RunTurn");
        }

        else if (inputManager.ShiftUp() == true)
        {
            animator.SetTrigger("Walk");
        } 
    }
}
