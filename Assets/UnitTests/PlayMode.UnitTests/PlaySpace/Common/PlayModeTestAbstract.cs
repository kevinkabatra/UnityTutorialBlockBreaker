using NUnit.Framework;
using UnityEngine;

/// <summary>
///     Abstract for Play Mode tests.
/// </summary>
public class PlayModeTestAbstract
{
    private GameObject cameraPrefab;
    private GameObject playSpacePrefab;
    private GameObject playerPrefab;

    private GameObject cameraInstance;
    private GameObject playSpaceInstance;
    private GameObject playerInstance;
    
    [SetUp]
    public virtual void Setup()
    {
        cameraPrefab = GetCameraPrefab();
        cameraInstance = MonoBehaviour.Instantiate(cameraPrefab);

        playSpacePrefab = GetPlaySpacePrefab();
        playSpaceInstance = MonoBehaviour.Instantiate(playSpacePrefab);

        playerPrefab = GetPlayerPrefab();
        playerInstance = MonoBehaviour.Instantiate(playerPrefab);
    }

    /// <summary>
    ///     Cleans up our mess.
    /// </summary>
    /// <remarks>
    ///     Do not destroy the player instance as it is a Singleton. Due to the delay in which
    ///     it takes Unity to process the destruction other unit tests will already have begun.
    ///     I have seen instances where the second unit tests has already completed its call to
    ///     setup and after that is when the Destroy command is executed.
    ///     
    ///     This is caused by Unity processing destruction during the next frame update rather than
    ///     immediately.
    /// </remarks>
    [TearDown]
    public virtual void TearDown()
    {
        Object.Destroy(cameraInstance);
        Object.Destroy(playSpaceInstance);
    }

    private GameObject GetCameraPrefab()
    {
        return Resources.Load<GameObject>("Camera/Prefabs/Camera");
    }

    private GameObject GetPlaySpacePrefab()
    {
        return Resources.Load<GameObject>("PlaySpace/Prefabs/PlaySpace");
    }

    private GameObject GetPlayerPrefab()
    {
        return Resources.Load<GameObject>("Player/Prefabs/Player");
    }
}
