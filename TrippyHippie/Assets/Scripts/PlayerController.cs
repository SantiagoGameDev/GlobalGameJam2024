using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    private PlayerActions playerActions;
    private Rigidbody rb;
    private Vector3 moveInput;

    private void Awake()
    {
        playerActions = new PlayerActions();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        moveInput = new Vector3(playerActions.Human.Walking.ReadValue<Vector2>().x, 0, playerActions.Human.Walking.ReadValue<Vector2>().y);

        rb.velocity = moveInput * speed * Time.deltaTime;
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        playerActions.Human.Enable();
    }

    private void OnDisable()
    {
        playerActions.Human.Disable();
    }

    private void PlayerMovement()
    {
        
    }
}
