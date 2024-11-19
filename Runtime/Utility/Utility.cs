using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
namespace DemGFramework.Utility
{
    public static class Utility
    {
        public delegate void CustomAction<T>(T value);
        public delegate void Vector3Action(Vector3 value);
        public delegate void BoolAction(bool value);
        public delegate void VoidAction();
        public delegate void FloatAction(float value);

        public static float NormalizeAngle(float angle)
        {
            while (angle > 360f) angle -= 360f;
            while (angle < 0f) angle += 360f;
            return angle;
        }
        public static Color GetGrayscaleFromValue(float value, float maxValue = Mathf.Infinity) {
            value = Mathf.Clamp(value, 0f, maxValue);
            float v = value / 100f;
            return Color.Lerp(Color.black, Color.white, v);
        }

#if UNITY_EDITOR

        static MethodInfo _clearConsoleMethod;
        static MethodInfo clearConsoleMethod {
            get {
                if (_clearConsoleMethod == null) {
                    Assembly assembly = Assembly.GetAssembly (typeof(SceneView));
                    Type logEntries = assembly.GetType ("UnityEditor.LogEntries");
                    _clearConsoleMethod = logEntries.GetMethod ("Clear");
                }
                return _clearConsoleMethod;
            }
        }

        public static void ClearLogConsole() {
            clearConsoleMethod.Invoke (new object (), null);
        }
#endif

    }
}