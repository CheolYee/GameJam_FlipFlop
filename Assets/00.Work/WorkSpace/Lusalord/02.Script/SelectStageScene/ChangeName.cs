using _00.Work.WorkSpace.Lusalord._02.Script.StartScene.SO;
using TMPro;
using UnityEngine;

namespace _00.Work.WorkSpace.Lusalord._02.Script.SelectStageScene
{
    public class ChangeName : MonoBehaviour
    {
        [SerializeField] private SaveStringName saveStringName;
        [SerializeField] private TextMeshProUGUI nameText;

        private void Start()
        {
            nameText.text = saveStringName.playerName;
        }
    }
}
