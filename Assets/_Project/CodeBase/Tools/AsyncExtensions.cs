using System.Threading.Tasks;
using UnityEngine;

namespace Tools
{
    public static class AsyncExtensions
    {
        public static Task GetTask(this AsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<AsyncOperation>();
            asyncOp.completed += operation => tcs.SetResult(operation);
            return tcs.Task;
        }
    }
}