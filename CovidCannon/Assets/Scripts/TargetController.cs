using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static float range = 7.5f;
    public Transform cannon;

    public static bool aiming = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CannonController.shootingRange) 
        {
            this.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            this.GetComponent<Renderer>().enabled = false;
        }


        if(aiming) 
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }

        
        //transform.position = getTargetPositionFromCannon();
    }

    Vector3 getTargetPositionFromCannon() 
    {  
        var oppositeLength = range * Mathf.Sin(cannon.rotation.z);
        var adjacentLength = range * Mathf.Cos(cannon.rotation.z);

        Vector3 targetPos = new Vector3(cannon.position.x - oppositeLength, cannon.position.y + adjacentLength, cannon.position.z);

        return targetPos;
    }

    public static void setAiming(bool value) 
    {
        aiming = value;
    }
}
