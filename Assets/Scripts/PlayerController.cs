using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//In Unity, the constraints changed so that the y position is frozen and the x and z rotations are frozen
//Change mass and drag as desired depending on how you want the player to move

//Attach to the player
//After making the multiple controllable androids, probably have to make an Android manager to keep track
//of all of the player's assets and items and a separate script for controls of each android
public class PlayerController : MonoBehaviour
{
    //Keeps track of the amount of points that the player has picked up and the number of androids he/she has
    private int pointCount, activeAndroids;
    GameObject door01, door02, door03, door04, door05;
    public bool key01Acquired, key02Acquired, key03Acquired, key04Acquired, key05Acquired;
    Transform doorTransform;
    GameObject key01, key02, key03, key04, key05;
    GameObject keyEffect, pointEffect;

    //Use the LockManager script as a reference for the variables
    LockManager LM;

    //Used for debugging
    public GameObject testObject;

    //Main controls for the android characters
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float moveSpeed = 10;
    public float rotationSpeed = 360;
    public float jumpForce = 20f;
    public float distToGround = 0.5f;
    public bool isGrounded;

    //Reference to the rigidbody to use later in implementation
    Rigidbody me;
    public Vector3 jump;

    //Animator
    Animator charAnim; 

    private void Start()
    {
        pointCount = 0;
        key01Acquired = false;
        key02Acquired = false;
        key03Acquired = false;
        key04Acquired = false;
        key05Acquired = false;
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //Reference to the LockManager script (don't make an instance of it otherwise varables will not be saved globally)
        LM = GameObject.Find("Doors").GetComponent<LockManager>();

        //testObject = GameObject.FindGameObjectWithTag("Test");

        keyEffect = GameObject.Find("Key Effect");
        pointEffect = GameObject.Find("Point Effect");
        me = GetComponent<Rigidbody>();

        //Amimations
        charAnim = GameObject.FindWithTag("Robot1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //variables to hold the input for turning and moving
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        //function called whenever the user is trying to move or turn
        ApplyInput(moveAxis, turnAxis);
        JumpUp();
        charAnim.SetTrigger("breathe");
    }

    //Add extra gravity to the player
    private void FixedUpdate()
    {
        //me.AddForce(Physics.gravity * me.mass * 10);
    }

    private void ApplyInput(float input1, float input2)
    {
        //input1 represents input for moving while input2 represents input for turning
        movePlayer(input1);
        turnPlayer(input2);
        //charAnim.SetTrigger("locomotion");
    }

    //Function that handles moving the player's character around
    private void movePlayer(float moveInput)
    {
        me.AddForce(transform.forward * moveInput * moveSpeed, ForceMode.Force);
        
        // Debug.Log("Move Pressed");
    }

    //Function that handles turning the player's character
    private void turnPlayer(float turnInput)
    {
        transform.Rotate(0, turnInput * rotationSpeed * Time.deltaTime, 0);
        //Debug.Log("Turn Pressed");
    }

    private void JumpUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            charAnim.SetTrigger("jump");
            me.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision Detected");
        //Picking up Key card 01 to open the first door
        if (other.gameObject.name == "Key Card 01")
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key01Acquired = true;
            LM.SetPickupKey01(true);
            Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            Debug.Log("Key 1 acquired: " + key01Acquired);
        }
        
        //Picking up Key card 02 to open the second door
        if (other.gameObject.name == "Key Card 02")
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key02Acquired = true;
            LM.SetPickupKey02(true);
            Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            Debug.Log("Key 2 acquired: " + key02Acquired);
        }
        //Picking up Key card 03 to open the third door
        if (other.gameObject.name == "Key Card 03")
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key03Acquired = true;
            LM.SetPickupKey03(true);
            Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            Debug.Log("Key 3 acquired: " + key03Acquired);
        }
        //Picking up Key card 04 to open the fourth door
        if (other.gameObject.name == "Key Card 04")
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key04Acquired = true;
            LM.SetPickupKey04(true);
            Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            Debug.Log("Key 4 acquired: " + key04Acquired);
        }
        //Picking up Key card 05 to open the fifth door
        if (other.gameObject.name == "Key Card 05")
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key05Acquired = true;
            LM.SetPickupKey05(true);
            Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            Debug.Log("Key 5 acquired: " + key05Acquired);
        }

        if (other.gameObject.CompareTag("Point"))
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            pointCount++;
            LM.SetPointCount(pointCount);
            Instantiate(pointEffect, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            Debug.Log("Point Count: " + pointCount);
        }
    }

    //OnCollisionStay is called once per frame for every collider/rigidbody that is touching rigidbody/collider.
    void OnCollisionStay()
    {
        isGrounded = true;
    }
}