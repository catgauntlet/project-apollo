using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // Parameters
    [SerializeField] private float thrustVelocity = 100.0f;
    [SerializeField] private float rotationVelocityDegrees = 1f;
    [SerializeField] private AudioSource mainEngineAudio;

    // Cache
    Rigidbody rigidBody;
    Transform transform;

    // State
    private bool movementEnabled = true;

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

    public void DisablePlayerMovement()
    {
        movementEnabled = false;
    }

    private void ProcessRocketThrust()
    {
        if (movementEnabled && Input.GetKey(KeyCode.Space)) {
            Vector3 force = new Vector3(0, thrustVelocity * Time.deltaTime, 0);
            rigidBody.AddRelativeForce(force, ForceMode.Force);
            if (!mainEngineAudio.isPlaying)
            {
                mainEngineAudio.Play();
            }

        } else if (mainEngineAudio.isPlaying) {
            mainEngineAudio.Pause();
        }
    }


    private void ProcessRocketRotation()
    {
        if (movementEnabled)
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
    }

    private void RotateRocket(float rotationDegrees)
    {
        Vector3 rotationVector = new Vector3(0, 0, rotationDegrees * Time.deltaTime);

        rigidBody.freezeRotation = true; // Freezing the rotation so we can manually rotate the gameObject
        transform.Rotate(rotationVector);
        rigidBody.freezeRotation = false; // Unfreezing rotation so the physics engine of Unity can take over again
    }
}
