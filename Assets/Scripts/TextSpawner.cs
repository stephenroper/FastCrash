using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawner : MonoBehaviour {

    private bool _space() { return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space); }

    public GameObject SpeechBubble;
    public GameObject[] Text;
    public List<GameObject> textPool;

    private Transform _spawnerTransform;
    private Tools _tools;

    private int _previous;
    private int _textOutOf;

    // Use this for initialization
    void Start () {

        SpeechBubble = GameObject.Find("TextBubble_000");
        _spawnerTransform = SpeechBubble.transform;

        _tools = new Tools();
        textPool = new List<GameObject>();

        _textOutOf = 0;
        _previous = 0;

        foreach (var text in Text)
        {
            GameObject obj = Instantiate(text);
            obj.SetActive(false);
            textPool.Add(obj);
        }

    }
	
	// Update is called once per frame
	void Update () {

        if ((_space()) && textPool.Count != 0 && _textOutOf <= 16)
        {
            Debug.Log(textPool.Count);


            _textOutOf += 1;
            _tools.SpawnObjFromPool(textPool, _spawnerTransform);
            textPool[_textOutOf - 1].transform.position = new Vector3 (1.6f, -.55f, 0);

            if (_textOutOf >= 2 && _textOutOf <= 16)
            {
                textPool[_previous].transform.position = new Vector3(100, 100, 0);
                _previous++;
            }

            if (_textOutOf == 16)
            {
                textPool[16].transform.position = new Vector3(100, 100, 0);
                SpeechBubble.transform.position = new Vector3(100, 100, 0);

            }

        }

    }
}
