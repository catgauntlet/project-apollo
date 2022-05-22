using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fuelText;

    public void SetAvailableFuel(int fuelAvailability)
    {
        fuelText.text = $"Fuel: {fuelAvailability.ToString()}";
    }
}
