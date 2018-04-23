using System.Collections;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    static private CollisionController _singleton = null;
    static public CollisionController Get() { return _singleton; }

    [SerializeField]
    private GameObject _rockBoom = null;

    private void Awake()
    {
        _singleton = this;
    }

    public void SpawnExploder(Vector3 pos)
    {
        GameObject boom = Instantiate(_rockBoom);
        boom.transform.position = pos;
    }

    IEnumerator DestroyExploder(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
