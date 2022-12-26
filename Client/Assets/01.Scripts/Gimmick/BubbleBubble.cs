using System.Collections;
using UnityEngine;

public class BubbleBubble : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] Transform minPos, maxPos;
    [SerializeField] GameObject bubblePrefab = null;

    private void Start()
    {
        StartCoroutine(SpawnWaterDrop());
    }

    private IEnumerator SpawnWaterDrop()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(bubblePrefab, GetRandomPos(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPos()
    {
        float x = Random.Range(minPos.position.x, maxPos.position.x);
        float y = Random.Range(minPos.position.y, maxPos.position.y);
        float z = Random.Range(minPos.position.z, maxPos.position.z);

        return new (x, y, z);
    }
}
