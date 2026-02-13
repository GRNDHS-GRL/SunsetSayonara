using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private PlayerControls.OverworldActions overworld;

    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerControls = new PlayerControls();
        overworld = playerControls.Overworld;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        overworld.Jump.performed += ctx => motor.Jump();
        overworld.Sprint.performed += ctx => motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell playermotor to move using value from our movement action
        motor.ProcessMove(overworld.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(overworld.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        overworld.Enable();
    }
    private void OnDisable()
    {
        overworld.Disable();
    }
}
