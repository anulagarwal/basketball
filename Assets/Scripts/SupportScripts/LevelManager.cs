using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Properties
    public static LevelManager Instance = null;

    [Header("Components Reference")]
    [SerializeField] private PlacementHandler placementHandler = null;

    [Header("TeamA Settings")]
    [SerializeField] private List<PlayerMovementHandler> teamAPlayerMovementHandlers = new List<PlayerMovementHandler>();
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
        EnableTeamAPlayerMovementHandlers(false);
    }
    #endregion

    #region Getter And Setter
    public PlacementHandler GetPlacementHandler { get => placementHandler; }
    #endregion

    #region Public Core Functions
    public void EnableTeamAPlayerMovementHandlers(bool value)
    {
        foreach (PlayerMovementHandler p in teamAPlayerMovementHandlers)
        {
            p.enabled = value;
        }
    }
    #endregion
}
