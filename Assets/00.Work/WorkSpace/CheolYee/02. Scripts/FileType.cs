namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    public enum FileType
    {
        Normal,     // 일반 파일
        Junk,       // 삭제 대상
        Important,  // 삭제하면 손해
        Virus,      // 클릭 시 방해
        Trap,       // 클릭 시 가짜 팝업 등 기믹 실행
        Folder      // 폴더
    }

    public enum TriggerType
    {
        None,
        AdPopup,
        ShutDown
    }
}
