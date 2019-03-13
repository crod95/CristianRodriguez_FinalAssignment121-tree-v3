using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    //Speed of the movement
    public float speed = 1f;
    
    //How high the object bobs up and down
    public float height = 0.05f;
    public float range = 0.4f;

    private void OnEnable()
    {
        height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //rotates 50 degrees per second around x, y, and z axis
        transform.Rotate(0, 0, 50 * Time.deltaTime);
        
        //Gets the position of the Ofuda
        Vector3 pos = transform.position;
        //Calculate the bobbing effect over time
        float newY = range * Mathf.Sin(Time.time * speed) + height;
        //set the new height of the ofuda
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        //transform.Rotate(Vector3.up * Time.deltaTime);
    }
}