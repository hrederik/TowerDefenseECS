using UnityEngine;

namespace Helpers
{
    public static class CameraUtils
    {
        private static Camera mainCamera;
        
        public static Camera MainCamera => mainCamera ??= Camera.main;
    }
}