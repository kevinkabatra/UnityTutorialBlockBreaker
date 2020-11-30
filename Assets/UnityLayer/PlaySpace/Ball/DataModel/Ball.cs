/// <summary>
///     The Ball.
/// </summary>
public class Ball : Common<Ball>
{
    public readonly float launchSpeed = 10f;
    public readonly float maxUpwardSpeed = 16f;
    public readonly float maxDownwardSpeed = 10f;
    public readonly float maxLeftRightSpeed = 10f;

    public bool hasLaunched = false;
}
