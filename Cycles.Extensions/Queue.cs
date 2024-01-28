﻿namespace Cycles.Extensions;

#region Queue
public static class Queue
{
    /// <summary>
    /// Dequeue zeros from the beginning of the queue.
    /// </summary>
    /// <param name="bytes"></param>
    public static void DequeueZeros(this Queue<byte> bytes)
    {
        while (bytes.Peek() == 0)
        {
            bytes.Dequeue();
        }
    }
}
#endregion