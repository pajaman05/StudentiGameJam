using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint1;
    [SerializeField] private Transform shootPoint2;
    [SerializeField] private float shootTimer = 0f;
    [SerializeField] private float shootCooldown = 0.5f;
    private bool isShooting = false;

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (IsFacingTarget(this.transform, player))
            {
                isShooting = true;
                ShootCooldown();
            }
            else
                isShooting = false;
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null && shootPoint1 != null && shootPoint2 != null)
        {
            isShooting = true;
            Instantiate(projectilePrefab, shootPoint1.position, shootPoint1.rotation);
            Instantiate(projectilePrefab, shootPoint2.position, shootPoint2.rotation);
        }
    }

    private void ShootCooldown()
    {
        if (isShooting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                Shoot();
                shootTimer = shootCooldown;
            }
        }
    }

    bool IsFacingTarget(Transform self, Transform target)
    {
        float thresholdAngle = 10f;
        Vector3 directionToTarget = (target.position - self.position).normalized;
        float angle = Vector3.Angle(self.forward, directionToTarget);
        return angle < thresholdAngle;
    }
}
