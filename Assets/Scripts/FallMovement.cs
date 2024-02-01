using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallMovement : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;

    public void StartFalling(TransformManager transformManager)
    {
        StartCoroutine(Falling(transformManager));
    }

    private IEnumerator Falling(TransformManager transformManager)
    {
        if (transformManager.CharacterOnGround() == true)
            yield break;

        Vector3 velocity = Vector3.zero;

        while(transformManager.CharacterOnGround() == false)
        {
            velocity += Vector3.down * 9.8f * Time.deltaTime;

            characterTransform.position += velocity * Time.deltaTime;

            yield return null;
        }
    }
}
