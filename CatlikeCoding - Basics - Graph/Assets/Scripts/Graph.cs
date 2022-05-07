using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;

    [SerializeField, Range(10, 100)] private int resolution = 10;

    [SerializeField, Range(0, 1)] private int function;

    private Transform[] points;

    private void Awake()
    {
        //This step is used because we are in a range of -1 to 1.
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = ((i + 0.5f) * step - 1f);
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    private void Update()
    {
        float time = Time.time;
        foreach (Transform point in points)
        {
            Vector3 position = point.localPosition;
            position.y = FunctionLibrary.Wave(position.x, time);
            point.localPosition = position;
        }
    }
}