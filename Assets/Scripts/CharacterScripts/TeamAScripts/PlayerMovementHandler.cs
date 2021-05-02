using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 0f;

    [Header("Component Reference")]
    [SerializeField] private Animator characterAnimator = null;
    [SerializeField] private CharacterController characterController = null;
    [SerializeField] private Transform ballHolder = null;

    [Header("Gravity Setup")]
    [SerializeField] private float groundDistance = 0f;
    [SerializeField] private float gravityInfluence = -9.81f;
    [SerializeField] private Transform groundCheckTrans = null;
    [SerializeField] private LayerMask groundCheckLayerMask = 0;

    private bool grounded = false;
    private Vector3 velocity = Vector3.zero;
    private PlayerCharacterAnimationState playerCharacterAnimationState = PlayerCharacterAnimationState.Idle;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        playerCharacterAnimationState = PlayerCharacterAnimationState.Run;
        SwitchAnimation();
    }

    private void Update()
    {
        if (playerCharacterAnimationState == PlayerCharacterAnimationState.Run)
        {
            Navigation();
        }

        GravityMechanism();
    }

    private void OnMouseDown()
    {
        TeamAHandler.Instance.PassBall(ballHolder);
    }
    #endregion

    #region Private Core Functions
    private void Navigation()
    {
        characterController.Move(Vector3.forward * Time.deltaTime * moveSpeed);
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
    #endregion

    #region Public Core Functions
    public void SwitchAnimation()
    {
        switch (playerCharacterAnimationState)
        {
            case PlayerCharacterAnimationState.Idle:
                characterAnimator.SetBool("b_Run", false);
                break;
            case PlayerCharacterAnimationState.Run:
                characterAnimator.SetBool("b_Run", true);
                break;
            case PlayerCharacterAnimationState.Throw:
                characterAnimator.SetBool("b_Run", false);
                characterAnimator.SetTrigger("t_Throw");
                break;
            case PlayerCharacterAnimationState.Victory:
                characterAnimator.SetBool("b_Run", false);
                characterAnimator.SetTrigger("t_Victory");
                break;
        }
    }
    #endregion
}
