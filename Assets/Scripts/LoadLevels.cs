using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadLevels
{
    public enum Scene { Level1 }


    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
