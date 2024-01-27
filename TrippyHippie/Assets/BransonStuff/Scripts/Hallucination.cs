//Author: Branson Vernon
//Date: 01/27/2024
//Purpose: Script to put on a halucination, makes them face the player and has them fade out and get destroyed after a bit

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hallucination : MonoBehaviour
{
    //The object to look towards
    private GameObject player;

    //despawn Timer
    private float despawnTimer;
    //time until the hallucination despawns
    private float timeToDespawn;
    //maximum amount of time it takes to despawn
    private float maxTimeToDespawn = 6f;

    //time the hallucination spends fading
    private float fadeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //initialize despawn timer
        despawnTimer = 0f;

        //generates how long until it despawns
        timeToDespawn = Random.Range(0, maxTimeToDespawn);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(GameManager.Instance.Player.transform);
        transform.LookAt(player.transform);

        //if despawn timer hasnt hit timetodespawn
        if (despawnTimer < timeToDespawn )
        {
            //increase despawn timer
            despawnTimer += Time.deltaTime;
        }
        //else if time to despawn
        else
        {
            //fade it out
            StartCoroutine(FadeOut());
        }

    }

    //sets what object this is looking towards
    public void SetLookTowards(GameObject inPlayer)
    {
        player = inPlayer;
    }

    //Fade out the object then destroy it
    IEnumerator FadeOut()
    {
        //Gets renderers
        Renderer[] renderers = new Renderer[2];
        renderers = GetComponentsInChildren<Renderer>();

        //gets alpha value of materials
        float a = renderers[0].material.color.a;

        //while alpha is greater than 0
        while (a > 0)
        {
            //decrease the alpha over time
            a -= Time.deltaTime / fadeTime;

            //if alpha gets below zero, it is zero
            if (a < 0)
            {
                a = 0;
            }

            //apply new alpha to the renderers
            foreach (Renderer r in renderers)
            {
                Color c = r.material.color;
                r.material.color = new Color(c.r, c.g, c.b, a);
            }

            yield return new WaitForEndOfFrame();
        }

        //destroy object after it fades out
        Destroy(this.gameObject);
    }
}
