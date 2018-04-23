using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMove : MonoBehaviour {

    private float speed = 3f;
    private Vector3 cardPos;
    private Vector3 zmPos;
    public GameObject zamMac;

	// Use this for initialization
	void Start () {
        cardPos = new Vector3 (0.05f,3.01f,-5);
        zmPos = new Vector3(25f, .78f, -5);
        zamMac = GameObject.Find("LOGOzmgames");
		
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(MoveTitle());

    }

    IEnumerator MoveTitle()
    {
        yield return new WaitForSeconds(4f);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, cardPos, step);
        zamMac.transform.position = Vector3.MoveTowards(zamMac.transform.position, zmPos, step);
        //GameObject.Destroy(zmLogo);
    }
}
