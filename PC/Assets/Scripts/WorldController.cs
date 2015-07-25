using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldController : MonoBehaviour
    {
        internal static readonly int GridSize = 5;

        public static char NextDirection;
        public static char Direction;

        internal static List<GameObject> Tiles;
        internal static List<string> MovingTiles;

        public static GameObject Raft_SM;
        public static GameObject Raft_MD;
        public static GameObject Raft_LG;
        public static GameObject Raft_XL;

        // Use this for initialization
        void Awake ()
        {
            Tiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tile"));
            MovingTiles = new List<string>();

            Raft_SM = (GameObject)Resources.Load("Prefabs/Raft_SM");
            Raft_MD = (GameObject)Resources.Load("Prefabs/Raft_MD");
            Raft_LG = (GameObject)Resources.Load("Prefabs/Raft_LG");
            Raft_XL = (GameObject)Resources.Load("Prefabs/Raft_XL");
        }

        void Update()
        {
            
        }

        internal static void MoveInDirection(char direction)
        {
            if (MovingTiles.Count != 0) return;

            foreach (var objectController in Tiles.Select(tile => (ObjectController) tile.GetComponent(typeof (ObjectController))))
            {
                objectController.Move(direction);
            }
        }
    }
}
