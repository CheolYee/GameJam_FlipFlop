using System.Timers;
using UnityEngine;
using Timer = _00.Work.WorkSpace.ForRest._02._Scripts.Timer;

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
                        break;
                    case TriggerType.ShutDown:
                        break;
                }
            }
            
            switch (fileData.type)
            {
                case FileType.Normal:
                    RandomGoodEffect(fileData);
                    break;
                case FileType.Junk:
                    JunkEffect(fileData);
                    break;
                case FileType.Important:
                    RandomImportantEffect(fileData);
                    break;
                case FileType.Virus:
                    RandomBadEffect(fileData);
                    break;
                case FileType.Trap:
                    break;
            }
        }

        private static void RandomImportantEffect(FileDataSo fileData)
        {
            
        }

        private static void JunkEffect(FileDataSo fileData)
        {
            DiskSliderBar.Instance.MinusDisk(fileData.fileSize);
        }

        private static void RandomGoodEffect(FileDataSo fileData)
        {
            if (Random.Range(0, 2) == 0)
                DiskSliderBar.Instance.MinusDisk(fileData.fileSize);
            else
                Timer.Instance.AddTimer(fileData.changeTime);
        }

        private static void RandomBadEffect(FileDataSo fileData)
        {
            if (Random.Range(0, 2) == 0)
                DiskSliderBar.Instance.PlusDisk(fileData.fileSize);
            else
                Timer.Instance.LessTimer(fileData.changeTime);
        }
    }
}