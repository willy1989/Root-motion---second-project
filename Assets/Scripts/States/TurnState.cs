using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnState : StateMachineBehaviour
{
    private AnimationManager animationManager;
    private TransformManager transformManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManager = animator.gameObject.GetComponent<AnimationManager>();

        transformManager = animator.gameObject.GetComponent<TransformManager>();

        animationManager.PlayAnimation("Turning");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformManager.SetRotation();

        transformManager.ResetXPosition();
    }

    private void CheckCondition(Animator animator)
    {
        if(animationManager.IsCurrentAnimationRunning() == false)
        {
            animator.SetTrigger("Idle");
        }
    }
}
