using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceHandler : MonoBehaviour
{
    #region Properties
    [Header("Component Reference")]
    [SerializeField] private Animator audienceAnimator = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        audienceAnimator.SetInteger("i_CheerIndex", Random.Range(1, 7));
    }
    #endregion
}
