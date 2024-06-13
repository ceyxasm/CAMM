using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    private Vector2 screenBounds;

    public void Initialize(float minSpeed, float maxSpeed, Vector2 screenBounds)
    {
        this.screenBounds = screenBounds;
        speed = Random.Range(minSpeed, maxSpeed);
        direction = Random.insideUnitCircle.normalized; // Random direction
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        Vector3 position = transform.position;

        // Check bounds and reverse direction if necessary
        if (position.x < -screenBounds.x || position.x > screenBounds.x)
        {
            direction.x = -direction.x;
            position.x = Mathf.Clamp(position.x, -screenBounds.x, screenBounds.x);
        }

        if (position.y < -screenBounds.y || position.y > screenBounds.y)
        {
            direction.y = -direction.y;
            position.y = Mathf.Clamp(position.y, -screenBounds.y, screenBounds.y);
        }

        transform.position = position;
    }
}
