using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject car;
    [SerializeField] private Transform carExit;

    private Renderer carRenderer;

    private PlayerController playerController;
    private CarController carController;
    [SerializeField] private CameraFollow cameraFollow;

    public bool isInCar;

    public bool canDmg;
    [SerializeField] public int carHP;

    private void Awake()
    {
        instance = this;

        playerController = player.GetComponent<PlayerController>();
        carController = car.GetComponent<CarController>();

        isInCar = false;

        canDmg = true;

    }
    private void Start()
    {
        playerController.EnablePlayerControls();
        carRenderer = car.GetComponentInChildren<Renderer>();
    }

    public void TakeCarDamage()
    {
        if (canDmg)
        {
            carHP -= 1;
            StartCoroutine(Iframes());
            Debug.Log("Damage taken hp is now: " + carHP);

            InGameHUD.Instance.UpdateHP(carHP);
        }


            
    }

    public void SwitchControls()
    {
        if (playerController.isActiveAndEnabled) //Switching to Car
        {
            playerController.enabled = false;
            carController.enabled = true;
            player.gameObject.SetActive(false);
            carController.EnableCarControls();

            isInCar = true;
            cameraFollow.target = car.transform;
        }
        else if (carController.isActiveAndEnabled) //Switching to Hippie
        {
            player.gameObject.SetActive(true);
            carController.enabled = false;
            playerController.enabled = true;
            player.transform.position = carExit.position;

            playerController.EnablePlayerControls();
            carController.DisableCarControls();

            isInCar = false;
            cameraFollow.target = player.transform;

        }
            
    }

    private IEnumerator Iframes()
    {
        canDmg = false;

        carRenderer.enabled = false;

        yield return new WaitForSeconds(0.2f);

        carRenderer.enabled = true;

        yield return new WaitForSeconds(0.2f);

        carRenderer.enabled = false;

        yield return new WaitForSeconds(0.2f);

        carRenderer.enabled = true;

        yield return new WaitForSeconds(0.2f);

        carRenderer.enabled = false;

        yield return new WaitForSeconds(0.2f);

        carRenderer.enabled = true;

        canDmg = true;

    }

}
