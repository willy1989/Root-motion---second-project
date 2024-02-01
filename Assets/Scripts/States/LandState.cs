using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandState : StateMachineBehaviour
{
    private AnimationManager animationManager;
    private CharacterTransformManager transformManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManager = animator.gameObject.GetComponent<AnimationManager>();
        transformManager = animator.gameObject.GetComponent<CharacterTransformManager>();

        animationManager.PlayAnimation("Landing");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformManager.ResetYPosition();
    }

    private void CheckCondition(Animator animator)
    {
        if (animationManager.IsCurrentAnimationRunning() == false)
        {
            animator.SetTrigger("Idle");
        }
    }
}
