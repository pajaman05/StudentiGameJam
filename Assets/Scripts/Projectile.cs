using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;

    private void Start()
    {
        // Destroy the projectile after a set lifetime
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the projectile forward along its forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
