using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController2 : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;
    Rigidbody playerRigidbody;
    Vector3 moveVelocity;
    Vector3 turnVelocity;
    public GameObject targetPlayer;
    public float launchForce = 700f;
    public float launchRange = 5f;
    private bool canLaunch = false;
    private Collider otherPlayerCollider;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    bool isGrounded()
    {
        float distanceToGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    void Update()
    {
        float hInput = 0;
    float vInput = 0;

    if (Input.GetKey(KeyCode.J))
    {
        hInput = -1;
    }
    if (Input.GetKey(KeyCode.L))
    {
        hInput = 1;
    }
    if (Input.GetKey(KeyCode.I))
    {
        vInput = 1;
    }
    if (Input.GetKey(KeyCode.K))
    {
        vInput = -1;
    }
    moveVelocity = (transform.forward * vInput + transform.right * hInput) * speed;
     if (isGrounded() && Input.GetKeyDown(KeyCode.U))
        {
            
               playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);


        if(canLaunch && Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("launching");
            Rigidbody otherPlayerRb = targetPlayer.GetComponent<Rigidbody>();
            Vector3 explosionPosition = transform.position;
            float explosionRadius = launchRange;
            otherPlayerRb.AddExplosionForce(launchForce, explosionPosition, explosionRadius, 0.0f, ForceMode.Impulse);
            otherPlayerRb.centerOfMass = Vector3.zero;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == targetPlayer)
        {
            Debug.Log("Player in range");
            otherPlayerCollider = other;
            canLaunch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == targetPlayer)
        {
            Debug.Log("Player out of range");
            otherPlayerCollider = null;
            canLaunch = false;
        }
    }
}