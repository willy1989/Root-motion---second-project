using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private InputManager inputManager;

    private CharacterTransformManager transformManager;

    private AnimationManager animationManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputManager = animator.gameObject.GetComponent<InputManager>();
        animationManager = animator.gameObject.GetComponent<AnimationManager>();
        transformManager = animator.gameObject.GetComponent<CharacterTransformManager>();

        
        animationManager.PlayAnimation("Idling");

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    private void CheckCondition(Animator animator)
    {
        if (transformManager.CharacterLookingRight() == true && (inputManager.MoveRightButtonDown() == true || inputManager.MoveRightButton() == true))
        {
            animator.SetTrigger("Walk");
        }

        else if (transformManager.CharacterLookingLeft() == true && (inputManager.MoveLeftButtonDown() == true || inputManager.MoveLeftButton() == true))
        {
            animator.SetTrigger("Walk");
        }

        else if(transformManager.CharacterLookingRight() == true && inputManager.MoveLeftButton() == true)
        {
            animator.SetTrigger("Turn");
        }

        else if (transformManager.CharacterLookingLeft() == true && inputManager.MoveRightButton() == true)
        {
            animator.SetTrigger("Turn");
        }

        else if (inputManager.SpaceDown() == true)
        {
            animator.SetTrigger("Jump");
        }
    }
}
