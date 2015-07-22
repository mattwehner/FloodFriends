using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PCControllerService : MonoBehaviour {
	
        void Update () {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                WorldController.Direction = 'N';
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                WorldController.Direction = 'S';
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                WorldController.Direction = 'E';
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                WorldController.Direction = 'W';
            }
        }
    }
}
