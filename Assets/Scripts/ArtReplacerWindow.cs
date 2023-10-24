using UnityEngine;
using UnityEditor;

public class ArtReplacerWindow : EditorWindow
{
    private Texture2D newSpriteSheet;

    [MenuItem("Tools/Art Replacer")]
    public static void ShowWindow()
    {
        GetWindow<ArtReplacerWindow>("Art Replacer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Art Replacement Tool", EditorStyles.boldLabel);

        newSpriteSheet = (Texture2D)EditorGUILayout.ObjectField("New SpriteSheet", newSpriteSheet, typeof(Texture2D), false);

        if (GUILayout.Button("Replace Art"))
        {
            ReplaceArt();
        }
    }

    void ReplaceArt()
    {
        // Replacement logic will go here.
        Debug.Log("Replace button pressed!"); // For now, just log to see if it's working.
    }

}
