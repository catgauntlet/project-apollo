using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float levelReloadDelay = 2f;
    [SerializeField] private AudioSource crashAudio;
    [SerializeField] private AudioSource finishAudio;

    private bool canCollide = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (canCollide)
        {
            switch (collision.gameObject.tag)
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

    }

    private void DisablePlayerMovement()
    {
        GetComponent<PlayerMovementController>().DisablePlayerMovement();
    }

    private void HandleUnfriendlyCollision()
    {
        canCollide = false;
        crashAudio.Play();
        DisablePlayerMovement();
        Invoke("LoadCurrentScene", levelReloadDelay);
    }

    private void HandleFinishCollision()
    {
        canCollide = false;
        finishAudio.Play();
        DisablePlayerMovement();
        Invoke("LoadNextScene", levelReloadDelay);
    }

    private void LoadCurrentScene()
    {
        gameManager.ReloadCurrentScene();
        canCollide = true;

    }

    private void LoadNextScene()
    {
        gameManager.LoadNextScene();
        canCollide = true;
    }
}
