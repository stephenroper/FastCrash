using UnityEngine;

public class Player : MonoBehaviour {

    private static Player Singleton;
    static public Player Get() { return Singleton; }

    private Player _player = null;

    public float speed;
    public float yPos;

    private bool _keyUp() { return (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)); }
    private bool _keyDown() { return (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)); }
    private bool _keyShoot() { return Input.GetKeyDown(KeyCode.Space); }

    private float _outterRowY = 2.85f;
    private float _secondRowY = 1.44f;
    private float _middleRowY = 0f;

    private float _firstLineY = 3.61f;
    private float _secondLineY = 2.16f;
    private float _thirdLineY = 0.71f;

    public GameObject[] Bullets;
    private float _waitForNext = 0;
    public float shootTimer;

    public void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _player = Get();
    }

    // Update is called once per frame
    void Update () {
        UpdatePlayerMovement();

        #region Re-align Player to Row
        //realign Top row
        if (transform.position.y < _firstLineY && transform.position.y > _secondLineY)
        {
            transform.position = new Vector3(transform.position.x, _outterRowY);
        }
        //realign Second top Row
        if (transform.position.y < _secondLineY && transform.position.y > _thirdLineY)
        {
            transform.position = new Vector3(transform.position.x, _secondRowY);
        }
        //realign Middle Row
        if (transform.position.y < _thirdLineY && transform.position.y > -_thirdLineY)
        {
            transform.position = new Vector3(transform.position.x, _middleRowY);
        }
        //realign Second bottom Row
        if (transform.position.y > -_secondLineY && transform.position.y < -_thirdLineY)
        {
            transform.position = new Vector3(transform.position.x, -_secondRowY);
        }
        //realign Bottom row
        if (transform.position.y > -_firstLineY && transform.position.y < -_secondLineY)
        {
            transform.position = new Vector3(transform.position.x, -_outterRowY);
        }
        #endregion

        
    }

    private void UpdatePlayerMovement()
    {
        //Player Movement Y
        if (transform.position.y < _outterRowY && _keyUp())
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y + yPos), speed * Time.deltaTime);
        }
        if (transform.position.y > -_outterRowY && _keyDown())
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y - yPos), speed * Time.deltaTime);
        }
    }
}
