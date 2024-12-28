using System;
using System.Collections;
using System.Collections.Generic;
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
        public delegate void StringAction(string value);

        public static float NormalizeAngle(float angle)
        {
            while (angle > 360f) angle -= 360f;
            while (angle < 0f) angle += 360f;
            return angle;
        }
        public static Color GetGrayscaleFromValue(float value, float maxValue = Mathf.Infinity)
        {
            value = Mathf.Clamp(value, 0f, maxValue);
            float v = value / 100f;
            return Color.Lerp(Color.black, Color.white, v);
        }

#if UNITY_EDITOR
        static MethodInfo _clearConsoleMethod;
        static MethodInfo clearConsoleMethod
        {
            get
            {
                if (_clearConsoleMethod == null)
                {
                    Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
                    Type logEntries = assembly.GetType("UnityEditor.LogEntries");
                    _clearConsoleMethod = logEntries.GetMethod("Clear");
                }
                return _clearConsoleMethod;
            }
        }

        public static void ClearLogConsole()
        {
            clearConsoleMethod.Invoke(new object(), null);
        }
#endif

        private static readonly HashSet<Type> exceptionTypes = new HashSet<Type>
    {
        typeof(LayerMask),
        typeof(AnimationCurve),
        typeof(AnimationClip),
        typeof(AudioClip),
        typeof(AudioClip[])
        typeof(Color)
    };

        public static Dictionary<string, object> ToDictionary(object obj, HashSet<object> processedObjects = null)
        {
            if (obj == null) return null;
            if (processedObjects == null)
                processedObjects = new HashSet<object>();

            if (processedObjects.Contains(obj))
                return null; // O gestisci come preferisci i riferimenti ciclici

            processedObjects.Add(obj);

            if (obj is Dictionary<string, object>) return obj as Dictionary<string, object>;

            var dict = new Dictionary<string, object>();
            foreach (FieldInfo field in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                var fieldValue = field.GetValue(obj);
                dict[field.Name] = ProcessValue(fieldValue, processedObjects);
            }
            return dict;
        }

        private static object ProcessValue(object value, HashSet<object> processedObjects)
        {
            if (value == null)
                return null;

            var type = value.GetType();

            // Se il tipo è nelle eccezioni, restituisci il valore così com'è
            if (exceptionTypes.Contains(type))
            {
                return value;
            }

            // Tipi primitivi e comuni
            if (type.IsPrimitive || value is string || value is decimal || value is DateTime || value is Guid)
            {
                return value;
            }

            // Gestione degli array e delle collezioni
            if (value is IEnumerable enumerable && !(value is string))
            {
                var list = new List<object>();
                foreach (var item in enumerable)
                {
                    list.Add(ProcessValue(item, processedObjects));
                }
                return list;
            }

            // Evita riferimenti circolari
            if (processedObjects.Contains(value))
                return null; // O gestisci come preferisci i riferimenti ciclici

            // Oggetti complessi
            return ToDictionary(value, processedObjects);
        }
    
    
        #region FIND ALL TYPE OF OBJECT RECURSIVELY IN A PARENT

            public static List<T> FindAllObjectsOfTypeInParent<T>(Transform parent)
            {
                //get all flatted children
                List<Transform> children = GetAllChildrenFlat(parent);
                List<T> objects = new List<T>();
                foreach (Transform child in children)
                {
                    if(child.TryGetComponent<T>(out T component)) {
                        objects.Add(component);
                    }
                }
                return objects;
            }
            public static List<Transform> GetAllChildrenFlat(Transform parent)
            {
                List<Transform> children = new List<Transform>();
                TraverseHierarchy(parent, children);
                return children;
            }
            private static void TraverseHierarchy(Transform current, List<Transform> children)
            {
                foreach (Transform child in current)
                {
                    children.Add(child);
                    TraverseHierarchy(child, children); // Chiamata ricorsiva
                }
            }

        #endregion
    
    
    }



    
}