using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITriggerEventsHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private RagdollHandler ragdollHandler = null;
    [SerializeField] private AIMovementHandler aiMovementHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (aiMovementHandler.GetTargetTransform != TeamAHandler.Instance.RugbyBallKeeper)
            {
                aiMovementHandler.enabled = false;

                ragdollHandler.EnableRagdoll(true);
                ragdollHandler.RagdollImpact((other.gameObject.transform.position - transform.position).normalized);
            }
            else
            {
                print(TeamAHandler.Instance.RugbyBallKeeper.name);
                print("GameOver!");
            }
        }
    }
    #endregion
}
