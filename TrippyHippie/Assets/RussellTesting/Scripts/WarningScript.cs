using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningScript : MonoBehaviour
{
    [SerializeField] GameObject warningObj;
    [SerializeField] int duration;

    private void Awake()
    {
        StartCoroutine(Warning(duration));
    }

    private IEnumerator Warning(int duration)
    {
        Debug.Log("Running coroutine");
        yield return new WaitForSeconds(duration);
        Debug.Log("Ending coroutine");
        warningObj.SetActive(false);
        
    }
}
