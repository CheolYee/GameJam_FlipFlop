using _00.Work.WorkSpace.Lusalord._02.Script.SO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public SavedSceneName savedSceneName;
    public string sceneName;
    private void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame && !Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneName);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(savedSceneName.sceneName);
            savedSceneName.sceneName = "";
        }
    }
}
