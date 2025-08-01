using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void StageLoad(GameObject button)
    {
        SceneManager.LoadScene(button.name);
    }
}
