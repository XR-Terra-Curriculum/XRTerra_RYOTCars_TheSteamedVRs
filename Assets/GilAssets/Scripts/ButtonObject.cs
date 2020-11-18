using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    public void LoadScene(int scene)
    {
        switch (scene)
        {
            case 0:
                SceneLoader.Instance.LoadNewScene("Production- Dealership");
                break;
            case 1:
                SceneLoader.Instance.LoadNewScene("Production- Victorian");
                break;
            case 2:
                SceneLoader.Instance.LoadNewScene("Production- Forest");
                break;
            case 3:
                SceneLoader.Instance.LoadNewScene("Production - Space");
                break;
            default:
                SceneLoader.Instance.LoadNewScene("Production- Dealership");
                break;
        }
    }
}
