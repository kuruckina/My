using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public static class CoroutineExtensions
    {
        public static Coroutine StartFrameTimer(this MonoBehaviour mono, int frameCount, Action action) =>
            mono.StartCoroutine(FrameTimer(frameCount, action));

        private static IEnumerator FrameTimer(int frameCount, Action action)
        {
            for (int i = 0; i < frameCount; i++)
                yield return null;
            
            action?.Invoke();
        }
    }
}