using Shared.Classes;
using Sirenix.OdinInspector.Editor;
using System;
using System.Linq;
using UnityEditor;

namespace Editor.DataManager {
    public class DataManager : OdinMenuEditorWindow
    {
        private static Type[] typesToDisplay = TypeCache.GetTypesWithAttribute<ManageableDataAttribute>()
        .OrderBy(m => m.Name)
        .ToArray();

        private Type selectedType;

        [MenuItem("DemG/Data Manager")]
        private static void OpenEditor() => GetWindow<DataManager>();

        protected override void OnImGUI()
        {
            //draw menu tree for SOs and other assets
            if (GUIUtils.SelectButtonList(ref selectedType, typesToDisplay))
                this.ForceMenuTreeRebuild();

            base.OnImGUI();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            if(selectedType != null)
                tree.AddAllAssetsAtPath(selectedType.Name, "Assets/", selectedType, true, true);
            return tree;
        }
    }

}

