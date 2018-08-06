using UnityEngine;

public class Quit : MonoBehaviour
{
    // This just quits the application. Doesn't do anything while in the editor
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
