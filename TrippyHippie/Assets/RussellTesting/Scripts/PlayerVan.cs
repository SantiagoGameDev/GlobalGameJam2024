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
        AudioClip clip = null;

        int chosenClip = Random.Range(1, 6);

        switch (chosenClip)
        {
            case 1:
                clip = Gnome;
                break;
            case 2:
                clip = Wow;
                break;
            case 3:
                clip = HisNameIs;
                break;
            case 4:
                clip = AreYouSure;
                break;
            case 5:
                clip = Huh;
                break;
        }

        trippyAudio.PlayOneShot(clip);
    }
}
