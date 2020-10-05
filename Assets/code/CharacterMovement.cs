using UnityEngine;

namespace code
{
    public class CharacterMovement : MonoBehaviour
    {
        public int startPositionR = 0;
        public int startPositionQ = 0;
        private int positionR;
        private int positionQ;
        private const float PositionShiftX = 1.5f;
        private const float PositionShiftZ = 0.8660254f; // sqrt(3) / 2

        // Start is called before the first frame update
        void Start()
        {
            SetSrartPositionRQ();
        }

        // Update is called once per frame
        void Update()
        {
            MoveOnKeyboardInput();
        }

        private void SetSrartPositionRQ()
        {
            this.transform.Translate(new Vector3(startPositionR * PositionShiftX, 0,
                startPositionR * PositionShiftZ + startPositionQ * PositionShiftZ * 2));
            positionR = startPositionR;
            positionQ = startPositionQ;
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
            positionR += hexesX;
            positionQ += hexesZ;
            this.transform.Translate(new Vector3(positionR * PositionShiftX, 0,
                positionR * PositionShiftZ + positionQ * PositionShiftZ * 2));
        }
    }
}