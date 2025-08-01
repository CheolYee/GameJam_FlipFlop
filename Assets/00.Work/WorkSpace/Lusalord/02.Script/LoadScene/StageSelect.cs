using _00.Work.WorkSpace.Lusalord._02.Script.SO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public SavedSceneName savedSceneName;
    private string _currentSceneName;
    
    public void StageLoad(GameObject button)
    {
        _currentSceneName = button.name;
        savedSceneName.sceneName = _currentSceneName;
        SceneManager.LoadScene(savedSceneName.sceneName);
    }
}
