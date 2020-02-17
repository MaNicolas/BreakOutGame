using UnityEngine;
using UnityEditor;

public class ResetBestScore : EditorWindow
{
    [MenuItem("Tool/Reset Best Score")]
    public static void ResetSave()
    {
        PlayerPrefs.DeleteAll();
    }
}