using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject car;
    [SerializeField] private Transform carExit;

    private PlayerController playerController;
    private CarController carController;

    private void Awake()
    {
        instance = this;

        playerController = player.GetComponent<PlayerController>();
        carController = car.GetComponent<CarController>();

    }
    private void Start()
    {
        playerController.EnablePlayerControls();
    }

    public void SwitchControls()
    {
        if (playerController.isActiveAndEnabled)
        {
            playerController.enabled = false;
            carController.enabled = true;
            player.gameObject.SetActive(false);
            carController.EnableCarControls();
        }
        else if (carController.isActiveAndEnabled)
        {
            player.gameObject.SetActive(true);
            carController.enabled = false;
            playerController.enabled = true;
            player.transform.position = carExit.position;

            playerController.EnablePlayerControls();
            carController.DisableCarControls();

        }
            
    }

}
