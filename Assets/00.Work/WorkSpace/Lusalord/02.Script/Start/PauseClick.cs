using _00.Work.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _00.Work.WorkSpace.Lusalord._02.Script.StartScene
{
    public class PauseClick : MonoBehaviour
    {
        [SerializeField] private string panelName;
        public void ExitClicked()
        {
            Application.Quit();
        }

        public void RestartClicked()
        {
            FadeManager.Instance.FadeToScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
