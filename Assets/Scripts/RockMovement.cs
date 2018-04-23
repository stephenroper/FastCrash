using UnityEngine;

public class RockMovement : MonoBehaviour {
    
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime );

        if (transform.position.x <= -8.59)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Animation
            CollisionController.Get().SpawnExploder(transform.position);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player")
        {
            //Animation
            CollisionController.Get().SpawnExploder(transform.position);
            Player.Get().RockCrashCash();
            gameObject.SetActive(false);
        }
    }
}
