using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    public AudioSource introMusic;
    public DOTweenAnimation shutterDOT;

    public void OnStartButtonClick()
    {
        StartCoroutine(FadeOutMusic());
        shutterDOT.DORestart();
        Invoke("LoadGameScene", 3f);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator FadeOutMusic()
    {
        yield return null;
        while(true) 
        { 
            introMusic.volume = Mathf.Lerp(introMusic.volume, 0f, Time.deltaTime);
            yield return null;
        }
    }
}
