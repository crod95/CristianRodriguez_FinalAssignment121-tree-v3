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
    public GameObject door01, door02, door03, door04, door05;
    public bool key01Acquired, key02Acquired, key03Acquired, key04Acquired, key05Acquired;
    public GameObject key01, key02, key03, key04, key05;
    public GameObject keyEffect;

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

    private void Start()
    {
        pointCount = 0;
        key01Acquired = false;
        key02Acquired = false;
        key03Acquired = false;
        key04Acquired = false;
        key05Acquired = false;
        //key01 = GameObject.Find("Key Card 01");
        //key05 = GameObject.Find("");
        //key05 = GameObject.Find("");
        //key05 = GameObject.Find("");
        //key05 = GameObject.Find("");
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //testObject = GameObject.FindGameObjectWithTag("Test");

        keyEffect = GameObject.Find("Key Effect");
        me = GetComponent<Rigidbody>();
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
            Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            Debug.Log("Key 1 acquired: " + key01Acquired);
        }
        /*
        //Picking up Key card 02 to open the second door
        if (other == key02)
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key02Acquired = true;
            other.gameObject.SetActive(false);
        }
        //Picking up Key card 03 to open the third door
        if (other == key03)
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key03Acquired = true;
            other.gameObject.SetActive(false);
        }
        //Picking up Key card 04 to open the fourth door
        if (other == key04)
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key04Acquired = true;
            other.gameObject.SetActive(false);
        }
        //Picking up Key card 05 to open the fifth door
        if (other == key05)
        {
            //Instantiate(keyEffect, other.transform.position, other.transform.rotation);
            key05Acquired = true;
            other.gameObject.SetActive(false);
        }
        */
    }

    //OnCollisionStay is called once per frame for every collider/rigidbody that is touching rigidbody/collider.
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    /*
     * Link: https://gamedev.stackexchange.com/questions/89693/how-could-i-constrain-player-movement-to-the-surface-of-a-3d-object-using-unity
    private void UpdatePlayerTransform(Vector3 movementDirection)
    {
        RaycastHit hitInfo;

        if (GetRaycastDownAtNewPosition(movementDirection, out hitInfo))
        {
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, float.PositiveInfinity);

            transform.rotation = finalRotation;
            transform.position = hitInfo.point + hitInfo.normal * .5f;
        }
    }

    private bool GetRaycastDownAtNewPosition(Vector3 movementDirection, out RaycastHit hitInfo)
    {
        Vector3 newPosition = transform.position;
        Ray ray = new Ray(transform.position + movementDirection * Speed, -transform.up);

        if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, WorldLayerMask))
        {
            return true;
        }

        return false;
    }
    */
}