using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {
    //Collet Rock Objects
    public GameObject[] Rocks;

    //Rock Pools and Amounts
    private List<GameObject> _rockPool;
    public int RockAmountTotal;
    public int cashAmountTotal;

    //Time to Spawn Rocks
    public float WaitForNextMax;
    public float CountDown;

    private Vector3 _pos;

    private Tools _tools;

    private Transform _spawnerTransform;

	// Use this for initialization
	void Start () {
        _spawnerTransform = GetComponent<Transform>();
        _tools = new Tools();

        #region Cash And Rock Object Creation to pool List
        _rockPool = new List<GameObject>();
        foreach (var rock in Rocks)
        {
            if (rock.tag == "Cash")
            {
                for (int i = 0; i < cashAmountTotal; i++)
                {
                    GameObject obj = Instantiate(rock);
                    obj.SetActive(false);
                    _rockPool.Add(obj);
                }
            }
            if (rock.tag == "Rock")
            {
                for (int i = 0; i < RockAmountTotal; i++)
                {
                    GameObject obj = Instantiate(rock);
                    obj.SetActive(false);
                    _rockPool.Add(obj);
                }
            }
        }
        #endregion
    }

    // Update is called once per frame
    void Update () {
        CountDown -= Time.deltaTime;
        if (CountDown <= 0)
        {
            _tools.SpawnObjFromPoolRandomRocks(_rockPool,_spawnerTransform);
            CountDown = Random.Range(1, WaitForNextMax);
        }
	}
}
