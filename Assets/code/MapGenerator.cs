using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public void GenerateMap()
    {
        Debug.Log("Создали карту");
    }
    
    private void Start()
    {
        EventManager.StartListening(Events.OnGenerateMapEvent, GenerateMap);
    }
}