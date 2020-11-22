using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader> 
{
    private UnityEvent startGameEvent = new UnityEvent();
    private UnityEvent nextSceneEvent = new UnityEvent();

    public void AddListenerForStartGameEvent(UnityAction callBackFunction)
    {
        startGameEvent.AddListener(callBackFunction);
    }

    public void AddListenerForNextSceneEvent(UnityAction callBackFunction)
    {
        nextSceneEvent.AddListener(callBackFunction);
    }

    /// <summary>
    ///     Loads the next scene.
    /// </summary>
	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        
        nextSceneEvent.Invoke();
    }
    
    /// <summary>
    ///     Loads the Game Over scene
    /// </summary>
    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }

    /// <summary>
    ///     Loads the first scene.
    /// </summary>
    /// <remarks>
    ///     This is used by the PlayAgain button from the Game Over scene, so ignore the lack of references.
    /// </remarks>
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        
        startGameEvent.Invoke();
    }

    /// <summary>
    ///     Quits the game.
    /// </summary>
    /// <remarks>
    ///     This is used by the QuiteGame button from the Start scene, so ignore the lack of references.
    /// </remarks>
    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        //startGameEvent = new UnityEvent();
        //nextSceneEvent = new UnityEvent();
    }
}
