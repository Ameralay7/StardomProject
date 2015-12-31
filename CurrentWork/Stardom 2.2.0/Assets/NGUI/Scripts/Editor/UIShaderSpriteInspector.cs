using UnityEngine;
using UnityEditor;
using System.Collections;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIShaderSprite), true)]
public class UIShaderSpriteInspector : UISpriteInspector
{
    protected override bool ShouldDrawProperties()
    {
        ShaderMenuUtility.ShaderField("Shader", serializedObject, "mShader", GUILayout.MinWidth(20f));

        SerializedProperty sp = serializedObject.FindProperty("clipMask");
        if (sp != null)
        {
            Texture tex = sp.objectReferenceValue as UnityEngine.Object as Texture;
            sp.objectReferenceValue = EditorGUILayout.ObjectField("Mask:", tex, typeof(Texture), true, GUILayout.Height(60));
        }

        return base.ShouldDrawProperties();
    }
}
