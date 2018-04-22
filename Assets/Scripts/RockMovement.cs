using UnityEngine;

public class RockMovement : MonoBehaviour {

    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime );
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }
}
