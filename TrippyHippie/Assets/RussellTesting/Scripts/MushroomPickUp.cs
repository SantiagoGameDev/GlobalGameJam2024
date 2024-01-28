using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPickUp : MonoBehaviour
{
    MushroomSpawner m_Spawner;

    void Start()
    {
        WorldData.Instance.totalMushroomsInGame += 1;

        StartCoroutine(GrowIn());
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            WorldData.Instance.totalMushroomsInGame -= 1;
            PlayerVan.Instance.playerMushroomCount += 1;

            PlayerVan.Instance.PlayRandomClip();

            m_Spawner.RemoveFromList(this.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetSpawner(MushroomSpawner inSpawn)
    {
        m_Spawner = inSpawn;
    }

    IEnumerator GrowIn()
    {
        float fullScale = this.transform.localScale.x;

        this.transform.localScale = new Vector3(0f, 0f, 0f);

        float scale = 0f;

        while (scale < fullScale)
        {
            scale += Time.deltaTime / 0.25f;

            if (scale > fullScale)
            {
                scale = fullScale;
            }

            this.transform.localScale = new Vector3(scale, scale, scale);

            yield return new WaitForEndOfFrame();
        }
    }
}
