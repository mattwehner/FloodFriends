using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{

    public void GoToScene(int index)
    {
        Application.LoadLevel(index);
    }

    public void GoToScene(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}