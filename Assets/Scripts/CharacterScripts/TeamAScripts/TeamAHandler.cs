using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAHandler : MonoBehaviour
{
    #region Properties
    public static TeamAHandler Instance = null;

    [Header("Team Settings")]
    [SerializeField] private RugbyBallHandler rugbyBallHandler = null;
    [SerializeField] private List<RugbyBallKeeper> rugbyBallKeepers = new List<RugbyBallKeeper>();
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    #endregion

    #region Public Core Functions
    public void PassBall(Transform targetPositionTransform)
    {
        rugbyBallHandler.transform.parent = null;
        rugbyBallHandler.BallNewPositionTransform = targetPositionTransform;
        rugbyBallHandler.PassBall = true;
    }
    #endregion
}
