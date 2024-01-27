using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shader : MonoBehaviour
{
    private Renderer renderer;

    [SerializeField]
    private HallucinationSpawn hs;

    float opacity;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetFloat("_Opacity", 0f);

        StartCoroutine(FluctuateShader());
    }

    // Update is called once per frame
    void Update()
    {
        opacity = ((float)hs.testMushroomCount / 50f);
    }

    IEnumerator FluctuateShader()
    {
        float o = 0f;

        while (true)
        {
            if (opacity > 0)
            {
                while (o < opacity)
                {
                    o += ((Time.deltaTime * opacity) / 2f);
                    renderer.material.SetFloat("_Opacity", o);
                    yield return new WaitForEndOfFrame();
                }

                yield return new WaitForSeconds(Random.Range(3f, 6f));

                while (o > (opacity / 6))
                {
                    o -= ((Time.deltaTime * opacity) / 2f);
                    renderer.material.SetFloat("_Opacity", o);
                    yield return new WaitForEndOfFrame();
                }

                yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            }
            yield return null;
        }
    }
}
