using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public string _question;

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
        _questionOutOfText.text = _questionOutOf.ToString();


        if (questionTimer >= 20f)
        {
            _timerGui.text = 20f.ToString();
        }
        else if (questionTimer <= 0)
        {
            _timerGui.text = 0f.ToString();
        }
        else
        {
            _timerGui.text = Mathf.Round(questionTimer).ToString();
        }      

        if (CountDown <= 0 && questionPool.Count != 0 && _questionOutOf <= 10 )
        {
            _questionOutOf += 1;
            _question = _tools.SpawnObjFromPoolRandomGetRangeValue(questionPool, _spawnerTransform);
            CountDown = WaitForNextMax;
        }

        if (questionTimer <= 0)
        {
            VerifyAnswer(_question);
            questionTimer = WaitforNextQuestion;
        }

        //Go to End Scene
        if (_questionOutOf > 10)
        {
            //Goto End Scene
            SceneManager.LoadScene("End");
        }
    }

    public void VerifyAnswer(string question)
    {       
        if (question != null)
        {
            if (question.Contains("Trivia01"))
            {
                VerifyAnswerA();
            }
            if (question.Contains("Trivia02"))
            {
                VerifyAnswerC();
            }
            if (question.Contains("Trivia03"))
            {
                VerifyAnswerD();
            }
            if (question.Contains("Trivia04"))
            {
                VerifyAnswerB();
            }
            if (question.Contains("Trivia05"))
            {
                VerifyAnswerC();
            }
            if (question.Contains("Trivia06"))
            {
                VerifyAnswerB();
            }
            if (question.Contains("Trivia07"))
            {
                VerifyAnswerC();
            }
            if (question.Contains("Trivia08"))
            {
                VerifyAnswerA();
            }
            if (question.Contains("Trivia09"))
            {
                VerifyAnswerD();
            }
            if (question.Contains("Trivia10"))
            {
                VerifyAnswerA();
            }
            if (question.Contains("Trivia11"))
            {
                VerifyAnswerA();
            }
            if (question.Contains("Trivia12"))
            {
                VerifyAnswerB();
            }
            if (question.Contains("Trivia13"))
            {
                VerifyAnswerB();
            }
            if (question.Contains("Trivia14"))
            {
                VerifyAnswerA();
            }
            if (question.Contains("Trivia15"))
            {
                VerifyAnswerB();
            }
        }
    }

    private void VerifyAnswerA()
    {
        var row = Player.Get().Row;
        Debug.Log("PLayer is in ROw: " + row.ToString());
        if (row != 'A')
        {
            Player.Get().AnswerWrong();
        }
        else
        {
            Player.Get().AnswerCorrent();
        }
    }

    private void VerifyAnswerB()
    {
        var row = Player.Get().Row;
        Debug.Log("PLayer is in ROw: " + row.ToString());
        if (row != 'B')
        {
            Player.Get().AnswerWrong();
        }
        else
        {
            Player.Get().AnswerCorrent();
        }
    }

    private void VerifyAnswerC()
    {
        var row = Player.Get().Row;
        Debug.Log("PLayer is in ROw: " + row.ToString());
        if (row != 'C')
        {
            Player.Get().AnswerWrong();
        }
        else
        {
            Player.Get().AnswerCorrent();
        }
    }

    private void VerifyAnswerD()
    {
        var row = Player.Get().Row;
        Debug.Log("PLayer is in ROw: " + row.ToString());
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
