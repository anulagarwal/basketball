using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    #region Properties
    public static LevelUIManager Instance = null;
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

    #region Btn Events Functions
    public void OnClick_EnableTeamAMovementHandlers()
    {
        LevelManager.Instance.GetPlacementHandler.StopPlacement();
        LevelManager.Instance.EnableTeamAPlayerMovementHandlers(true);
    }
    #endregion
}
