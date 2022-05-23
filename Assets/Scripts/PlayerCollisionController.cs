using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float levelReloadDelay = 2f;
    [SerializeField] private AudioSource crashAudio;
    [SerializeField] private AudioSource finishAudio;

    [SerializeField] private ParticleSystem crashParticles;
    [SerializeField] private ParticleSystem finishParticles;

    PlayerMovementController movementController;
    DealWithItGlassesController dealWithItGlassesController;

    private bool canCollide = true;

    private void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
        dealWithItGlassesController = GetComponent<DealWithItGlassesController>();
    }

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
        movementController.DisablePlayerMovement();
    }

    private void HandleUnfriendlyCollision()
    {
        canCollide = false;
        crashAudio.Play();
        crashParticles.Play();
        DisablePlayerMovement();
        Invoke("LoadCurrentScene", levelReloadDelay);
    }

    private void HandleFinishCollision()
    {
        canCollide = false;
        finishAudio.Play();
        finishParticles.Play();
        DisablePlayerMovement();
        dealWithItGlassesController.DropGlasses();
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

    public void ToggleCollisions()
    {
        canCollide = !canCollide;
    }
}
