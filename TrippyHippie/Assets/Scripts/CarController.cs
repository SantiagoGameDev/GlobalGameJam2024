using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front,Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    [SerializeField] private float maxAccel;
    [SerializeField] private float brakeAccel;

    [SerializeField] private float turnSense;
    [SerializeField] private float maxSteerAngle;

    private Vector3 centerOfMass;
    [SerializeField] private List<Wheel> wheels;

    private PlayerActions playerActions;
    private Rigidbody carRb;

    private Quaternion defaultRot;


    Vector3 moveInput;
    Vector3 steerInput;

    private void Start()
    {
        playerActions = new PlayerActions();
        //playerActions.Car.Enable();
        carRb = GetComponent<Rigidbody>();

        carRb.centerOfMass = centerOfMass;
        defaultRot = transform.rotation;

        playerActions.Car.Brake.performed += ActivateBrake;
        playerActions.Car.Brake.canceled += ReleaseBrake;
        playerActions.Car.ExitCar.performed += ExitCar;
        playerActions.Car.FlipCar.performed += FlipCar;
    }

    private void Update()
    {
        UpdateInput();
        //AnimateWheels();
    }

    private void LateUpdate()
    {
        Movement();
        Steer();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SwitchControls();
        }

        if (collision.gameObject.CompareTag("Tree"))
        {
            GameManager.Instance.TakeCarDamage();
        }
    }

    private void UpdateInput()
    {
        moveInput = new Vector3(playerActions.Car.Movement.ReadValue<Vector2>().x, 0, playerActions.Car.Movement.ReadValue<Vector2>().y);
        steerInput = new Vector3(playerActions.Car.Movement.ReadValue<Vector2>().x, 0, playerActions.Car.Movement.ReadValue<Vector2>().y);
    }

    private void Movement()
    {
        foreach (Wheel wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput.z * maxAccel * Time.deltaTime;
        }
    }

    private void Steer()
    {
        foreach(Wheel wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var steerAngle = steerInput.x * turnSense * maxSteerAngle * Time.deltaTime;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steerAngle, 0.6f);
            }
        }
    }

    public void EnableCarControls()
    {
        playerActions.Car.Enable();
        GameManager.Instance.canDmg = true;
    }

    public void DisableCarControls()
    {
        GameManager.Instance.canDmg = false;
        playerActions.Car.Disable();
    }

    private void FlipCar(InputAction.CallbackContext context)
    {
        Debug.Log("Car Flipped");
        transform.rotation = defaultRot;
    }

    private void ExitCar(InputAction.CallbackContext context)
    {
        GameManager.Instance.SwitchControls();

        foreach (Wheel wheel in wheels)
        {
            wheel.wheelCollider.attachedRigidbody.velocity = Vector3.zero;
        }

        carRb.velocity = Vector3.zero;  
    }

    private void ActivateBrake(InputAction.CallbackContext context)
    {
        Debug.Log("Braking");
        foreach (Wheel wheel in wheels)
        {
            wheel.wheelCollider.brakeTorque = brakeAccel * Time.deltaTime;
        }
    }

    private void ReleaseBrake(InputAction.CallbackContext context)
    {
        Debug.Log("Brake Released");

        foreach (Wheel wheel in wheels)
        {
            wheel.wheelCollider.brakeTorque = 0;
        }
    }

    private void AnimateWheels()
    {
        foreach (Wheel wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

}
