using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls input;
    [SerializeField] private float moveSpeed;
    private Vector2 movementInput;

    private void Awake()
    {
        input = new PlayerControls();
    }

    private void OnEnable()
    {
        input.gameplay.Enable();
        input.gameplay.move.performed += OnMove;
        input.gameplay.move.canceled += OnMove;
    }

    private void OnDisable()
    {
        input.gameplay.move.performed -= OnMove;
        input.gameplay.move.canceled -= OnMove;
        input.gameplay.Disable();
    }

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // You get movement input here from W/A/S/D as a Vector2
        movementInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Just for demo: move the GameObject with input
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(move * Time.deltaTime * moveSpeed, Space.World);
    }
}
