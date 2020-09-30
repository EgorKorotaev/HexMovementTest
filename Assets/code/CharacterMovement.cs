using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    private const float PositionShiftX = 1.5f;
    private const float PositionShiftZ = 0.8660254f; // sqrt(3) / 2

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveOnKeyboardInput();
    }

    private void MoveOnKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MoveToAdjacentHex(-1, 1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveToAdjacentHex(0, 2);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToAdjacentHex(-1, -1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToAdjacentHex(0, -2);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToAdjacentHex(1, -1);
            EventManager.TriggerEvent(Events.OnGenerateMapEvent);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveToAdjacentHex(1, 1);
        }
    }

    private void MoveToAdjacentHex(int hexesX, int hexesZ)
    {
        var newX = PositionShiftX * hexesX; 
        var newZ = PositionShiftZ * hexesZ;
        this.transform.Translate(new Vector3(newX, 0, newZ));
    }
}
