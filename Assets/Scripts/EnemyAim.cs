using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float LookSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        AimAtPlayer();
    }

    private void AimAtPlayer()
    {
        if(player != null)
        {
            Vector3 direction = (player.position - transform.position);
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, LookSpeed * Time.deltaTime);
            }
        }
    }
}
