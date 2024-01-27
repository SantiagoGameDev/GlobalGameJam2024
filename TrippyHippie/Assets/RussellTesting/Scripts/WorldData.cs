using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    public static WorldData Instance;

    public int totalMushroomsInGame;

    public float trippyViewPerc; 

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        trippyViewPerc = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTrippyViewChancePerc()
    {
        trippyViewPerc = Random.Range(PlayerVan.Instance.playerMushroomCount, 100);
        float multiplier = Random.Range(0.1f, 1.0f);
        trippyViewPerc = trippyViewPerc * multiplier;
        UIManager.Instance.SetFlashTime();
    }
}
