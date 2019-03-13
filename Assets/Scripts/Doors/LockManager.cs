using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    GameObject key01, key02, key03, key04, key05;
    GameObject door01, door02, door03, door04, door05;
    bool key01Acquired, key02Acquired, key03Acquired, key04Acquired, key05Acquired;
    int currentPoints;


    // Start is called before the first frame update
    void Start()
    {
        //Script KeyInteraction deals with the player and key interactions; if the player picks up the key,
        //then KeyInteraction will change the keyAcquired booleans to true in this script
        key01Acquired = false;
        key02Acquired = false;
        key03Acquired = false;
        key04Acquired = false;
        key05Acquired = false;
        currentPoints = 0;

        //Setting the GameObjects specifically to the keys in the inspector
        key01 = GameObject.Find("Key Card 01");
        key02 = GameObject.Find("Key Card 02");
        key03 = GameObject.Find("Key Card 03");
        key04 = GameObject.Find("Key Card 04");
        key05 = GameObject.Find("Key Card 05");
        door01 = GameObject.Find("Door 01");
        door02 = GameObject.Find("Door 02");
        door03 = GameObject.Find("Door 03");
        door04 = GameObject.Find("Door 04");
        door05 = GameObject.Find("Door 05");
    }

    //******Getters and Setters for the LockManager varaibles******
    //Setter for acquiring the key01
    public void SetPickupKey01(bool pickedUp)
    {
        key01Acquired = pickedUp;
    }

    public bool GetKey01Pickuped()
    {
        return key01Acquired;
    }

    //Setter and getter for key02
    public void SetPickupKey02(bool pickedUp)
    {
        key02Acquired = pickedUp;
    }

    public bool GetKey02Pickuped()
    {
        return key02Acquired;
    }

    //Setter and getter for key03
    public void SetPickupKey03(bool pickedUp)
    {
        key03Acquired = pickedUp;
    }

    public bool GetKey03Pickuped()
    {
        return key03Acquired;
    }

    //Setter and getter for key04
    public void SetPickupKey04(bool pickedUp)
    {
        key04Acquired = pickedUp;
    }

    public bool GetKey04Pickuped()
    {
        return key04Acquired;
    }

    //Setter and getter for key05
    public void SetPickupKey05(bool pickedUp)
    {
        key05Acquired = pickedUp;
    }

    public bool GetKey05Pickuped()
    {
        return key05Acquired;
    }

    //Setter and getter for points
    //Takes in the current count x and updates it for LockManager
    public void SetPointCount(int x)
    {
        currentPoints = x;
    }

    public int GetPointCount()
    {
        return currentPoints;
    }
}
