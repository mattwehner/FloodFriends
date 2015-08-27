using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class WorldStorage : MonoBehaviour {

        internal static readonly int GridSize = 5;
        internal static int MoveCount = 0;

        public static char NextDirection;
        public static char Direction;

        internal static List<GameObject> Tiles;
        internal static List<string> MovingTiles;

        public static GameObject Raft_SM;
        public static GameObject Raft_MD;
        public static GameObject Raft_LG;
        public static GameObject Raft_XL;

        public GameObject WinText;
        public GameObject LoseText;
        public Text MoveCounter;
        public static bool LevelWon;
        public static bool LevelLost;

        void Awake()
        {
            Tiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tile"));
            MovingTiles = new List<string>();

            Raft_SM = (GameObject)Resources.Load("Prefabs/1Combined");
            Raft_MD = (GameObject)Resources.Load("Prefabs/2Combined");
            Raft_LG = (GameObject)Resources.Load("Prefabs/3Combined");

            MoveCount = 0;
            LevelWon = false;
            LevelLost = false;

            WinText.SetActive(LevelWon);
            LoseText.SetActive(LevelLost);
            MoveCounter.text = MoveCount.ToString();
        }

        void Update()
        {
            MoveCounter.text = MoveCount.ToString();
            WinText.SetActive(LevelWon);
            LoseText.SetActive(LevelLost);
        }
    }
}
