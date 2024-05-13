using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Game.Scripts.Utils
{
    public class ScriptableObjectSearcher
    {
        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            return AssetDatabase.FindAssets($"t: {typeof(T).Name}").ToArray()
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<T>)
                .ToArray();
        }
    }
}