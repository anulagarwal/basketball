using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float aiSight = 0f;

    [Header("Component Reference")]
    [SerializeField] private Animator characterAnimator = null;
    [SerializeField] private CharacterController characterController = null;
    
    [Header("Gravity Setup")]
    [SerializeField] private float groundDistance = 0f;
    [SerializeField] private float gravityInfluence = -9.81f;
    [SerializeField] private Transform groundCheckTrans = null;
    [SerializeField] private LayerMask groundCheckLayerMask = 0;

    private bool grounded = false;
    private Vector3 velocity = Vector3.zero;
    private List<PlayerMovementHandler> teamAPlayerMovementHandlers = new List<PlayerMovementHandler>();
    private Transform targetTransform = null;
    #endregion

    #region Delegates
    private delegate void AIMovementMechanism();

    private AIMovementMechanism aiMovementMechanism;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        teamAPlayerMovementHandlers = LevelManager.Instance.GetTeamAPlayerMovementHandlers;
        aiMovementMechanism += AITargetFinder;
    }

    private void Update()
    {
        if (aiMovementMechanism != null)
        {
            aiMovementMechanism();
        }

        GravityMechanism();
    }
    #endregion

    #region Private Core Functions
    private void AITargetFinder()
    {
        foreach (PlayerMovementHandler pmh in teamAPlayerMovementHandlers)
        {
            if (Vector3.Distance(transform.position, pmh.transform.position) <= aiSight)
            {
                aiMovementMechanism = null;
                aiMovementMechanism += AIRugbyBallKeeperChase;
                aiMovementMechanism += AINavigation;

                SwitchCharacterAnimation(AICharacterAnimationState.Run);
            }
        }
    }

    private void GravityMechanism()
    {
        grounded = Physics.Raycast(groundCheckTrans.position, -groundCheckTrans.up, groundDistance, groundCheckLayerMask);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravityInfluence * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void AIRugbyBallKeeperChase()
    {
        foreach (PlayerMovementHandler pmh in teamAPlayerMovementHandlers)
        {
            if (TeamAHandler.Instance.RugbyBallKeeper)
            {
                targetTransform = TeamAHandler.Instance.RugbyBallKeeper;
                break;
            }
        }
    }

    private void AINavigation()
    {
        if (targetTransform != null)
        {
            Vector3 direction = (targetTransform.position - transform.position).normalized;
            characterController.Move(direction * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.LookRotation((targetTransform.position - transform.position));
        }
    }

    private void SwitchCharacterAnimation(AICharacterAnimationState state)
    {
        switch (state)
        {
            case AICharacterAnimationState.Idle:
                characterAnimator.SetBool("b_Run", false);
                break;
            case AICharacterAnimationState.Run:
                characterAnimator.SetBool("b_Run", true);
                break;
            case AICharacterAnimationState.Victory:
                characterAnimator.SetTrigger("t_Victory");
                characterAnimator.SetBool("b_Run", false);
                break;
        }
    }
    #endregion

    #region Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, aiSight);
    }
    #endregion
}
