using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVan : MonoBehaviour
{
    public static PlayerVan Instance;

    public int playerMushroomCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
