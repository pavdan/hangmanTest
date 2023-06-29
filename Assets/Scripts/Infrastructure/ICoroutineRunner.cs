using System.Collections;
using UnityEngine;

namespace Hangman.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}