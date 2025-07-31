using _00.Work.WorkSpace.CheolYee._02._Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wastebasket : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropFile = eventData.pointerDrag;

        if (dropFile != null)
        {
            Destroy(dropFile);
        }
    }
}
