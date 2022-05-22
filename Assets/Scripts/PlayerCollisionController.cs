using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Unfriendly":
                HandleUnfriendlyCollision();
                break;
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("Reached the finish!");
                break;
            default:
                break;
        }
    }

    private void HandleUnfriendlyCollision()
    {
        gameManager.ReloadCurrentScene();
    }
}
