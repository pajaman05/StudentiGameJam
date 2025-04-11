using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float LookSpeed = 20f;
    private PlayerControls input;
    private Vector2 mouseScreenPos;

    private void Awake()
    {
        input = new PlayerControls();
    }

    private void OnEnable()
    {
        input.gameplay.Enable();
        input.gameplay.aim.performed += OnAim;
    }

    private void OnDisable()
    {
        input.gameplay.aim.performed -= OnAim;
        input.gameplay.Disable();
    }

    // Called by the Input System when the mouse moves
    public void OnAim(InputAction.CallbackContext context)
    {
        mouseScreenPos = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        AimAtMouse();
    }

    private void AimAtMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPos);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            Vector3 target = hit.point;
            Vector3 direction = (target - transform.position);
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, LookSpeed * Time.deltaTime);
            }
        }
    }
}
