using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMove : MonoBehaviour {

    private bool _move;
    private float speed = 3f;
    private Vector3 cardPos;
    private Vector3 zmPos;
    public GameObject zamMac;
    public GameObject start;

	// Use this for initialization
	void Start () {
        _move = false;
        cardPos = new Vector3 (0.05f,3.01f,-5);
        zmPos = new Vector3(25f, .78f, -5);
        zamMac = GameObject.Find("LOGOzmgames");
        start = GameObject.Find("space2start");
        start.SetActive(false);
        StartCoroutine(StartAnim());
		
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(MoveTitle());

        if (_move == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, cardPos, step);
            zamMac.transform.position = Vector3.MoveTowards(zamMac.transform.position, zmPos, step);
        }

    }

    IEnumerator MoveTitle()
    {
        yield return new WaitForSeconds(4f);
        _move = true;

        //GameObject.Destroy(zmLogo);
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(8.6f);
        start.SetActive(true);
    }
}
