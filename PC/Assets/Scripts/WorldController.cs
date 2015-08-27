using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldController : MonoBehaviour
    {
        void Awake()
        {
            WorldStorage.LevelWon = false;
            WorldStorage.LevelLost = false;
        }
        void Update()
        {
            if (WorldStorage.Tiles.Count == 1)
            {
                LevelCompleted();
            }
            if (WorldStorage.LevelLost)
            {
                LevelLost();
            }
        }

        private void LevelLost()
        {
            WorldStorage.MovingTiles.Add("COMPLETE");
            WorldStorage.LevelWon = false;
            WorldStorage.LevelLost = true;
        }

        private void LevelCompleted()
        {
            WorldStorage.MovingTiles.Add("COMPLETE");
            WorldStorage.LevelLost = false;
            WorldStorage.LevelWon = true;
        }

        internal static void RestartLevel()
        {
            //must change to current level
            Application.LoadLevel(1);
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
