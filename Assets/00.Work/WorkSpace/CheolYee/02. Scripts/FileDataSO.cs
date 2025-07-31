using System.Collections.Generic;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    [CreateAssetMenu(fileName = "FileData", menuName = "SO/FileData", order = 1)]
    public class FileDataSo : ScriptableObject
    {
        public string fileName;
        public Sprite icon;
        public FileType type;
        public TriggerType triggerType;
        public bool triggersPopup;

        [Header("File Attributes")]
        public float fileSize;
        
        [Header("Only for Folder")]
        public List<FileDataSo> children;
    }
}