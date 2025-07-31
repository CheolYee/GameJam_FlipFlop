using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    public class CloseBtn : MonoBehaviour
    {
        public GameObject panelToClose;

        public void OnClickClose()
        {
            Destroy(panelToClose);
        }
    }
}