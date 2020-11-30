using System.Linq;
using UnityEngine;

public class BlockCounter
{
    /// <summary>
    ///     Gets the number of blocks that are remaining.
    /// </summary>
    /// <returns></returns>
    public static int GetBlockCount()
    {
        var blocks = GameObject.FindObjectsOfType<Block>();
        return blocks.Where(block => !block.isDestroyed).Count();
    }
}
