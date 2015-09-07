using UnityEngine;

namespace Assets.Scripts
{
    public class LevelList
    {

        // Static singleton instance
        private static LevelList _instance;

        // Static singleton property
        public static LevelList Instance
        {
            get { return _instance ?? (_instance = new LevelList()); }
        }

        public string[][] Levels = new string[][]
        {
            
        };
    }
}
