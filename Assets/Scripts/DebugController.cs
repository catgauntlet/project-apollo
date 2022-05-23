using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    [SerializeField] private PlayerCollisionController playerCollisionController;
    
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gameManager.LoadNextScene();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            playerCollisionController.ToggleCollisions();
        }
    }
}
