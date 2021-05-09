using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerThrowHandler : MonoBehaviour
{
    public bool isPowering;
    public float maxPower;
    public float currentPower;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPowering)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentPower += 0.5f;
            }

            currentPower -= 0.1f;
        }
    }


    public void PowerThrow()
    {
        //Add force to rugby ball
        isPowering = false;
    }
}
