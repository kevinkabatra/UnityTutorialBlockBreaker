/// <summary>
///     Quit button.
/// </summary>
public class QuitButton : Button
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        button.onClick.AddListener(() => { sceneLoader.QuitGame(); });
    }
}