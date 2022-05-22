using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuelController : MonoBehaviour
{

    [SerializeField] private float initialFuel = 100f;
    [SerializeField] private float fuelUsageModifier = 1f;
    [SerializeField] private float fuelCapsuleCount = 20f;
    [SerializeField] private UILayerController uiController;

    public float availableFuel;

    // Start is called before the first frame update
    void Start() {
        availableFuel = initialFuel;
    }

    public void UpdateFuelAvailability()
    {
        availableFuel -= fuelUsageModifier * Time.deltaTime;
        uiController.SetAvailableFuel(Mathf.FloorToInt(availableFuel));
    }

    public void AddFuelFromCapsule()
    {
        availableFuel += fuelCapsuleCount;
        uiController.SetAvailableFuel(Mathf.FloorToInt(availableFuel));
    }
}
