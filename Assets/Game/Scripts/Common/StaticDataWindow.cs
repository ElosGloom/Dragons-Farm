using Game.Scripts.ECS;
using UnityEditor;

namespace Game.Scripts.Common
{
    public abstract class StaticDataWindow
    {
        [MenuItem("Game/Static Data")]
        private static void ShowWindow()
        {
            var staticData = Utils.ScriptableObjectSearcher.GetAllInstances<StaticData>()[0];
            EditorUtility.OpenPropertyEditor(staticData);
        }
    }
}