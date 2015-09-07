using UnityEngine;

namespace Assets.Scripts
{
    public class MenuCommands : MonoBehaviour {

        public void GoToScene(int index)
        {
            Application.LoadLevel(index);
        }

        public void GoToScene(string levelName)
        {
            Application.LoadLevel(levelName);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void ResetLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        public void NextLevel()
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }

        public void PreviousLevel()
        {
            Application.LoadLevel(Application.loadedLevel - 1);
        }
    }
}
