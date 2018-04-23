using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaSpawner : MonoBehaviour {

    private static TriviaSpawner Singleton;
    static public TriviaSpawner Get() { return Singleton; }

    public GameObject[] Questions;
    public List<GameObject> questionPool;

    private Transform _spawnerTransform;

    public float WaitForNextMax;
    public float CountDown;

    public float questionTimer;
    public float WaitforNextQuestion;

    private Tools _tools;

    public int? questionNum;

    [SerializeField]
    private TextMesh _timerGui = null;
    [SerializeField]
    private TextMesh _questionOutOfText = null;
    private int _questionOutOf;

    private void Awake()
    {
        Singleton = this;
    }

    void Start () {
        _tools = new Tools();
        questionPool = new List<GameObject>();
        _spawnerTransform = GetComponent<Transform>();
        _questionOutOf = 0;
        foreach (var question in Questions)
        {
            GameObject obj = Instantiate(question);
            obj.SetActive(false);
            questionPool.Add(obj);
        }
	}

    private void FixedUpdate()
    {
       
    }

    void Update () {

        CountDown -= Time.deltaTime;
        questionTimer -= Time.deltaTime;
        _timerGui.text = Mathf.Round(questionTimer).ToString();
        _questionOutOfText.text = _questionOutOf.ToString();

        if (CountDown <= 0 && questionPool.Count != 0 && _questionOutOf <= 10)
        {
            _questionOutOf += 1;
            questionNum = _tools.SpawnObjFromPoolRandomGetRangeValue(questionPool, _spawnerTransform);           
            CountDown = WaitForNextMax;
        }
        if (questionTimer <= 0)
        {
            VerifyAnswer(questionNum);
            questionTimer = WaitforNextQuestion;
        }

        //Go to End Scene
        if (_questionOutOf > 10)
        {
            //Goto End Scene
        }
    }

    public void VerifyAnswer(int? question)
    {       
        if (question != null)
        {
            if (question == 0)
            {
                var row = Player.Get().Row;
                if (row != 'A')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 1)
            {
                var row = Player.Get().Row;
                if (row != 'C')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 2)
            {
                var row = Player.Get().Row;
                if (row != 'D')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                } 
            }
            if (question == 3)
            {
                var row = Player.Get().Row;
                if (row != 'B')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 4)
            {
                var row = Player.Get().Row;
                if (row != 'C')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 5)
            {
                var row = Player.Get().Row;
                if (row != 'B')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 6)
            {
                var row = Player.Get().Row;
                if (row != 'C')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 7)
            {
                var row = Player.Get().Row;
                if (row != 'A')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 8)
            {
                var row = Player.Get().Row;
                if (row != 'D')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 9)
            {
                var row = Player.Get().Row;
                if (row != 'A')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 10)
            {
                var row = Player.Get().Row;
                if (row != 'A')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 11)
            {
                var row = Player.Get().Row;
                if (row != 'B')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 12)
            {
                var row = Player.Get().Row;
                if (row != 'B')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 13)
            {
                var row = Player.Get().Row;
                if (row != 'A')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
            if (question == 14)
            {
                var row = Player.Get().Row;
                if (row != 'B')
                {
                    Player.Get().AnswerWrong();
                }
                else
                {
                    Player.Get().AnswerCorrent();
                }
            }
        }
    }
}
