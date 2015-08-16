using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour
{
    public GameObject Levels;
    public GameObject Menu;
    public GameObject BackBtn;

	// Use this for initialization
    private void Awake()
    {
        Levels.transform.localScale = Vector3.one;
        Levels.transform.localPosition = new Vector3(105, 8.5f, 0);
        Menu.SetActive(true);
        BackBtn.SetActive(false);
    }

    public void ShowLevels()
    {
        Levels.transform.localScale = Vector3.one*0.27f;
        Levels.transform.localPosition = new Vector3(0, 8.5f, 0);
        print("Local scale of Levels set to " + Levels.transform.localScale + "with new position " + Levels.transform.localPosition);
        Menu.SetActive(false);
        BackBtn.SetActive(true);
    }

    public void HideLevels()
    {
        Levels.transform.localScale = Vector3.one;
        Levels.transform.localPosition = new Vector3(105, 8.5f, 0);
        print("Local scale of Levels set to " + Levels.transform.localScale + "with new position " + Levels.transform.localPosition);
        Menu.SetActive(true);
        BackBtn.SetActive(false);
    }
}