using _00.Work.WorkSpace.CheolYee._02._Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wastebasket : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var fileItem = eventData.pointerDrag?.GetComponent<FileItem>();
        if (fileItem != null)
        {
            fileItem.DeleteSelf();
        }
    }
}
