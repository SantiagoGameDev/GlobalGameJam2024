using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPickUp : MonoBehaviour
{
    void Start()
    {
        WorldData.Instance.totalMushroomsInGame += 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerVan.Instance.playerMushroomCount += 1;
            UIManager.Instance.UpdateTrippyView();
            Destroy(gameObject);
        }
    }
}
