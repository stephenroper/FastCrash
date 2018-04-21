using UnityEngine;

public class Player : MonoBehaviour {

    private static Player Singleton;
    static public Player Get() { return Singleton; }

    private Player _player = null;

    public float speed;
    private float _step;
    private bool _moveDown = false;
    private bool _moveUp = false;

    private bool _keyUp() { return (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)); }
    private bool _keyDown() { return (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)); }
    private bool _keyShoot() { return Input.GetKeyDown(KeyCode.Space); }

    public Transform _rowA;
    public Transform _rowB;
    public Transform _rowC;
    public Transform _rowD;

    public char row;

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
        transform.position = new Vector2(-4,_rowB.position.y);
        row = 'B';
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update () {
        _step = speed * Time.deltaTime;
        UPdatePlayer();
    }

    private float DeterminePlayerPosition(Vector3 pos)
    {
        if (_keyUp())
        {
            if (pos.y == _rowA.position.y)
            {
                return _rowA.position.y;
            }
            if (pos.y == _rowB.position.y)
            {
                return _rowA.position.y;
            }
            if (pos.y == _rowC.position.y)
            {
                return _rowB.position.y;
            }
            if (pos.y ==  _rowD.position.y)
            {
                return _rowC.position.y;
            }
        }

        if (_keyDown())
        {
            if (pos.y == _rowA.position.y)
            {
                return _rowB.position.y;
            }
            if (pos.y == _rowB.position.y)
            {
                return _rowC.position.y;
            }
            if (pos.y == _rowC.position.y)
            {
                return _rowD.position.y;
            }
            if (pos.y == _rowD.position.y)
            {
                return _rowD.position.y;
            }
        }
        return pos.y;
    }

    private void UPdatePlayer()
    {
        #region Move Up
        if (_keyUp() && (_moveDown == false) && (transform.position.y != _rowA.position.y))
        {
            _moveUp = true;
        }
        //B to A
        if (_moveUp && (transform.position.y >= _rowB.position.y && transform.position.y < _rowA.position.y) )
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, _rowA.position.y), _step);

            if (transform.position.y == _rowA.position.y)
            {
                _moveUp = false;
                row = 'A';
            }
        }
        //C To B
        if (_moveUp && (transform.position.y >= _rowC.position.y && transform.position.y < _rowB.position.y))
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, _rowB.position.y), _step);

            if (transform.position.y == _rowB.position.y)
            {
                _moveUp = false;
                row = 'B';
            }
        }
        //D to C
        if (_moveUp && (transform.position.y >= _rowD.position.y && transform.position.y < _rowC.position.y))
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, _rowC.position.y), _step);

            if (transform.position.y == _rowC.position.y)
            {
                _moveUp = false;
                row = 'C';
            }
        }

        #endregion

        #region Move Down
        if (_keyDown() && (_moveUp == false) && (transform.position.y != _rowD.position.y))
        {
            _moveDown = true;
        }
        //C to D
        if (_moveDown && (transform.position.y <= _rowC.position.y && transform.position.y > _rowD.position.y))
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, _rowD.position.y), _step);

            if (transform.position.y == _rowD.position.y)
            {
                _moveDown = false;
                row = 'D';
            }
        }
        //B to C
        if (_moveDown && (transform.position.y <= _rowB.position.y && transform.position.y > _rowC.position.y))
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, _rowC.position.y), _step);

            if (transform.position.y == _rowC.position.y)
            {
                _moveDown = false;
                row = 'C';
            }
        }
        //A to B
        if (_moveDown && (transform.position.y <= _rowA.position.y && transform.position.y > _rowB.position.y))
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, _rowB.position.y), _step);

            if (transform.position.y == _rowB.position.y)
            {
                _moveDown = false;
                row = 'B';
            }
        }
        #endregion
    }
}
