using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Common logic for causing collisions between two objects.
/// </summary>
public class ObjectCollider
{
    /// <summary>
    ///     Collides two objects together.
    /// </summary>
    /// <param name="firstObject"></param>
    /// <param name="secondObject"></param>
    /// <returns></returns>
    public static IEnumerator CauseCollision(MonoBehaviour firstObject, MonoBehaviour secondObject)
    {
        var objects = new List<MonoBehaviour>
        {
            firstObject,
            secondObject
        };

        CauseCollision(objects);
        yield return new WaitForSeconds(0.1f);
    }

    /// <summary>
    ///     Moves all Game Objects to Vector3.zero position to force a collision.
    /// </summary>
    /// <param name="gameObjects"></param>
    public static void CauseCollision(List<MonoBehaviour> objects)
    {
        foreach(var gameObject in objects)
        {
            gameObject.transform.position = Vector3.zero;
        }
    }
}
