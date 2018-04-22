using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControllerTitle : MonoBehaviour {

    public AudioSource titleMusic;
    public AudioSource select;

    private float _startVolume = 0.2f;

    private bool _space() { return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space); }
    private bool _select;


    void Awake ()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        titleMusic = audio[0];
        select = audio[1];

        _select = false;
        StartVolume();
    }

    // Use this for initialization
    void Start () {

        titleMusic.Play();
		
	}
	
	// Update is called once per frame
	void Update () {

        if ((_space() == true) && (_select == false))
        {
            titleMusic.Stop();
            select.Play();
            _select = true;
            StartCoroutine(WaitForNextScene());
        }
		
	}

    private void StartVolume()
    {
        titleMusic.volume = _startVolume;
        select.volume = _startVolume;
    }

    IEnumerator WaitForNextScene()
    {
        Debug.Log("Entered Coroutine.");
        yield return new WaitForSeconds(3f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("Story");
    }

}
