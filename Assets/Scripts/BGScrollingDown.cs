﻿using UnityEngine;

public class BGScrollingDown : MonoBehaviour {

    private Rigidbody2D _rigidBody;
    [SerializeField]
    private bool _stopScrolling;

    public float Speed = 0.5F;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_stopScrolling)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else
        {
            _rigidBody.transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
    }
}
