using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {


    public AudioSource shoot1;
    public AudioSource shoot2;
    public AudioSource shoot3;
    public AudioSource hitEnemy;
    public AudioSource crash;
    public AudioSource correct;
    public AudioSource incorrect;


    void Awake ()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        shoot1 = audio[0];
        shoot2 = audio[1];
        shoot3 = audio[2];
        hitEnemy = audio[3];
        crash = audio[4];
        correct = audio[5];
        incorrect = audio[6];
    }

    // Use this for initialization
    void Start () {
        shoot1.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
