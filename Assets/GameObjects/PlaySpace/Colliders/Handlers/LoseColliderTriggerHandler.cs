using UnityEngine;

public class LoseColliderTriggerHandler : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        SceneLoader.LoadGameOverScene();
    }
}
