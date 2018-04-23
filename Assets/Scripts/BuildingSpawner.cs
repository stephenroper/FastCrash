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

	// Use this for initialization
	void Start () {
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
            SpawnObjFromPoolRandom(_buildingPool, _spawnerTransform);
            CountDown = Random.Range(1, WaitForNextMax);
        }
	}

    private void SpawnObjFromPoolRandom(List<GameObject> objPool, Transform transform)
    {
        if (objPool != null)
        {
            GameObject gameObj = objPool[Random.Range(0, objPool.Count)];
            if (!gameObj.activeInHierarchy)
            {
                InstantiateObject(gameObj, transform);
            }
        }
    }
    private void InstantiateObject(GameObject gameObj, Transform transform)
    {
        Vector2 pos;
        if (gameObj.tag == "Building1")
        {
            pos = new Vector2(transform.position.x, transform.position.y + 1.65f);
        }
        else
        {
            pos = new Vector2(transform.position.x, transform.position.y);
        }
        
        gameObj.transform.position = pos;
        gameObj.SetActive(true);
    }
}
