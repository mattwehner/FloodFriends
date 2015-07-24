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

        public static bool CanMove { get; set; }

        // Use this for initialization
        void Awake ()
        {
            Tiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tile"));
            MovingTiles = new List<string>();
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
