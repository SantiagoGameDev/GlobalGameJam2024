using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    Image trippyView;

    [SerializeField] GameObject credits;

    private float newAlpha;
    private float alphaIncreaseRate;

    float totalFlashTime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        newAlpha = 0.0f;
    }

    public void UpdateTrippyView()
    {
        float randomRed = Random.Range(0.1f, 1.0f);
        float randomGreen = Random.Range(0.1f, 1.0f);
        float randomBlue = Random.Range(0.1f, 1.0f);

        alphaIncreaseRate = 1.0f / WorldData.Instance.totalMushroomsInGame;
        newAlpha += alphaIncreaseRate;

        trippyView.color = new Color(randomRed, randomGreen, randomBlue, newAlpha);

        PlayerVan.Instance.PlayRandomClip();
    }

    public void StartGameBtn()
    {
        SceneManager.LoadScene("TrippyHippie");
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        credits.gameObject.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.gameObject.SetActive(false);
    }

    /*public void SetFlashTime()
    {
        totalFlashTime = 0.0f;
        if (WorldData.Instance.trippyViewPerc >= 0.0f && WorldData.Instance.trippyViewPerc < 15.0f)
        {
            totalFlashTime = 2.0f;
        }
        else if (WorldData.Instance.trippyViewPerc >= 15.0f && WorldData.Instance.trippyViewPerc < 30.0f)
        {
            totalFlashTime = 3.0f;
        }
        else if (WorldData.Instance.trippyViewPerc >= 30.0f && WorldData.Instance.trippyViewPerc < 45.0f)
        {
            totalFlashTime = 4.0f;
        }
        else if (WorldData.Instance.trippyViewPerc >= 45.0f && WorldData.Instance.trippyViewPerc < 60.0f)
        {
            totalFlashTime = 6.0f;
        }
        else if (WorldData.Instance.trippyViewPerc >= 60.0f && WorldData.Instance.trippyViewPerc < 75.0f)
        {
            totalFlashTime = 8.0f;
        }
        else if (WorldData.Instance.trippyViewPerc >= 75.0f && WorldData.Instance.trippyViewPerc <= 100.0f)
        {
            totalFlashTime = 10.0f;
        }

        StartCoroutine(FlashTrippyView());
    }*/

     /*public void StartIt()
     {
         StartCoroutine(FlashTrippyView());
     }

     private IEnumerator FlashTrippyView()
     {
        totalFlashTime = 5.0f;

         trippyView.gameObject.SetActive(true);

         float currentFlashTime = 0.0f;
         while(currentFlashTime < totalFlashTime)
         {
             float randomRed = Random.Range(0.1f, 1.0f);
             float randomGreen = Random.Range(0.1f, 1.0f);
             float randomBlue = Random.Range(0.1f, 1.0f);
             float randomAlpha = Random.Range(0.25f, 1.0f);
             trippyView.color = new Color(randomRed, randomGreen, randomBlue, randomAlpha);

             trippyView.gameObject.SetActive(trippyView.isActiveAndEnabled);
             yield return new WaitForSeconds(0.10f);
             trippyView.gameObject.SetActive(!trippyView.isActiveAndEnabled);
             currentFlashTime += 0.10f;
         }
         trippyView.gameObject.SetActive(false);
         StopCoroutine(FlashTrippyView());
     }*/
}
