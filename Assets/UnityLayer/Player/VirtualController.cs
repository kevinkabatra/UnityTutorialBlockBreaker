using UnityEngine;
using UnityEngine.Events;

/// <summary>
///     Virtual Controller to handle the input from Unity.
/// </summary>
public class VirtualController : Common<VirtualController>
{
    private readonly UnityEvent fireEvent = new UnityEvent();

    /// <summary>
    ///     Update is called once per frame.
    /// </summary>
    private void Update()
    {
        HandleFireEvent();
    }

    /// <summary>
    ///     Invokes the event.
    /// </summary>
    public void FireEvent()
    {
        fireEvent.Invoke();
    }

    /// <summary>
    ///     Informs the event to trigger the callback when event is invoked.
    /// </summary>
    /// <param name="callback"></param>
    public void FireEventSubscribe(UnityAction callback)
    {
        fireEvent.AddListener(callback);
    }

    /// <summary>
    ///     Stops the event from triggering the callback.
    /// </summary>
    /// <param name="callback"></param>
    public void FireEventUnsubscribe(UnityAction callback)
    {
        fireEvent.RemoveListener(callback);
    }

    /// <summary>
    ///     Logic for handling the Fire Event.
    /// </summary>
    private void HandleFireEvent()
    {
        var leftMouseButton = 0;
        if (Input.GetMouseButtonDown(leftMouseButton))
        {
            FireEvent();
        }
    }
}
