using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float thrustVelocity = 100.0f;
    [SerializeField] private float rotationVelocityDegrees = 1f;

    Rigidbody rigidBody;
    Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRocketThrust();
        ProcessRocketRotation();
    }

    void ProcessRocketThrust()
    {
        if (Input.GetKey(KeyCode.Space)) {
            Vector3 force = new Vector3(0, thrustVelocity * Time.deltaTime, 0);
            rigidBody.AddRelativeForce(force, ForceMode.Force);
        }
    }


    void ProcessRocketRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateRocket(rotationVelocityDegrees);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateRocket(-rotationVelocityDegrees);
        }
    }

    private void RotateRocket(float rotationDegrees)
    {
        Vector3 rotationVector = new Vector3(0, 0, rotationDegrees * Time.deltaTime);
        transform.Rotate(rotationVector);
    }
}
