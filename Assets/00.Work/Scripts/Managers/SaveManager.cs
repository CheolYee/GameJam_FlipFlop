using System.IO;
using UnityEngine;

namespace _00.Work.Scripts.Managers
{
    public static class SaveManager
    {
        private static string SavePath => Application.persistentDataPath + "/stageData.json";

        public static void SaveStageData(StageData data)
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(SavePath, json);
        }

        public static StageData LoadStageData()
        {
            if (!File.Exists(SavePath))
            {
                StageData init = new StageData();
                init.stageProgress.Add(3);
                return init;
            }

            string json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<StageData>(json);
        }
    }
}