using System.Collections.Generic;
using _00.Work.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public class FolderManager : MonoSingleton<FolderManager>
    {
        [SerializeField] private Transform folderPanelTrm;
        [SerializeField] private GameObject folderPanel;
        [SerializeField] private GameObject fileItemPrefab;

        private Dictionary<string, GameObject> _openedPanels = new();
        
        public void CreatePanel(FileDataSo fileData)
        {
            // 이미 만들어진 패널이 있으면 다시 보여주기
            if (_openedPanels.TryGetValue(fileData.fileName, out GameObject existingPanel))
            {
                if (existingPanel.activeSelf) return;
                
                existingPanel.transform.position = folderPanelTrm.position;
                existingPanel.SetActive(true);
                return;
            }

            // 없으면 새로 생성
            GameObject panel = Instantiate(folderPanel, folderPanelTrm);
            panel.GetComponent<FolderFiles>().Initialize(fileData);
            _openedPanels[fileData.fileName] = panel;

            Transform createdPanelTransform = panel.transform.GetChild(1);

            foreach (var file in fileData.children)
            {
                FileItem newFile = Instantiate(fileItemPrefab, createdPanelTransform).GetComponentInChildren<FileItem>();
                newFile.Initialize(file);
            }

            panel.transform.SetAsLastSibling();
            panel.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate { ClosePanel(fileData.fileName); });
            
        }
        
        public void ClosePanel(string fileName)
        {
            if (_openedPanels.TryGetValue(fileName, out var panel))
            {
                panel.SetActive(false);
            }
        }
    }
}