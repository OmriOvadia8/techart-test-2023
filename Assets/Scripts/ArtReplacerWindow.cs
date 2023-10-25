using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Linq;

public class ArtReplacerTool : EditorWindow
{
    private GameObject templatePrefab;
    private Texture2D newSpriteSheet;
    private string prefabName = "NewPrefab";

    [MenuItem("Tools/Art Replacer")]
    static void Init()
    {
        ArtReplacerTool window = GetWindow<ArtReplacerTool>();
        window.Show();
    }

    void OnGUI()
    {
        DisplayFields();
        DisplayReplaceButton();
    }

    private void DisplayFields()
    {
        templatePrefab = (GameObject)EditorGUILayout.ObjectField("Template Prefab:", templatePrefab, typeof(GameObject), false);
        newSpriteSheet = (Texture2D)EditorGUILayout.ObjectField("New SpriteSheet:", newSpriteSheet, typeof(Texture2D), false);
        prefabName = EditorGUILayout.TextField("Prefab Name:", prefabName);
    }

    private void DisplayReplaceButton()
    {
        if (GUILayout.Button("Replace Art & Save New Prefab"))
        {
            ReplaceArt();
        }
    }

    private void ReplaceArt()
    {
        if (!HasValidInput())
        {
            Debug.LogError("Ensure both the Template Prefab and New SpriteSheet are set!");
            return;
        }

        GameObject newInstance = Instantiate(templatePrefab);
        Sprite[] sprites = LoadSpritesFromSheet();
        ReplaceSpritesInChildren(newInstance.transform, sprites);
        SavePrefab(newInstance);
        DestroyImmediate(newInstance);
    }

    private bool HasValidInput()
    {
        return templatePrefab != null && newSpriteSheet != null;
    }

    private Sprite[] LoadSpritesFromSheet()
    {
        string spriteSheetPath = AssetDatabase.GetAssetPath(newSpriteSheet);
        return AssetDatabase.LoadAllAssetsAtPath(spriteSheetPath).OfType<Sprite>().ToArray();
    }

    private void SavePrefab(GameObject instance)
    {
        string prefabPath = $"Assets/Prefabs/{prefabName}.prefab";
        PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);
    }

    private void ReplaceSpritesInChildren(Transform parent, Sprite[] sprites)
    {
        foreach (Transform child in parent)
        {
            Image img = child.GetComponent<Image>();
            if (img != null && img.sprite != null)
            {
                string currentSpriteName = img.sprite.name;
                Sprite matchingSprite = sprites.FirstOrDefault(sprite => sprite.name == currentSpriteName);
                if (matchingSprite != null)
                {
                    img.sprite = matchingSprite;
                }
            }
            ReplaceSpritesInChildren(child, sprites);
        }
    }
}