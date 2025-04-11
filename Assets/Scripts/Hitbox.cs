using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [SerializeField] private string projectileLayer = "Default";
    [SerializeField] private Health health;

    private void Start()
    {
        health = transform.parent.GetComponent<Health>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy hit");
        if (other.gameObject.layer == LayerMask.NameToLayer(projectileLayer))
        {
            Projectile projectile = other.transform.parent.GetComponent<Projectile>();
            if (projectile != null)
            {
                health.TakeDamage(projectile.damage);
            }
            Destroy(other.transform.parent.gameObject);
        }
    }
}
