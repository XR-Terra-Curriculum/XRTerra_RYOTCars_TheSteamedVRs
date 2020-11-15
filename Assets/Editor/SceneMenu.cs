using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneMenu
{
    [MenuItem("Scenes/Dealership")]
    public static void OpenDealership()
    {
        OpenScene("Production- Dealership");
    }

    [MenuItem("Scenes/Forest")]
    public static void OpenForest()
    {
        OpenScene("Production- Forest");
    }

    [MenuItem("Scenes/Victorian")]
    public static void OpenVictorian()
    {
        OpenScene("Production- Victorian");
    }

    private static void OpenScene(string sceneName)
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Production-Maps/Production- Persistent.unity", OpenSceneMode.Single);
        EditorSceneManager.OpenScene("Assets/Scenes/Production-Maps/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
}