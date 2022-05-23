using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // Parameters
    [SerializeField] private float thrustVelocity = 100.0f;
    [SerializeField] private float rotationVelocityDegrees = 1f;
    [SerializeField] private AudioSource mainEngineAudio;
    [SerializeField] private ParticleSystem thrusterParticles;
    [SerializeField] private ParticleSystem leftThrusterParticles;
    [SerializeField] private ParticleSystem rightThrusterParticles;

    // Cache
    Rigidbody rigidBody;
    Transform transform;
    PlayerFuelController fuelController;

    // State
    private bool movementEnabled = true;
    private bool forceRocketUpwards = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        fuelController = GetComponent<PlayerFuelController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRocketThrust();
        ProcessRocketRotation();
    }

    public void ThrustUpwardInMenu()
    {
        forceRocketUpwards = true;
    }

    public void DisablePlayerMovement()
    {
        movementEnabled = false;
    }

    private void ProcessRocketThrust()
    {
        if (forceRocketUpwards || (movementEnabled && Input.GetKey(KeyCode.Space))) {
            if (fuelController.availableFuel > 0)
            {
                fuelController.UpdateFuelAvailability();
                Vector3 force = new Vector3(0, thrustVelocity * Time.deltaTime, 0);
                rigidBody.AddRelativeForce(force, ForceMode.Force);
                if (!mainEngineAudio.isPlaying)
                {
                    mainEngineAudio.Play();
                }

                if (!thrusterParticles.isPlaying)
                {
                    thrusterParticles.Play();
                }
            } else
            {
                thrusterParticles.Stop();
            }
        } else {
            if (thrusterParticles.isPlaying)
            {
                thrusterParticles.Stop();
            }
            if (mainEngineAudio.isPlaying)
            {
                mainEngineAudio.Pause();
            }
        }
    }

    private void ProcessRocketRotation()
    {
        if (movementEnabled)
        {
            if (Input.GetKey(KeyCode.D))
            {
                RotateRocket(rotationVelocityDegrees);
                if (!leftThrusterParticles.isPlaying)
                {
                    leftThrusterParticles.Play();
                }
           
            } else if (Input.GetKey(KeyCode.A))
            {
                RotateRocket(-rotationVelocityDegrees);
                if (!rightThrusterParticles.isPlaying)
                {
                    rightThrusterParticles.Play();
                }
            } else
            {
                leftThrusterParticles.Stop();
                rightThrusterParticles.Stop();
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
