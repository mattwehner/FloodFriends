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
            var loadedLevel = Application.loadedLevel;
            Application.LoadLevel(loadedLevel);
        }
    }
}
