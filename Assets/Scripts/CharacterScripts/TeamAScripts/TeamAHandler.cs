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

    [Header("Temp Variables")]
    [SerializeField] private Transform ballKeeperTemp = null;
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

    private void Start()
    {
        //Testing
        RugbyBallKeeper = ballKeeperTemp;
    }
    #endregion

    #region Getter And Setter
    public Transform RugbyBallKeeper { get; set; }
    #endregion

    #region Public Core Functions
    public void PassBall(Transform targetPositionTransform, Transform playerTransform)
    {
        RugbyBallKeeper = playerTransform;

        rugbyBallHandler.transform.parent = null;
        rugbyBallHandler.BallNewPositionTransform = targetPositionTransform;
        rugbyBallHandler.PassBall = true;
    }
    #endregion
}
