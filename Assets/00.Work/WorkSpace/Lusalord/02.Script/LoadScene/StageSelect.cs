using _00.Work.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void StageLoad(int num)
    {
        FadeManager.Instance.FadeToScene(num);
    }
}
