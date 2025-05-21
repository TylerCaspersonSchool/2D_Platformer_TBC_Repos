using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed;             //Speed of Platform
    public int startingPoint;       //Starting Position of Platform
    public Transform[] points;      //Point location for platform to move to

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; //Setting the position of the platform to the position of one of the points using index startingPoint

    }

    // Update is called once per frame
    void Update()
    {
        //Checks distance of platform to point
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //increase index
            if (i == points.Length) //check if platform was hit last point after index increase
            {
                i = 0; //reset index
            }
        }
        //Moving platform to point position with index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
