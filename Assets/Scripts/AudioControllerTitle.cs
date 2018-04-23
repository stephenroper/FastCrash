using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControllerTitle : MonoBehaviour {


    public GameObject zmLogo;

    public AudioSource titleMusic;
    public AudioSource select;

    private float _startVolume = 0.2f;

    private bool _space() { return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space); }
    private bool _select;


    void Awake ()
    {
        zmLogo = GameObject.Find("LOGOzmgames");
        AudioSource[] audio = GetComponents<AudioSource>();
        titleMusic = audio[0];
        select = audio[1];

        titleMusic.loop = true;
        _select = true;
        StartVolume();
    }

    // Use this for initialization
    void Start () {

        titleMusic.Play();

        StartCoroutine(WaitToProgress());
        //StartCoroutine(DestroyZMLogo());

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

    IEnumerator WaitToProgress()
    {
        yield return new WaitForSeconds(8.6f);
        _select = false;
    }

    IEnumerator WaitForNextScene()
    {
        Debug.Log("Entered Coroutine.");
        yield return new WaitForSeconds(3f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("Story");
    }

    //IEnumerator DestroyZMLogo()
    //{
    //    yield return new WaitForSeconds(5.8f);

    //    zmLogo.SetActive(false);
    //    //GameObject.Destroy(zmLogo);
    //}

}
