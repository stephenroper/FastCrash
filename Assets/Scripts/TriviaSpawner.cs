using Assets.Scripts;
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

    [SerializeField]
    private GameObject Lights;
    private Animator _lightsAnim;
    private bool startLightTime = false;
    private float _blinkTimer = 3f;
    private bool _canGreenBlink = false;
    private bool _canRedBlink = false;

    private void Awake()
    {
        Singleton = this;
    }

    void Start () {
        _tools = new Tools();
        _lightsAnim = Lights.GetComponent<Animator>();
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
        if (startLightTime)
        {
            _blinkTimer -= Time.deltaTime;
            if (_canGreenBlink)
            {
                _lightsAnim.Play("day4lightgreen");
                if (_blinkTimer <= 0)
                {
                    _lightsAnim.Play("StillGreen");
                }
            }
            else if (_canRedBlink)
            {
                _lightsAnim.Play("Day4RedLights");
                if (_blinkTimer <= 0)
                {
                    _lightsAnim.Play("StillGreen");
                }
            }
            else
            {
                _lightsAnim.Play("StillGreen");
            }
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
                VerifyAnswerA();
            }
            if (question == 1)
            {
                VerifyAnswerC();
            }
            if (question == 2)
            {
                VerifyAnswerD();
            }
            if (question == 3)
            {
                VerifyAnswerB();
            }
            if (question == 4)
            {
                VerifyAnswerC();
            }
            if (question == 5)
            {
                VerifyAnswerB();
            }
            if (question == 6)
            {
                VerifyAnswerC();
            }
            if (question == 7)
            {
                VerifyAnswerA();
            }
            if (question == 8)
            {
                VerifyAnswerD();
            }
            if (question == 9)
            {
                VerifyAnswerA();
            }
            if (question == 10)
            {
                VerifyAnswerA();
            }
            if (question == 11)
            {
                VerifyAnswerB();
            }
            if (question == 12)
            {
                VerifyAnswerB();
            }
            if (question == 13)
            {
                VerifyAnswerA();
            }
            if (question == 14)
            {
                VerifyAnswerB();
            }
        }
    }

    private void VerifyAnswerA()
    {
        var row = Player.Get().Row;
        if (row != 'A')
        {
            Player.Get().AnswerWrong();
            _canRedBlink = true;
        }
        else
        {
            Player.Get().AnswerCorrent();
            _canGreenBlink = true;
        }
    }

    private void VerifyAnswerB()
    {
        var row = Player.Get().Row;
        if (row != 'B')
        {
            Player.Get().AnswerWrong();
            _canRedBlink = true;
        }
        else
        {
            Player.Get().AnswerCorrent();
            _canGreenBlink = true;
        }
    }

    private void VerifyAnswerC()
    {
        var row = Player.Get().Row;
        if (row != 'C')
        {
            Player.Get().AnswerWrong();
            _canRedBlink = true;
        }
        else
        {
            Player.Get().AnswerCorrent();
            _canGreenBlink = true;
        }
    }

    private void VerifyAnswerD()
    {
        var row = Player.Get().Row;
        if (row != 'D')
        {
            Player.Get().AnswerWrong();
            _canRedBlink = true;
        }
        else
        {
            Player.Get().AnswerCorrent();
            _canGreenBlink = true;
        }
    }
}
