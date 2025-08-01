using System.Collections.Generic;
using _00.Work.Scripts.Managers;
using _00.Work.WorkSpace.ForRest._02._Scripts;
using TMPro;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public class MissionManager : MonoSingleton<MissionManager>
    {
        [SerializeField] private TextMeshProUGUI succesCount;
        
        public List<FileDataSo> targetFiles;
        public List<FileDataSo> forbiddenFiles;

        private int _allTargetCount;

        protected override void Awake()
        {
            base.Awake();
            _allTargetCount = targetFiles.Count;
            succesCount.text = $"꼭 지워야 하는 파일 ({_allTargetCount} / {targetFiles.Count}):";
        }

        public void OnFileDeleted(FileDataSo fileData)
        {
            if (targetFiles.Contains(fileData))
            {
                targetFiles.Remove(fileData);
                succesCount.text = $"꼭 지워야 하는 파일 ({_allTargetCount} / {targetFiles.Count}):";
            }

            if (forbiddenFiles.Contains(fileData))
            {
                TimerManager.Instance.SetTimer(0);
            }
        }
    }
}