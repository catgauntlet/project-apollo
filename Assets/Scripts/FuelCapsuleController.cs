using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCapsuleController : MonoBehaviour
{
    [SerializeField] private PlayerFuelController fuelController;

    private void OnTriggerEnter(Collider other)
    {
        HandleFuelCollision();
    }

    private void HandleFuelCollision()
    {
        fuelController.AddFuelFromCapsule();
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }
}
