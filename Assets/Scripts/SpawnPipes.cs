using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable() {
        InvokeRepeating(nameof(SpawnPipe), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(SpawnPipe));
    }

    private void SpawnPipe() {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
