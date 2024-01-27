using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVan : MonoBehaviour
{
    public static PlayerVan Instance;

    public int playerMushroomCount = 0;

    [SerializeField]
    AudioSource trippyAudio;

    public AudioClip Gnome;
    public AudioClip Wow;
    public AudioClip HisNameIs;
    public AudioClip AreYouSure;
    public AudioClip Huh;

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
        int chosenClip = Random.Range(1, 5);

        if (chosenClip == 1)
        {
            trippyAudio.PlayOneShot(Gnome);
        }
        else if (chosenClip == 2)
        {
            trippyAudio.PlayOneShot(Wow);
        }
        else if (chosenClip == 3)
        {
            trippyAudio.PlayOneShot(HisNameIs);
        }
        else if (chosenClip == 4)
        {
            trippyAudio.PlayOneShot(AreYouSure);
        }
        else if (chosenClip == 5)
        {
            trippyAudio.PlayOneShot(Huh);
        }
    }
}
