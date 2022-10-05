using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem

{
    [System.Serializable]
    public class SaveStarMap
    {
        public StarData starData = new StarData();
    }

    [System.Serializable]
    public class SavePlayerStats
    {
        public PlayerData PlayerData = new PlayerData();
    }

    [System.Serializable]
    public class SavePlanetStats
    {
        public PlanetData PlanetData = new PlanetData();
    }
}
