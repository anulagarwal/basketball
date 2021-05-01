using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    [SerializeField] public bool isPlacing;
    [SerializeField] public bool isSelectedCharacter;
    public LayerMask lm;

    private Transform selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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


}
