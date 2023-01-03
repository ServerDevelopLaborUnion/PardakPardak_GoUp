using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSide : MonoBehaviour
{
    [SerializeField] List<Transform> sides = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    [SerializeField] float duration = 3f;
    private int currentSideOrder = 0;

    private void Awake()
    {
        foreach(Transform trm in sides)
            positions.Add(trm.position);
    }

    private void Start()
    {
        StartCoroutine(MoveCoroutine(positions[currentSideOrder], duration));
    }

    private IEnumerator MoveCoroutine(Vector3 targetPos, float duration)
    {
        float timer = 0f;
        Vector3 startPos = transform.position;
        Vector3 pos = startPos;

        while(timer <= duration)
        {
            timer += Time.deltaTime;
            pos = Vector3.Lerp(startPos, targetPos, timer / duration);
            transform.position = pos;

            yield return null;
        }

        currentSideOrder = (currentSideOrder + 1) % sides.Count;

        StartCoroutine(MoveCoroutine(positions[currentSideOrder], duration));
    }
}
