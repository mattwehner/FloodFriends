using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PCControllerService : MonoBehaviour {
	
        void Update () {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                WorldController.MoveInDirection('N');
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                WorldController.MoveInDirection('S');
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                WorldController.MoveInDirection('E');
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                WorldController.MoveInDirection('W');
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                WorldController.RestartLevel();
            }
        }
    }
}
