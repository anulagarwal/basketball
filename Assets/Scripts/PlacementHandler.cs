using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    #region Properties
    [SerializeField] private bool isPlacing = false;
    [SerializeField] private bool isSelectedCharacter = false;
    [SerializeField] private LayerMask lm = 0;

    private Transform selectedCharacter = null;
    #endregion

    #region MonoBehaviour Functions
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (isSelectedCharacter)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    print(hit.collider.gameObject.name);
                    selectedCharacter.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    isSelectedCharacter = false;
                }
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacing)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                   
                    if (hit.collider.tag == "Player")
                    {
                        SelectCharacter(hit.collider.transform);
                    }

                }
            }
        }
    }
    #endregion

    #region Public Core Functions
    public void StartPlacement()
    {
        isPlacing = true;
    }

    public void StopPlacement()
    {
        isPlacing = false;
    }

    public void SelectCharacter(Transform character)
    {
        selectedCharacter = character;
        isSelectedCharacter = true;
    }
    #endregion
}
