/// <summary>
///     Start button.
/// </summary>
public class StartButton : Button
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        button.onClick.AddListener(() => { sceneLoader.LoadNextScene(); });
    }
}
