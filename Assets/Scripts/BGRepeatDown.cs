using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRepeatDown : MonoBehaviour {

    private BoxCollider2D _backgroundCollider;
    private float _bgSize;

    // Use this for initialization
    void Start()
    {
        _backgroundCollider = GetComponent<BoxCollider2D>();
        _bgSize = _backgroundCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _bgSize)
        {
            RepeatBG();
        }
    }

    void RepeatBG()
    {
        Vector3 bgOffset = new Vector3(0, _bgSize * 2f);
        transform.position -= bgOffset;
    }
}
