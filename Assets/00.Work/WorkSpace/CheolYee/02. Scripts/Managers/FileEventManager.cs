
using System;
using _00.Work.WorkSpace.ForRest._02._Scripts;
using Random = UnityEngine.Random;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public static class FileEventManager
    {
        public static void HandleTrigger(FileDataSo fileData)
        {
            if (fileData.triggersPopup)
            {
                switch (fileData.triggerType)
                {
                    case TriggerType.None:
                        break;
                    case TriggerType.AdPopup:
                        PopUpManager.Instance.OpenAdPopup(fileData);
                        break;
                    case TriggerType.ShutDown:
                        ImportantEffect(fileData);
                        break;
                }
            }
            
            switch (fileData.type)
            {
                case FileType.Normal:
                    GoodEffect(fileData);
                    break;
                case FileType.Junk:
                    JunkEffect(fileData);
                    break;
                case FileType.Important:
                    ImportantEffect(fileData);
                    break;
                case FileType.Virus:
                    VirusEffect(fileData);
                    break;
            }
        }

        private static void ImportantEffect(FileDataSo fileData)
        {
            ShutDownManager.Instance.TriggerShutdown(fileData.shutDownCount);
        }

        private static void JunkEffect(FileDataSo fileData)
        {
            DiskSliderBar.Instance.MinusDisk(fileData.fileSize);
        }

        private static void GoodEffect(FileDataSo fileData)
        {
            DiskSliderBar.Instance.MinusDisk(fileData.fileSize);
        }

        private static void VirusEffect(FileDataSo fileData)
        {
            if (Random.Range(0, 2) == 0)
            {
                ShutDownManager.Instance.TriggerShutdown(fileData.shutDownCount);
            }
            else
            {
                PopUpManager.Instance.OpenAdPopup(fileData);
            }
        }
    }
}