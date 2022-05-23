using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float cyclePeriod = 0f;

    Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position; 
    }

    private void Update()
    {
        if (cyclePeriod <= Mathf.Epsilon) { return;  }
        float cycles = Time.time / cyclePeriod;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPosition + offset;
    }
}
