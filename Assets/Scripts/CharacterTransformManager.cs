using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterTransformManager : MonoBehaviour
{
    [SerializeField] private Transform animatedCharacterTransform;

    public Transform AnimatedCharacterTransform => animatedCharacterTransform;

    private bool isOnGround = true;

    public bool CharacterLookingRight()
    {
        float yRotation = animatedCharacterTransform.rotation.eulerAngles.y;

        // Assuming 0 is directly forward:
        if (yRotation >= 0 && yRotation < 90 || yRotation > 270 && yRotation < 360)
            return true;

        return false;
    }

    public bool CharacterLookingLeft()
    {
        float yRotation = animatedCharacterTransform.rotation.eulerAngles.y;

        // Assuming 0 is directly forward:
        if (yRotation >= 0 && yRotation < 90 || yRotation > 270 && yRotation < 360)
            return false;

        return true;
    }

    public bool CharacterOnGround()
    {
        return isOnGround;
    }

    public void ResetYPosition()
    {
        StartCoroutine(ResetYPositionCoroutine());
    }

    private IEnumerator ResetYPositionCoroutine()
    {
        yield return new WaitForEndOfFrame();

        float roundedYPosition = Mathf.RoundToInt(animatedCharacterTransform.position.y);

        animatedCharacterTransform.position = new Vector3(animatedCharacterTransform.position.x, roundedYPosition, animatedCharacterTransform.position.z);
    }

    public void ResetXPosition()
    {
        StartCoroutine(ResetXPositionCoroutine());
    }

    private IEnumerator ResetXPositionCoroutine()
    {
        yield return new WaitForEndOfFrame();

        animatedCharacterTransform.position = new Vector3(0f, animatedCharacterTransform.position.y, animatedCharacterTransform.position.z);
    }

    public void SetRotation()
    {
        StartCoroutine(SetRotationCoroutine());
    }

    private IEnumerator SetRotationCoroutine()
    {
        yield return new WaitForEndOfFrame();

        if (CharacterLookingRight() == true)
        {
            animatedCharacterTransform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (CharacterLookingLeft() == true)
        {
            animatedCharacterTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") == true)
            isOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground") == true)
            isOnGround = false;
    }
}
