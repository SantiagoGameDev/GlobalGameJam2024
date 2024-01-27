using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleEffect : MonoBehaviour
{
    private TMP_Text titleText;
    private Mesh textMesh;
    private Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        titleText = GetComponent<TMP_Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        titleText.ForceMeshUpdate();
        textMesh = titleText.mesh; 
        vertices = textMesh.vertices;

      /*  for (int s = 0; s < vertices.Length; s++)
        {
            Vector3 offset = Wobble((Time.time + s) * 5.0f);
            vertices[s] = vertices[s] + offset;
        }*/

        for (int c = 0; c < titleText.textInfo.characterCount; c++)
        {
            TMP_CharacterInfo charInfo = titleText.textInfo.characterInfo[c];
            int index = charInfo.vertexIndex;

            Vector3 offset = Wobble((Time.time + c) * 3.0f);
            vertices[index] += offset;
            vertices[index + 2] += offset;
            vertices[index + 4] += offset;
            vertices[index + 6] += offset;
        }

        textMesh.vertices = vertices;
        titleText.canvasRenderer.SetMesh(textMesh);
    }

    private Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time*3.3f), Mathf.Cos(time*1.8f));
    }
}
