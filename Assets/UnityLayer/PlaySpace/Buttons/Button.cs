using UnityEngine;

/// <summary>
///     Common data model for a Button.
/// </summary>
public class Button : MonoBehaviour
{
    protected SceneLoader sceneLoader;
    protected UnityEngine.UI.Button button;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        sceneLoader = SceneLoader.Get();
        button = GetComponent<UnityEngine.UI.Button>();
    }
}
