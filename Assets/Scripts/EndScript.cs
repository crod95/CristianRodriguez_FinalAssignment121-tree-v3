using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Robot1")
        {
            Debug.Log("Ending Game");
            Application.Quit();
        }
    }
}
