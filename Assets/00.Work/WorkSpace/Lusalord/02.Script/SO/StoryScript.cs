using UnityEngine;

namespace _00.Work.WorkSpace.Lusalord._02.Script.SO
{
    [CreateAssetMenu(fileName = "StoryScript", menuName = "SO/StoryScript")]
    public class StoryScript : ScriptableObject
    { 
        [Multiline(5)]public string story;
    }
}
