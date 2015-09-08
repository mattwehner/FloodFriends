using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ShowScore: MonoBehaviour
    {
        public GameObject LoseScreen;
        public GameObject WinScreen;

        private static int Par;
        private static int Moves;
        
        private Text WinScoreText;
        private Text LoseScoreText;

        public GameObject Medal1;
        public GameObject Medal2;
        public GameObject Medal3;

        private Color32 _gold = new Color32(255, 216, 0, 255);
        private Color32 _empty = new Color32(137, 163, 81, 255);

        void Start()
        {
            WinScoreText= WinScreen.transform.GetChild(0).gameObject.GetComponent<Text>();
            print("WinScoreText set to " + WinScoreText.name);

            LoseScoreText = LoseScreen.transform.GetChild(0).gameObject.GetComponent<Text>();
            print("LoseScoreText set to " + LoseScoreText.name);

            Par = WorldStorage.Par;

            print("par is " + Par);
            Moves = 0;
            print("Movesreset to " + Moves);

            LoseScreen.SetActive(false);
            WinScreen.SetActive(false);
        }

        public void CalculateScore(bool win)
        {
            LoseScreen.SetActive(!win);
            WinScreen.SetActive(win);

            Moves = WorldStorage.MoveCount;
            if (win)
            {
                WinScoreText.text = Moves.ToString();
            }
            else
            {
                LoseScoreText.text = Moves.ToString();
            }
            CalculateMedal();
        }

        private void CalculateMedal()
        {

            double percent = ((double)Par / Moves)*10;
            
            print("user scored " + percent);

            if (percent == 10)
            {
                Medal1.GetComponent<Image>().color = _gold;
                Medal2.GetComponent<Image>().color = _gold;
                Medal3.GetComponent<Image>().color = _gold;
            }
            else if (percent >= 8 && percent < 10)
            {
                Medal1.GetComponent<Image>().color = _gold;
                Medal2.GetComponent<Image>().color = _gold;
                Medal3.GetComponent<Image>().color = _empty;
            }
            else if (percent >= 4 && percent < 8)
            {
                Medal1.GetComponent<Image>().color = _gold;
                Medal2.GetComponent<Image>().color = _empty;
                Medal3.GetComponent<Image>().color = _empty;
            }
            else
            {
                Medal1.GetComponent<Image>().color = _empty;
                Medal2.GetComponent<Image>().color = _empty;
                Medal3.GetComponent<Image>().color = _empty;
            }
        }
    }
}
