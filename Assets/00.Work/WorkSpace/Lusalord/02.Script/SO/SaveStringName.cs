using UnityEngine;

namespace _00.Work.WorkSpace.Lusalord._02.Script.StartScene.SO
{
    [CreateAssetMenu(fileName = "SaveStringName", menuName = "SO/SaveStringName")]
    public class SaveStringName : ScriptableObject
    {
        public string playerName; // InputField로 받아 올 플레이어의 이름
    }
}
