using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource drivingMusic;
    public static AudioSource shoot1;
    public AudioSource shoot2;
    public AudioSource shoot3;
    public static AudioSource hitEnemy;
    public static AudioSource crash;
    public static AudioSource correct;
    public static AudioSource incorrect;
    public static AudioSource pickup;

    private float _startVolume;
    private float _rng;

    private bool _space() {return Input.GetKeyDown(KeyCode.Space); }

    void Awake ()
    {
        if (GameObject.Find("StoryController") != null)
        {
            if (AudioControllerStory.storyMusic.isPlaying == true)
            {
                AudioControllerStory.storyMusic.Stop();
            }
        }


        AudioSource[] audio = GetComponents<AudioSource>();
        shoot1 = audio[0];
        shoot2 = audio[1];
        shoot3 = audio[2];
        hitEnemy = audio[3];
        crash = audio[4];
        correct = audio[5];
        incorrect = audio[6];
        drivingMusic = audio[7];
        pickup = audio[8];

        _startVolume = 0.3f;
        drivingMusic.volume = 0.6f;
        StartVolume();
        drivingMusic.loop = true;
    }

    // Use this for initialization
    void Start () {
        drivingMusic.Play();
	}
	
	// Update is called once per frame
	void Update () {

        //if (_space())
        //{
        //    _rng = Random.Range(1, 100);
        //    Debug.Log(_rng);

        //    if (_rng > 50)
        //    {
        //        shoot1.Play();
        //    }
        //    else
        //    {
        //        shoot3.Play();
        //    }

        //}
		
	}

    private void StartVolume()
    {
        shoot1.volume = _startVolume;
        shoot2.volume = _startVolume;
        shoot3.volume =  _startVolume;
        hitEnemy.volume =  _startVolume;
        crash.volume = _startVolume;
        correct.volume =  _startVolume;
        incorrect.volume = _startVolume;
        pickup.volume = _startVolume;

    }
}
