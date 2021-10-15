using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float slope = 0.125f;
    public float mouseXMax = 5f;
    public float mouseXMin = -5f;

    bool positioning = true;
    bool aiming = false;
    bool shooting = false;

    public float rotateMax = 60;
    public float rotateMin = -60;

    public float rotateAngle = 1;

    public float degreeStep = 5f;

    private float step;
    public float moveStep = .01f;

    public bool bombLoaded = true;

    public Transform target;
    public GameObject bomb;
    

    // Start is called before the first frame update
    void Start()
    {
        step = degreeStep * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition));
        //Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        float mouseX = worldPosition.x;

        if (mouseX < mouseXMax && mouseX > mouseXMin && positioning)
        {
            transform.position = new Vector3(mouseX, Mathf.Pow(mouseX, 2) * slope, transform.position.z);
        }

        if (positioning) 
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && TargetController.range < 12.5f)
            {
                TargetController.range += 2.5f;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && TargetController.range > 5f)
            {
                TargetController.range -= 2.5f;
            }
        }
        
        if (Input.GetMouseButton(0) && positioning)
        {
            positioning = false;
            aiming = true;
        }

        if (aiming)
        {
            transform.Rotate(Vector3.forward, step);
        }

        if (transform.rotation.z >= 0.35f || transform.rotation.z <= -0.35f && aiming)
        {
            step *= -1;
        }


        if (Input.GetMouseButtonUp(0) && aiming)
        {
            aiming = false;
            shooting = true;
        }

        if (shooting && Input.GetKeyDown(KeyCode.Space) && bombLoaded) 
        {
            
            Instantiate(bomb, this.transform);
        }


    }

    void shootBomb() 
    {
    
    }
}
