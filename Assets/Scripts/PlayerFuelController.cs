using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuelController : MonoBehaviour
{

    [SerializeField] private float initialFuel = 100f;
    [SerializeField] private float fuelUsageModifier = 1f;
    [SerializeField] private float fuelCapsuleCount = 20f;
    [SerializeField] private float alertFuelAmount = 80f;
    [SerializeField] private UILayerController uiController;

    public float availableFuel;

    // Start is called before the first frame update
    void Start() {
        availableFuel = initialFuel;
    }

    public void UpdateFuelAvailability()
    {
        availableFuel -= fuelUsageModifier * Time.deltaTime;
        if (uiController)
        {
            uiController.SetAvailableFuel(Mathf.FloorToInt(availableFuel));
        }
        HandleFuelDeficiency();
    }

    public void AddFuelFromCapsule()
    {
        availableFuel += fuelCapsuleCount;
        if (uiController)
        {
            uiController.SetAvailableFuel(Mathf.FloorToInt(availableFuel));
        }
        HandleFuelDeficiency();
    }

    public void HandleFuelDeficiency()
    {
        if (uiController)
        {
            uiController.SetFuelAlert(availableFuel > alertFuelAmount);
        }
    }
}

