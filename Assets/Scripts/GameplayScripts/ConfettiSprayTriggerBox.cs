using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiSprayTriggerBox : MonoBehaviour
{
    #region Properties
    [Header("Component Reference")]
    [SerializeField] private List<ParticleSystem> confettiPSPack = new List<ParticleSystem>();
    #endregion

    #region MonoBehaviour Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (ParticleSystem ps in confettiPSPack)
            {
                ps.Play();
            }
        }
    }
    #endregion
}
