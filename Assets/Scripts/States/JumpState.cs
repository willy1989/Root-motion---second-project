using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    private AnimationManager animationManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManager = animator.gameObject.GetComponent<AnimationManager>();

        animationManager.PlayAnimation("JumpingUp");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    private void CheckCondition(Animator animator)
    {
        if (animationManager.IsCurrentAnimationRunning() == false)
        {
            animator.SetTrigger("Fall");
        }
    }
}
