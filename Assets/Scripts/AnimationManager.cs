using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animationAnimator;

    private float defaultTransitionDuration = 0.3f;

    public void PlayAnimation(string animationName)
    {
        animationAnimator.Play(animationName);
        //animationAnimator.CrossFadeInFixedTime(animationName, defaultTransitionDuration);
    }

    public bool IsCurrentAnimationRunning()
    {
        AnimatorStateInfo stateInfo = animationAnimator.GetCurrentAnimatorStateInfo(0);

        return stateInfo.normalizedTime < 1.0f;
    }

    public bool IsInTransition()
    {
        return animationAnimator.IsInTransition(0);
    }
}
