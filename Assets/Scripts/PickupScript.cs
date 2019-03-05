using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //rotates 50 degrees per second around x, y, and z axis
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
}