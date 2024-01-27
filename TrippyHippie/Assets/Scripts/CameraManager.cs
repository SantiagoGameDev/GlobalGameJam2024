using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    public static CameraManager Instance { get { return instance; } }

    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        instance = this;
        mainCamera = GetComponent<Camera>();
    }

}
