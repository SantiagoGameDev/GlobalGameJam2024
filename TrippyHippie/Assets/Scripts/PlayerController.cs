using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator animator;

    private PlayerActions playerActions;
    private Rigidbody rb;
    private Vector3 moveInput;

    [SerializeField] GameObject hippieModel;

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
        //var targetAngle = Mathf.Atan2(moveInput.x, moveInput.z);

        if(moveInput.x != 0.0f || moveInput.z != 0.0f )
            transform.rotation = Quaternion.LookRotation(new Vector3(moveInput.x, 0, moveInput.z));

        //transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
        //hippieModel.transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);

        if ((rb.velocity.x >= 0.1f || rb.velocity.x <= -0.1f) || (rb.velocity.z >= 0.1f || rb.velocity.z <= -1.0f))
            animator.Play("walk");

    }
    private void PlayerMovement()
    {
        
    }

    public void EnablePlayerControls()
    {
        playerActions.Human.Enable();
    }
    public void DisablePlayerControls()
    {
        playerActions.Human.Disable();
    }
}
