using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public Vector3 target;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(35, this.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private Transform startMarker;
    private Vector3 endMarker;
    public float speed = 10.0F;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startMarker = this.transform;
        endMarker = new Vector3(35f, this.transform.position.y, 0f);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker);

    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;
        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startMarker.position, endMarker, fractionOfJourney);

        if (transform.position == endMarker)
        {
            Destroy(this.gameObject);
        }
    }

}
*/