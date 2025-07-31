using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts.Managers
{
    public static class FileEventManager
    {
        public static void HandleOpener(OpenType openType, FileDataSo fileData)
        {
            
            
        }
        
        public static void HandleTrigger(FileType fileType, FileDataSo fileData)
        {
            if (fileData.triggersPopup)
            {
                
                return;   
            }
            
            switch (fileType)
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
            Debug.Log($"저장 공간 확보 : {fileData.fileSize}");
        }

        private static void RandomGoodEffect(FileDataSo fileData)
        {
            int randomNumber = Random.Range(0, 2);

            Debug.Log(randomNumber == 1 ? $"제한 시간 증가 : {fileData.changeTime}" : $"저장 공간 확보 : {fileData.fileSize}");
        }

        private static void RandomBadEffect(FileDataSo fileData)
        {
            int randomNumber = Random.Range(0, 2);

            Debug.Log(randomNumber == 1 ? $"제한 시간 감소 : {fileData.changeTime}" : $"저장 공간 감소 : {fileData.fileSize}");
        }
    }
}