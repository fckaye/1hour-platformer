using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameFlowController gameFlowController;
    private Rigidbody rb;
    private Vector3 forceVector;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float upwardsImpulse;
    private bool canJump;
    private bool isAlive;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            ApplyUpwardImpulse();
            ApplySidewayMovement();
        }
    }

    private void ApplyUpwardImpulse()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(new Vector3(0, upwardsImpulse, 0), ForceMode.Impulse);
        }
    }

    private void ApplySidewayMovement()
    {
        float sideForce = Input.GetAxisRaw("Horizontal");
        forceVector.x = sideForce * baseSpeed;
        rb.AddForce(forceVector, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            canJump = true;
        }

        if(collision.collider.CompareTag("Lava"))
        {
            isAlive = false;
            gameFlowController.PlayerLose();
        }

        if(collision.collider.CompareTag("Goal"))
        {
            isAlive = false;
            gameFlowController.PlayerWin();
        }
    }
}
