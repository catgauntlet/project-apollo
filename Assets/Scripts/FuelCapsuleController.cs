using UnityEngine;

public class FuelCapsuleController : MonoBehaviour
{
    [SerializeField] private PlayerFuelController fuelController;
    [SerializeField] private AudioSource fuelPickupAudio;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float cyclePeriod = 4f;

    Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position; 
    }

    private void Update()
    {
        if (cyclePeriod <= Mathf.Epsilon) { return; }
        float cycles = Time.time / cyclePeriod;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPosition + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleFuelCollision();
    }

    private void HandleFuelCollision()
    {
        fuelPickupAudio.Play();
        fuelController.AddFuelFromCapsule();
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }
}
