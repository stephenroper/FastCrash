using UnityEngine;

public class Bullet : MonoBehaviour {
    public float Speed;
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
	}

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
