using UnityEngine;

public class FloatingAssets : MonoBehaviour
{
    public GameObject[] assets;
    public int numberOfAssets = 20;
    public float minSpeed = 0.5f;
    public float maxSpeed = 2.0f;

    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        for (int i = 0; i < numberOfAssets; i++)
        {
            SpawnAsset();
        }
    }

    void SpawnAsset()
    {
        GameObject asset = Instantiate(assets[Random.Range(0, assets.Length)]);
        asset.transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y), 0);

        // Add a RandomMovement component to handle the movement
        asset.AddComponent<RandomMovement>().Initialize(minSpeed, maxSpeed, screenBounds);
    }
}
