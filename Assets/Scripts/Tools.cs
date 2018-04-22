using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tools
    {
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

        public void SpawnObjFromPool(List<GameObject> objPool, Transform transform)
        {
            if (objPool != null)
            {
                GameObject obj = GetPooledObject(objPool);
                if (obj != null)
                {
                    //Activate Pooled Obj
                    var pos = new Vector2(transform.position.x, transform.position.y);
                    obj.transform.position = pos;
                    obj.SetActive(true);
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
                    var pos = new Vector2(transform.position.x, transform.position.y);
                    gameObj.transform.position = pos;
                    gameObj.SetActive(true);
                }
            }
        }

        public void SpawnObjFromPoolRandomRocks(List<GameObject> objPool, Transform transform)
        {
            if (objPool != null)
            {
                GameObject gameObj = objPool[Random.Range(0, objPool.Count)];

                if (!gameObj.activeInHierarchy)
                {
                    if (gameObj.tag == "Cash")
                    {
                        var cashVisible = GameObject.FindGameObjectsWithTag("Cash");
                        if (cashVisible.Length < 2)
                        {
                            InstantiateObject(gameObj, transform);
                        }
                    }
                    InstantiateObject(gameObj, transform);
                }
            }
        }

        private void InstantiateObject(GameObject gameObj, Transform transform)
        {
            var pos = new Vector2(transform.position.x, transform.position.y);
            gameObj.transform.position = pos;
            gameObj.SetActive(true);
        }
    }
}
