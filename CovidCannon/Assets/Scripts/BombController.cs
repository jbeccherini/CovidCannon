using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    public Vector3 initialScaling = new Vector3(0.5f, 0.5f, 1);

    private GameObject[] tables;
    private GameObject[] unmasked;

    public float bombDistance = 5.0f;

    public static bool bombActive = false;

    void Start()
    {
        TargetController.setAiming(false);

        transform.localScale = initialScaling;

        startMarker = GameObject.Find("Cannon").transform;
        endMarker = GameObject.Find("Target").transform;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        bombActive = true;
        
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        float scaleModifier = (float)(-4*Mathf.Pow(fractionOfJourney - 0.5f, 2) + 2);


        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        transform.localScale = initialScaling * scaleModifier;

        if (transform.position == endMarker.position) 
        {
            tables = GameObject.FindGameObjectsWithTag("Table");
            unmasked = GameObject.FindGameObjectsWithTag("Unmasked");

            if (this.gameObject.tag == "DisinfectBomb")
            {
                for (int i = 0; i < tables.Length; i++) 
                {
                    //if (Vector3.Distance(this.transform.position, tables[i].transform.position) < bombDistance)
                    if (Vector2.Distance(this.transform.position, tables[i].transform.position) < bombDistance)
                    {
                        GameManager.changeScore(1);
                    }
                    //Debug.Log(Vector2.Distance(this.transform.position, tables[i].transform.position));
                }
            }
            else if (this.gameObject.tag == "MaskBomb")
            {
                for (int i = 0; i < unmasked.Length; i++)
                {
                    if (Vector2.Distance(this.transform.position, unmasked[i].transform.position) < bombDistance)
                    {
                        GameManager.changeScore(1);
                    }
                }
            }

            Destroy(this.gameObject);
            TargetController.setAiming(true);
            bombActive = false;
        }
    }
}
