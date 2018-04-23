using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tools
    {
        public void SpawnObjFromPool(List<GameObject> objPool, Transform transform)
        {
            if (objPool != null)
            {
                GameObject obj = GetPooledObject(objPool);
                if (obj != null)
                {
                    InstantiateObject(obj, transform);
                }
            }
        }

        public void SpawnObjFromPoolRandom(List<GameObject> objPool, Transform transform)
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

        public int? SpawnObjFromPoolRandomGetRangeValue(List<GameObject> objPool, Transform transform)
        {
            if (objPool != null)
            {
                var randRange = Random.Range(0, objPool.Count);
                GameObject gameObj = objPool[randRange];
                InstantiateObject(gameObj, transform);
                return randRange;
            }
            return null;
        }

        public void SpawnObjFromPoolRandomRocks(List<GameObject> objPool, Transform transform)
        {
            if (objPool != null)
            {
                GameObject gameObj = objPool[Random.Range(0, objPool.Count)];
                if (gameObj.tag == "Rock")
                {
                    if (!gameObj.activeInHierarchy)
                    {
                        InstantiateObject(gameObj, transform);
                    }
                }
                if (gameObj.tag == "Cash")
                {
                    if (!gameObj.activeInHierarchy)
                    {
                        var cashVisible = GameObject.FindGameObjectsWithTag("Cash");
                        if (cashVisible.Length <= 1)
                        {
                            InstantiateObject(gameObj, transform);
                        }
                    } 
                }
            }
        }

        private GameObject GetPooledObject(List<GameObject> objectPool)
        {
            for (int i = 0; i < objectPool.Count; i++)
            {
                if (!objectPool[i].activeInHierarchy)
                {
                    return objectPool[i];
                }
            }
            return null;
        }

        private void InstantiateObject(GameObject gameObj, Transform transform)
        {
            var pos = new Vector2(transform.position.x, transform.position.y);
            gameObj.transform.position = pos;
            gameObj.SetActive(true);
        }
    }
}
