using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI startButton;
    [SerializeField] private TextMeshProUGUI quitButton;
    [SerializeField] private TextMeshProUGUI logo;
    [SerializeField] private PlayerMovementController playerMovementController;

    public void StartGameClicked()
    {
        startButton.alpha = 0;
        quitButton.alpha = 0;
        logo.alpha = 0;
        playerMovementController.ThrustUpwardInMenu();
        Invoke("LoadFirstLevel", 3.5f);
    }

    public void LoadFirstLevel()
    {
        gameManager.LoadFirstLevel();
    }

    public void QuitGameClicked()
    {
        gameManager.QuitGame();
    }
}
