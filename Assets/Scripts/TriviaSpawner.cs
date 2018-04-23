using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaSpawner : MonoBehaviour {

    public GameObject[] Questions;
    private List<GameObject> _questionPool;

    private Transform _spawnerTransform;

    public float WaitForNextMax;
    public float CountDown;

    private Player _player;
    private Tools _tools;

    public float _quesitonTime = 5f;
    public float _questionTimeNext;
    private bool _startQuestionTime;

    private int? _questionNum;

    void Start () {
        _tools = new Tools();
        _player = new Player();
        _questionPool = new List<GameObject>();
        _spawnerTransform = GetComponent<Transform>();
        _startQuestionTime = false;
        foreach (var question in Questions)
        {
            GameObject obj = Instantiate(question);
            obj.SetActive(false);
            _questionPool.Add(obj);
        }
	}
	
	void Update () {

        CountDown -= Time.deltaTime;

        if (CountDown <= 0 && _questionPool.Count != 0)
        {
            _questionNum = _tools.SpawnObjFromPoolRandomGetRangeValue(_questionPool, _spawnerTransform);
            _startQuestionTime = true;
        }

        if (_startQuestionTime)
        {
            _quesitonTime -= Time.deltaTime;
        }

        if (_quesitonTime <= 0 && _questionPool.Count != 0)
        {
            VerifyAnswer(_questionNum);
            _quesitonTime = _questionTimeNext;
            CountDown = WaitForNextMax;
            _startQuestionTime = false;
        }
    }

    public void VerifyAnswer(int? question)
    {
        if (question != null)
        {
            if (question == 0)
            {
                if (_player.Row != 'A')
                {
                    _player.AnswerWrong();
                }
                _player.AnswerCorrent();
            }
            if (question == 1)
            {
                if (_player.Row != 'C')
                {
                    _player.AnswerWrong();
                }
                _player.AnswerCorrent();
            }
            if (question == 2)
            {
                if (_player.Row != 'D')
                {
                    _player.AnswerWrong();
                }
                _player.AnswerCorrent();
            }
            if (question == 3)
            {
                if (_player.Row != 'B')
                {
                    _player.AnswerWrong();
                }
                _player.AnswerCorrent();
            }
        }
    }
}
