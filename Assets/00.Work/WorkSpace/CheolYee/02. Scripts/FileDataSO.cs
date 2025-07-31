using System.Collections.Generic;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    [CreateAssetMenu(fileName = "FileData", menuName = "SO/FileData", order = 1)]
    public class FileDataSo : ScriptableObject
    {
        [Header("FileData")]
        public string fileName;
        public Sprite icon;
        public FileType type;

        [Header("File Attributes")]
        public float fileSize;
        public int changeTime;
        
        [Header("Open File")]
        public bool openFile;
        public OpenType openType;
        
        [Header("Delete Trigger")]
        public bool triggersPopup;
        public string triggerName;
        [TextArea]
        public string triggerDescription;
        
        [Header("Only for Folder")]
        public List<FileDataSo> children;
    }
}