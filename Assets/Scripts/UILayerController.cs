using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private GameObject fuelAlertPanel;

    private bool fuelAlertBlinking = false;
    public void SetAvailableFuel(int fuelAvailability)
    {
        fuelText.text = $"Fuel: {fuelAvailability.ToString()}";
    }

    public void SetFuelAlert(bool enoughFuelAvailable)
    {
        if (enoughFuelAvailable)
        {
            fuelAlertBlinking = false;
            fuelAlertPanel.GetComponent<Image>().color = new Color(1, 0, 0, 0);
            fuelText.color = Color.white;
            CancelInvoke();
        }
        else
        {
            HandleFuelAlert();
        }
    }

    public void ToggleFuelAlertPanel()
    {
        float currentAlpha = fuelAlertPanel.GetComponent<Image>().color.a;
        fuelAlertPanel.GetComponent<Image>().color = new Color(1, 0, 0, currentAlpha == 0.2f ? 0 : 0.2f);
    }


    public void HandleFuelAlert()
    {
        if (!fuelAlertBlinking)
        {
            fuelAlertBlinking = true;
            InvokeRepeating("ToggleFuelAlertPanel", 0, 0.5f);
            fuelText.color = Color.red;
        }
    }
}
