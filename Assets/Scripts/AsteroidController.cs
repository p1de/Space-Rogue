using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Sprite asteroid1;
    public Sprite asteroid2;
    private Vector2 screenBounds;
    private Vector3 direction;
    private float movementSpeed;
    private float rotationRate;

    void Start()
    {
        movementSpeed = Random.Range(2f, 10f);

        if (Random.Range(0.0f, 1.0f) > 0.5f)
            sr.sprite = asteroid1;
        else
            sr.sprite = asteroid2;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        /* spawnSide
         * 1 - right
         * 2 - down
         * 3 - left
         * 4 - up
         */
        int spawnSide = Random.Range(1, 5); // range is 1 to 4 since 5 is exclusive

        switch (spawnSide)
        {
            // right
            case 1:
                transform.position = new Vector3(
                    Random.Range(screenBounds.x + 1, screenBounds.x + 2),
                    Random.Range(-screenBounds.y, screenBounds.y),
                    0);
                break;
            // down
            case 2:
                transform.position = new Vector3(
                    Random.Range(-screenBounds.x, screenBounds.x),
                    Random.Range(-screenBounds.y - 2, - screenBounds.y - 1),
                    0);
                break;
            // left
            case 3:
                transform.position = new Vector3(
                    Random.Range(-screenBounds.x - 2, -screenBounds.x - 1),
                    Random.Range(-screenBounds.y, screenBounds.y),
                    0);
                break;
            // up
            case 4:
                transform.position = new Vector3(
                    Random.Range(-screenBounds.x, screenBounds.x),
                    Random.Range(screenBounds.y + 1, screenBounds.y + 2),
                    0);
                break;
        }

        // Generate a random point inside camera view
        direction = new Vector3(Random.Range(-screenBounds.x, screenBounds.x),
                                Random.Range(-screenBounds.y, screenBounds.y),
                                0);
        // Calculate a vector pointing from asteroid position to that point
        direction -= transform.position;

        // Normalize the vector so that it can be scale by movement speed
        direction.Normalize();

        // Generate random rotation rate for the asteroid
        rotationRate = Random.Range(45, 360);

        // Generate random scale for the asteroid
        float scale = Random.Range(0.5f, 3.0f);
        transform.localScale = new Vector3(scale, scale, 1);

        rb.mass = scale;

        rb.angularVelocity = rotationRate;
        rb.velocity = direction * movementSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
