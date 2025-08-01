namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    public enum FileType
    {
        Normal,     // 일반 파일
        Junk,       // 삭제하면 용량이 오히려 느는 파일
        Important,  // 삭제하면 손해
        Virus,      // 클릭 시 방해
        Folder      // 폴더
    }

    public enum TriggerType
    {
        None,
        AdPopup,
        ShutDown
    }
}
