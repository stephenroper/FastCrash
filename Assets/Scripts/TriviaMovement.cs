using UnityEngine;

public class TriviaMovement : MonoBehaviour {
    
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime );

        if (transform.position.x <= -9.35)
        {
            Destroy(gameObject);
        }
    }
}
