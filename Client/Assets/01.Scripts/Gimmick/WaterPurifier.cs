using System.Collections;
using UnityEngine;

public class WaterPurifier : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] GameObject waterDrop = null;
    [SerializeField] Transform spawnPosition = null;

    private void Start()
    {
        StartCoroutine(SpawnWaterDrop());
    }

    private IEnumerator SpawnWaterDrop()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(waterDrop, spawnPosition.position, Quaternion.identity);
        }
    }
}
