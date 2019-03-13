using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor : MonoBehaviour
{
    Animator anim;

    //Use the LockManager script as a reference for the variables
    LockManager LM;
    bool isOpenable;

    void Start()
    {
        anim = GetComponent<Animator>();
        LM = GameObject.Find("Doors").GetComponent<LockManager>();
        isOpenable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOD: Collision Detection, " + isOpenable);
        //Check which door the script is on and get respective key variable from LockManager
        if (gameObject.name == "Door 01")
        {
            isOpenable = LM.GetKey01Pickuped();
            Debug.Log("TOD: Working, " + isOpenable);
        }
        else if (gameObject.name == "Door 02")
        {
            isOpenable = LM.GetKey02Pickuped();
            Debug.Log("TOD: Working, " + isOpenable);
        }
        else if (gameObject.name == "Door 03")
        {
            isOpenable = LM.GetKey03Pickuped();
            Debug.Log("TOD: Working, " + isOpenable);
        }
        else if (gameObject.name == "Door 04")
        {
            isOpenable = LM.GetKey04Pickuped();
            Debug.Log("TOD: Working, " + isOpenable);
        }
        else if (gameObject.name == "Door 05")
        {
            isOpenable = LM.GetKey05Pickuped();
            Debug.Log("TOD: Working, " + isOpenable);
        }

        if (isOpenable)
        {
            if (other.tag == "Player")
            {
                anim.SetTrigger("openAnim");
            }
            if (other.tag == "Robot1")
            {
                anim.SetTrigger("openAnim");
            }
            if (other.tag == "Robot2")
            {
                anim.SetTrigger("openAnim");
            }
            if (other.tag == "Robot3")
            {
                anim.SetTrigger("openAnim");
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.enabled = true;
        }
        if (other.tag == "Robot1")
        {
            anim.enabled = true;
        }
        if (other.tag == "Robot2")
        {
            anim.enabled = true;
        }
        if (other.tag == "Robot3")
        {
            anim.enabled = true;
        }
    }

    private void pauseAnimationEvent()
    {
        anim.enabled = false;
    }

}
