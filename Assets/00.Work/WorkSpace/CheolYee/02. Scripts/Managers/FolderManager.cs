using _00.Work.Scripts.Managers;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public class FolderManager : MonoSingleton<FolderManager>
    {
        [SerializeField] private Transform folderPanelTrm;
        [SerializeField] private GameObject folderPanel;
        [SerializeField] private GameObject fileItemPrefab;

        public GameObject CreatePanel(FileDataSo fileData)
        {
            GameObject panel = Instantiate(folderPanel, folderPanelTrm);

            Transform createdPanelTransform = panel.transform.GetChild(1);

            foreach (var file in fileData.children)
            {
                FileItem newFile = Instantiate(fileItemPrefab, createdPanelTransform).GetComponentInChildren<FileItem>();
                newFile.Initialize(file);
            }

            return panel;
        }
    }
}