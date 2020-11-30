/// <summary>
///     Singleton pattern in Unity.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : Common<T> where T : Singleton<T>
{
    /// <summary>
    ///     There can be only one - Highlander.
    /// </summary>
    protected void Awake()
    {
        var existingInstance = FindObjectsOfType<T>();
        if (existingInstance.Length > 1)
        {
            /*
             * Disable the Game Object prior to destroying.
             * This is to prevent an issue from appearing where other
             * classes can attempt to access the Game Object prior to it
             * being destroyed.
             * 
             * This is due to Destroy being called last in the Execution Order
             * for Unity.
             */
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
