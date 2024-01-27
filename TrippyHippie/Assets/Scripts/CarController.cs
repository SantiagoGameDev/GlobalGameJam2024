using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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


    Vector3 moveInput;
    Vector3 steerInput;

    private void Start()
    {
        playerActions = new PlayerActions();
        playerActions.Car.Enable();
        carRb = GetComponent<Rigidbody>();

        carRb.centerOfMass = centerOfMass;
    }

    private void Update()
    {
        UpdateInput();
    }

    private void LateUpdate()
    {
        Movement();
        Steer();
        Brake();
    }

    private void OnEnable()
    {
        if(playerActions != null)
            playerActions.Car.Enable();
    }

    private void OnDisable()
    {
        playerActions.Car.Disable();
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

    private void Brake()
    {
        if (playerActions.Car.Brake.IsPressed())
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = brakeAccel * Time.deltaTime;
            }
        }
        else
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }

        

    }
}