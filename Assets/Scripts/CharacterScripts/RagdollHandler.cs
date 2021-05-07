using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    #region Properties
    [Header("Ragdoll Setup")]
    [SerializeField] private float impactForce = 0f;
    [SerializeField] private GameObject ragdollObj = null;
    [SerializeField] private Animator characterAnimator = null;
    [SerializeField] private Rigidbody rbSpine = null;
    #endregion

    #region Public Core Functions
    public void EnableRagdoll(bool value)
    {
        ragdollObj.SetActive(value);
        characterAnimator.enabled = !value;
    }

    public void RagdollImpact(Vector3 impactDirection)
    {
        rbSpine.AddForce(impactDirection * impactForce, ForceMode.Impulse);
    }
    #endregion
}
