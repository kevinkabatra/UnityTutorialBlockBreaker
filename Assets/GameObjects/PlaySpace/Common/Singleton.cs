using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    /// <summary>
    ///     There can be only one - Highlander.
    /// </summary>
    protected void Awake()
    {
        var existingInstance = FindObjectsOfType<T>();
        if (existingInstance.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
