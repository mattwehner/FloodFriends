using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorldController : MonoBehaviour
    {
        public int Par;
        public GameObject ShowScores;

        void Awake()
        {
            WorldStorage.LevelWon = false;
            WorldStorage.LevelLost = false;
            WorldStorage.Par = Par;
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
            if (WorldStorage.MovingTiles.Contains("COMPLETE"))
            {
                return;
            }
            WorldStorage.MovingTiles.Add("COMPLETE");
            ShowScores.GetComponent<ShowScore>().CalculateScore(false);
        }

        private void LevelCompleted()
        {
            if (WorldStorage.MovingTiles.Contains("COMPLETE"))
            {
                return;
            }
            WorldStorage.MovingTiles.Add("COMPLETE");
            ShowScores.GetComponent<ShowScore>().CalculateScore(true);
        }

        internal static void RestartLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
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
