using System.Linq;
using UnityEngine;

public class BlockCounter
{
    public static int GetBlockCount()
    {
        var blocks = GameObject.FindObjectsOfType<Block>();
        return blocks.Where(block => !block.isDestroyed).Count();
    }
}
