using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageController : MonoBehaviour {

    private bool _clicked;
    private bool _sound;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    public Transform door1Target;
    //public Transform door2Target;
    //public Transform door3Target;


    private float speed = .75f;

    string clickedDoor;

    // Use this for initialization
    void Start () {
        _clicked = false;
        _sound = true;

        door1 = GameObject.Find("Background-GameShow-Doors");
        door2 = GameObject.Find("Background-GameShow-Doors (1)");
        door3 = GameObject.Find("Background-GameShow-Doors (2)");
        
    }
	
	// Update is called once per frame
	void Update () {

        if (_clicked == true)
        {
            GarageUp();
            //_clicked = false;

        if (_sound == true)
            {

                StartCoroutine(FadeOut(AudioControllerStory.storyMusic, 4f));
                //_select = true;
                StartCoroutine(WaitForNextScene());
                AudioControllerStory.select.Play();
                _sound = false;
            }

        }
    }

    public void OnMouseDown()
    {
        _clicked = true;

        Debug.Log("Clicked: " + _clicked);
        //Debug.Log("Clicked door " + this);
    }

    void GarageUp()
    {


        if (gameObject == door1)
        {
            float step = speed * Time.deltaTime;
            door2.GetComponent<GarageController>().enabled = false;
            door3.GetComponent<GarageController>().enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, door1Target.position, step);

            //door2.SetActive(false);
            //door3.SetActive(false);
        }
        else if (gameObject == door2)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, door1Target.position, step);
            door1.GetComponent<GarageController>().enabled = false;
            door3.GetComponent<GarageController>().enabled = false;
            //door1.SetActive(false);
            //door3.SetActive(false);
        }
        else if (gameObject == door3)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, door1Target.position, step);
            door2.GetComponent<GarageController>().enabled = false;
            door1.GetComponent<GarageController>().enabled = false;
            //door1.SetActive(false);
            //door2.SetActive(false);
        }
    }


    IEnumerator WaitForNextScene()
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("JTest");
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }


}
