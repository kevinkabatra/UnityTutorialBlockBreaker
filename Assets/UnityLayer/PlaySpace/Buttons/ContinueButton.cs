/// <summary>
///     Continue button.
/// </summary>
public class ContinueButton : Button
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
        var player = Player.Get();

        button.onClick.AddListener(() => 
        { 
            sceneLoader.LoadStartScene();
            player.IncreasePlayerHealth();
            player.ResetScore();
        });
    }
}
