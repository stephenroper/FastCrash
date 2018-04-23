using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    public GameObject[] Buildings;
    private List<GameObject> _buildingPool;
    public int buildingAmount;

    public float WaitForNextMax;
    public float CountDown;

    private Transform _spawnerTransform;

    private Tools _tools;


	// Use this for initialization
	void Start () {
        _tools = new Tools();
        _spawnerTransform = GetComponent<Transform>();
        _buildingPool = new List<GameObject>();
        foreach (var building in Buildings)
        {
            for (int i = 0; i < buildingAmount; i++)
            {
                GameObject obj = Instantiate(building);
                obj.SetActive(false);
                _buildingPool.Add(obj);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        CountDown -= Time.deltaTime;
        if (CountDown <= 0)
        {
            _tools.SpawnObjFromPoolRandom(_buildingPool, _spawnerTransform);
            CountDown = Random.Range(1, WaitForNextMax);
        }
	}
}
