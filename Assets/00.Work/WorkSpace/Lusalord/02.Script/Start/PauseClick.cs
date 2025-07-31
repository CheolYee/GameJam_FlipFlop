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
            SceneManager.LoadScene(panelName);
        }
    }
}
