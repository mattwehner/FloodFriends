using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldController : MonoBehaviour
    {
        void Update()
        {
            if (WorldStorage.Tiles.Count == 1)
            {
                LevelCompleted();
            }
        }

        private void LevelCompleted()
        {
            WorldStorage.MovingTiles.Add("COMPLETE");
            WorldStorage.LevelWon = true;
        }

        internal static void RestartLevel()
        {
            Application.LoadLevel(0);
        }

        internal static void MoveInDirection(char direction)
        {
            if (WorldStorage.MovingTiles.Count != 0) return;

            WorldStorage.MoveCount += 1;

            foreach (var objectController in WorldStorage.Tiles.Select(tile => (ObjectController)tile.GetComponent(typeof(ObjectController))))
            {
                objectController.Move(direction);
            }
        }
    }
}
