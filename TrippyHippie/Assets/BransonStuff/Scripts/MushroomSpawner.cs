using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    float spawnTimer;
    float timeToSpawn = 0.5f;

    [SerializeField]
    private GameObject mushroomPrefab;

    [SerializeField]
    private GameObject spawnPlane;

    private int maxMushrooms = 100;
    [SerializeField]
    private List<GameObject> mushrooms = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > timeToSpawn)
        {
            spawnTimer = 0f;

            if (maxMushrooms > mushrooms.Count)
            {
                Vector3 pos = GetSpawnPoint();

                GameObject shroom = Instantiate(mushroomPrefab, pos, Quaternion.identity);
                
                MushroomPickUp shroomScript = shroom.GetComponent<MushroomPickUp>();
                shroomScript.SetSpawner(this);

                mushrooms.Add(shroom);
            }
        }
    }

    private Vector3 GetSpawnPoint()
    {
        Vector3 pos = new Vector3();

        if (spawnPlane != null)
        {
            float length = spawnPlane.transform.localScale.x * 9f;
            float width = spawnPlane.transform.localScale.z * 9f;

            float xPos = (Random.Range(0, length) - length / 2) + spawnPlane.transform.position.x;
            float zPos = (Random.Range(0, width) - width / 2) + spawnPlane.transform.position.z;

            pos = new Vector3(xPos, spawnPlane.transform.position.y, zPos);
        }

        return pos;
    }

    public void RemoveFromList(GameObject inShroom)
    {
        mushrooms.Remove(inShroom);
    }
}
