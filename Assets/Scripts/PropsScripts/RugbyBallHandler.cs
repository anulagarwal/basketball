using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugbyBallHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float ballPassSpeed = 0f;
    #endregion

    #region MonoBehaviour Functions
    private void Update()
    {
        if (PassBall)
        {
            if (Vector3.Distance(transform.position, BallNewPositionTransform.position) >= 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, BallNewPositionTransform.position, Time.deltaTime * ballPassSpeed);
            }
            else
            {
                transform.parent = BallNewPositionTransform;
                PassBall = false;
            }
        }
    }
    #endregion

    #region Getter And Setter
    public bool PassBall { get; set; }

    public Transform BallNewPositionTransform { get; set; }
    #endregion
}
