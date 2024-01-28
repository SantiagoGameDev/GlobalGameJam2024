using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVan : MonoBehaviour
{
    public static PlayerVan Instance;

    public int playerMushroomCount = 0;

    [SerializeField]
    AudioSource trippyAudio;

    public AudioClip farOutMan;
    public AudioClip peaceAndLove;
    public AudioClip trippy;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomClip()
    {
        AudioClip clip = null;

        int chosenClip = Random.Range(1, 4);

        switch (chosenClip)
        {
            case 1:
                clip = farOutMan;
                break;
            case 2:
                clip = peaceAndLove;
                break;
            case 3:
                clip = trippy;
                break;
        }

        trippyAudio.PlayOneShot(clip);
    }
}
