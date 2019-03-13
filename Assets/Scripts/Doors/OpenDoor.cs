using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place script on the button
public class OpenDoor : MonoBehaviour
{
    //Booleans to show whether the player has acquired the keys
    bool key01Acquired;
    GameObject thisDoor, thisButton, lockScript;
    public Camera currentCamera;
    RaycastHit playerHit;

    //Use the LockManager script as a reference for the variables
    LockManager LM;

    void Start()
    {
        //Change accordingly to for each door and button pair
        thisButton = GameObject.Find("DoorButton 01");
        thisDoor = GameObject.Find("Door 01");
        key01Acquired = false;

        //Reference to the LockManager script (don't make an instance of it otherwise varables will not be saved globally)
        LM = GameObject.Find("Doors").GetComponent<LockManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = currentCamera.transform.TransformDirection(Vector3.forward);
        // draw Ray in scene view
        Debug.DrawRay(currentCamera.transform.position, fwd * 2, Color.green);
        if (Physics.Raycast(currentCamera.transform.position, fwd, out playerHit))
        {
            // distance to gameobject
            if (playerHit.distance <= 7.0f)
            {
                //Look at the reference variable to see if the key has been picked up
                key01Acquired = LM.GetKey01Pickuped();
                //Check the player targeted the button and is pressing the 'e' button
                if (playerHit.collider.gameObject == thisButton && Input.GetKeyDown("e"))
                {
                    //Code for opening the door
                    //activateButton = !activateButton;
                }
            }
        }
    }
}
