//Author: Branson Vernon
//Date: 01/27/2024
//Purpose: Spawns hallucinations around the player based on how many mushrooms the player has collected

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class HallucinationSpawn : MonoBehaviour
{
    //List of all hallucinations
    [SerializeField]
    public List<GameObject> hallucinations = new List<GameObject>();

    //chance for a hallucination to occur during a check
    private int spawnChance;

    //Time to spawn a hallucination
    private float spawnTimer;
    //Time between hallucination spawn checks
    [SerializeField]
    private float timeToSpawn = 3f;

    //The max radius an object can be from the player
    [SerializeField]
    private float maxRadius = 40f;

    //test variable for the mushroom count, will be replaced by GameManager mushroom cout
    public int testMushroomCount;

    //debug text to see mushroom count
    [SerializeField]
    public Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        //initializing values
        spawnTimer = 0f;
        spawnChance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = testMushroomCount.ToString();

        //testMushroomCount = GameManager.Instance.TotalMushroomsCollected;

        spawnChance = testMushroomCount * 3;

        //spawnChance cant go over 100
        if (spawnChance > 100)
        {
            spawnChance = 100;
        }

        if (testMushroomCount > 0)
        {
            timeToSpawn = 1f / ((testMushroomCount + 1f) / 5f);
        }


        //Increment spawnTimer
        spawnTimer += Time.deltaTime;

        //If spawnTimer hits timeToSpawn
        if (spawnTimer > timeToSpawn)
        {
            //Reset the spawn timer
            spawnTimer = 0f;

            //Check to see if a hallucination will spawn based on chance
            bool spawn = CheckToSpawn();

            //if it does spawn
            if (spawn)
            {
                SpawnHallucinations();
            }
        }
    }

    //Checks to see if a hallucination will spawn based on the chance
    private bool CheckToSpawn()
    {
        bool willSpawn = false;

        //random number from 1-100
        int randNum = Random.Range(1, 101);

        //if generated number is less than or equal to the spawn chance, a halucination will spawn
        if (randNum <= spawnChance)
        {
            willSpawn = true;
        }

        return willSpawn;
    }

    //Spawns the hallucination
    private void SpawnHallucinations()
    {
        //figure out which hallucination to spawn
        GameObject hallucination = ChooseHallucination();

        if (hallucination != null) 
        {
            //Randomly generates a scale for the hallucination to be at
            float scale = hallucination.transform.localScale.x;
            scale *= Random.Range(0.5f, 4.5f);

            //Gets where to spawn the player
            Vector3 pos = GetSpawnPosition();
            pos.y = scale * 2;

            //spawns in the hallucination and sets its scale
            GameObject hal = Instantiate(hallucination, pos, Quaternion.identity);
            hal.transform.localScale = new Vector3(scale, scale, scale);

            //Get the hallucination script and set the 
            Hallucination halScript = hal.GetComponent<Hallucination>();
            halScript.SetLookTowards(this.gameObject);
        }
    }

    //Chooses which hallucination to spawn
    private GameObject ChooseHallucination()
    {
        GameObject hallucination = null;

        //if there are hallucinations in the array
        if (hallucinations.Count > 0)
        {
            //choose a random number with a valid array index
            int randIndex = Random.Range(0, hallucinations.Count);

            //choose the hallucination at that random index
            hallucination = hallucinations[randIndex];
        }

        return hallucination; 
    }

    //Returns a spawn position
    private Vector3 GetSpawnPosition()
    {
        Vector3 pos = Vector3.zero;
        Vector3 centre = this.transform.position;

        //Get angle on circle to spawn on
        float randRad = Random.Range(0f, 2 * Mathf.PI);

        //generates a random radius for the hallucination to spawn from
        float radius = Random.Range(11f, maxRadius);

        //use sin and cos to get the circle positions of the 
        pos.x = Mathf.Cos(randRad) * radius + centre.x;
        pos.z = Mathf.Sin(randRad) * radius + centre.z;

        return pos;
    }

    //test function for the button
    public void IncreaseCount()
    {
        testMushroomCount++;
    }

}
