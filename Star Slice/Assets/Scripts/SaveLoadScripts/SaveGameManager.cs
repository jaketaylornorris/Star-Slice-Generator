using UnityEngine;
using System.IO;
using TMPro;

namespace SaveLoadSystem
{
    public static class SaveGameManager
    {
        public static SaveStarMap CurrentSaveMap = new SaveStarMap();
        public static SavePlayerStats CurrentSavePlayer = new SavePlayerStats();
        public static SavePlanetStats CurrentSavePlanet = new SavePlanetStats();
        
        public static string SaveDirectory = "/" + SaveData.mapName + "/";
        public static string LoadDirectory = "/" + MainMenu.Instance.folderName + "/";
        public static string LoadPlanetDirectory = MainMenu.Instance.systemName + "/";
        public static string FileNamePlayer = "PlayerData.json";
        public static string FileNameStar;
        public static string FileNamePlanet;

        public static bool SavePlayer()
        {
            SaveDirectory = "/" + SaveData.mapName + "/";
            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string json = JsonUtility.ToJson(CurrentSavePlayer, prettyPrint: true);
            File.WriteAllText(path: dir + FileNamePlayer, contents:json);

            GUIUtility.systemCopyBuffer = dir + FileNamePlayer;

            return true;
        }

        public static bool SaveStars()
        {
            FileNameStar = SaveData.starNameReplace + ".json";
            var dir = Application.persistentDataPath + SaveDirectory;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string json = JsonUtility.ToJson(CurrentSaveMap, prettyPrint: true);
            File.WriteAllText(path: dir + FileNameStar, contents: json);

            GUIUtility.systemCopyBuffer = dir + FileNameStar;

            return true;
        }
        public static bool SavePlanets()
        {
            FileNamePlanet = SaveData.starNameReplace + ".json";
            var dir = Application.persistentDataPath + SaveDirectory + SaveData.starInSystemName + "/";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            Debug.Log(dir);
            string json = JsonUtility.ToJson(CurrentSavePlanet, prettyPrint: true);
            File.WriteAllText(path: dir + FileNamePlanet, contents: json);

            GUIUtility.systemCopyBuffer = dir + FileNamePlanet;

            return true;
        }
        public static void LoadPlayer ()
        {
            string fullPath = Application.persistentDataPath + LoadDirectory + FileNamePlayer;
            SavePlayerStats tempData = new SavePlayerStats ();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                tempData = JsonUtility.FromJson<SavePlayerStats>(json);
            }
            else
            {
                Debug.LogError("Save file does not exist.");
            }

            CurrentSavePlayer = tempData;
        }
    }
}