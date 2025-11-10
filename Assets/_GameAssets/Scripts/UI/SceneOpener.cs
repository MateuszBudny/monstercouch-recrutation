using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    [SerializeField]
    [Scene]
    private string sceneToOpen;

    public void OpenGivenScene()
    {
        SceneManager.LoadScene(sceneToOpen);
    }
}
