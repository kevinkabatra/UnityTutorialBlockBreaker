using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    /// <summary>
    ///     Loads the next scene.
    /// </summary>
	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
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
}
