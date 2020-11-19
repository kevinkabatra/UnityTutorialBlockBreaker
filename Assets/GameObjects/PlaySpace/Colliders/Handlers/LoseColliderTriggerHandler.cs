using UnityEngine;

public class LoseColliderTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneLoader.LoadGameOverScene();
    }
}
