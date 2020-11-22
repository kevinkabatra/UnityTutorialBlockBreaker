using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var sceneLoader = SceneLoader.GetSceneLoader();

        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => { sceneLoader.QuitGame(); });
    }
}
