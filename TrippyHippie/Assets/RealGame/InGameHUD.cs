using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    private static InGameHUD instance;
    public static InGameHUD Instance {get { return instance;}}

    [SerializeField] TMP_Text mushCount;
    [SerializeField] Slider hpSlider;

    private void Awake()
    {
        instance = this;
        mushCount.text = "x0";
    }

    private void Update()
    {
        
    }

    public void MushCollected()
    {
        mushCount.text = "x" + PlayerVan.Instance.playerMushroomCount.ToString();
    }

    public void UpdateHP(int val)
    {
        hpSlider.value = val;
    }
}
