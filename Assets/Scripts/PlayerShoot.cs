using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerControls input;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootCooldown = 0.2f;

    private bool isShooting = false;
    private float shootTimer = 0f;

    private void Awake()
    {
        input = new PlayerControls();
    }

    private void OnEnable()
    {
        input.gameplay.Enable();
        input.gameplay.shoot.started += OnShootStarted;
        input.gameplay.shoot.canceled += OnShootCanceled;
    }

    private void OnDisable()
    {
        input.gameplay.shoot.started -= OnShootStarted;
        input.gameplay.shoot.canceled -= OnShootCanceled;
        input.gameplay.Disable();
    }

    private void Update()
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

    private void OnShootStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isShooting = true;
        shootTimer = 0f; // instant fire on press
    }

    private void OnShootCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isShooting = false;
    }

    private void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
