using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICollisionEventsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private RagdollHandler ragdollHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Working");

            ragdollHandler.EnableRagdoll(true);
            ragdollHandler.RagdollImpact((collision.gameObject.transform.position - transform.position).normalized);
        }
    }
    #endregion
}
