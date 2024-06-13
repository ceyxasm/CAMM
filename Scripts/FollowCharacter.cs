using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform target; // The main character's transform
    public float followDistance = 2f; // Distance to maintain from the main character
    public float followSpeed = 5f; // Speed at which the side character follows

    void Update()
    {
        // Calculate the distance between the side character and the target
        float distance = Vector3.Distance(transform.position, target.position);

        // If the distance is greater than the follow distance, move towards the target
        if (distance > followDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }
}
