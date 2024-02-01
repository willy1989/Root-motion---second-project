using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : StateMachineBehaviour
{
    private TransformManager transformManager;

    private AnimationManager animationManager;

    private FallMovement fallMovement;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformManager = animator.gameObject.GetComponent<TransformManager>();
        animationManager = animator.gameObject.GetComponent<AnimationManager>();
        fallMovement = animator.gameObject.GetComponent<FallMovement>();

        fallMovement.StartFalling(transformManager);

        animationManager.PlayAnimation("Falling");
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    private void CheckCondition(Animator animator)
    {
        if(transformManager.CharacterOnGround() == true)
        {
            animator.SetTrigger("Land");
        }
    }

}
