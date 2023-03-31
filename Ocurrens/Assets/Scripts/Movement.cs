using System;
using Mono.Cecil;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkspeed = 4f;

    public float maxVelocityChange = 10;
    [SerializeField] public Camera playerCamera;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        CalcRotation();
    }

    private void FixedUpdate()
    {
        rb.AddForce(CalcMovement(walkspeed), ForceMode.VelocityChange);
    }

    void CalcRotation()
    {
        mouseInput.x += Input.GetAxis("Mouse X");
        mouseInput.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, mouseInput.x, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(-mouseInput.y, 0, 0);
    }

    Vector3 CalcMovement(float speed)
    {
        Vector3 targetVelocity = new Vector3(moveInput.x,0, moveInput.y);
        targetVelocity = transform.TransformDirection(targetVelocity);

        targetVelocity *= speed;

        Vector3 velocity = rb.velocity;

        if (moveInput.magnitude > .5f)
        {
            Vector3 velocityChange = targetVelocity - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);

            velocityChange.y = 0;

            return velocityChange;
        }
        else
        {
            return Vector3.zero;
        }
    }
}