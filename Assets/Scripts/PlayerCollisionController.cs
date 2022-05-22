using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private float levelReloadDelay = 2f;
   
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Unfriendly":
                HandleUnfriendlyCollision();
                break;
            case "Finish":
                HandleFinishCollision();
                break;
            case "Friendly":
            default:
                break;
        }
    }

    private void DisablePlayerMovement()
    {
        GetComponent<PlayerMovementController>().DisablePlayerMovement();
    }

    private void HandleUnfriendlyCollision()
    {
        DisablePlayerMovement();
        Invoke("LoadCurrentScene", levelReloadDelay);
    }

    private void HandleFinishCollision()
    {
        DisablePlayerMovement();
        Invoke("LoadNextScene", levelReloadDelay);
    }

    private void LoadCurrentScene()
    {
        gameManager.ReloadCurrentScene();

    }

    private void LoadNextScene()
    {
        gameManager.LoadNextScene();
    }
}
