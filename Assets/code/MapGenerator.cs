using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject haxObjectPrefab;
    private const float PositionShiftX = 1.5f;
    private const float PositionShiftZ = 0.8660254f; // sqrt(3) / 2

    public Map GenerateMap(int rOrigin, int qOrigin, int width, int height)
    {
        GameObject[,] array = new GameObject[width, height];

        for (int r = 0; r < width; ++r)
        {
            for (int q = 0; q < height; ++q)
            {
                var R = (r + rOrigin);
                var Q = (q + qOrigin);
                var position = new Vector3(R * PositionShiftX, 0, R * PositionShiftZ + Q * PositionShiftZ * 2);
                GameObject newHex = Instantiate(haxObjectPrefab, position, Quaternion.identity);
                // newHex.SetActive(false);
                array[r, q] = newHex;
            }
        }

        return new Map(ref array, rOrigin, qOrigin);
    }

    private void Start()
    {
        GenerateMap(-10, -10, 20, 20);
    }
}