using System.Collections;
using UnityEngine;

public class BubbleBubble : MonoBehaviour
{
    [SerializeField] int maxCount = 5;
    [SerializeField] float delay = 1f;
    [SerializeField] Transform minPos, maxPos;
    [SerializeField] GameObject bubblePrefab = null;
    private Transform bubble = null;

    private void Awake()
    {
        bubble = transform.Find("Bubble");
    }

    private void Start()
    {
        StartCoroutine(SpawnWaterDrop());
    }

    private IEnumerator SpawnWaterDrop()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            if(bubble.childCount < maxCount)
                Instantiate(bubblePrefab, GetRandomPos(), Quaternion.identity).transform.SetParent(bubble);
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
