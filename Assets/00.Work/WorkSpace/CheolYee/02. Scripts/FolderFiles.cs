using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    public class FolderFiles : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;

        public void Initialize(FileDataSo fileData)
        {
            titleText.text = fileData.name;
        }
    }
}