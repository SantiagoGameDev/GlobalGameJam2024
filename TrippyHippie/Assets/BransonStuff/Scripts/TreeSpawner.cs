using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    private float spawnTimer;
    [SerializeField]
    private float timeToSpawn = 5f;

    [SerializeField]
    private float mushroomsToSpawn = 20f;

    [SerializeField]
    private GameObject treePrefab;

    [SerializeField]
    private Transform spawnPos;

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
            spawnTimer = 0;

            if (GameManager.Instance.isInCar)
            {
                if (PlayerVan.Instance.playerMushroomCount >= mushroomsToSpawn)
                {
                    int randNum = Random.Range(0, 5);

                    if (randNum == 0)
                    {

                        GameObject tree = Instantiate(treePrefab, spawnPos.position, Quaternion.identity);

                        //Get the hallucination script and set the 
                        Hallucination halScript = tree.GetComponent<Hallucination>();
                        halScript.SetLookTowards(this.gameObject);

                    }
                }
            }
        }
    }
}
