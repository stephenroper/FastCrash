﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControllerStory : MonoBehaviour {

    public static AudioSource storyMusic;
    public static AudioSource select;

    private float _startVolume = 0.5f;


    //private bool _space() { return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space); }
    //private bool _select;


    void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);

        AudioSource[] audio = GetComponents<AudioSource>();
        storyMusic = audio[0];
        select = audio[1];

        //_select = false;
        StartVolume();
        storyMusic.loop = true;
    }

    // Use this for initialization
    void Start () {

        if (!storyMusic.isPlaying)
        {
            storyMusic.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //if ((_space() == true) && (_select == false))
        //{
        //    storyMusic.Stop();

        //    StartCoroutine(FadeOut(storyMusic, 4f));

        //    select.Play();
        //    _select = true;
        //    StartCoroutine(WaitForNextScene());

        //}
    }

    public void StartVolume()
    {
        storyMusic.volume = _startVolume;
        select.volume = _startVolume;
    }

    //IEnumerator WaitForNextScene()
    //{
    //    Debug.Log("Entered Coroutine.");
    //    yield return new WaitForSeconds(4.5f);
    //    Debug.Log("Loading Scene");
    //    SceneManager.LoadScene("JTest");
    //}

    //public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    //{
    //    float startVolume = audioSource.volume;

    //    while (audioSource.volume > 0)
    //    {
    //        audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

    //        yield return null;
    //    }

    //    audioSource.Stop();
    //    audioSource.volume = startVolume;
    //}
}
