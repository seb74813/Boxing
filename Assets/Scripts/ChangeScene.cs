using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is used to allow the script access to the scene management code
using UnityEngine.SceneManagement;


/// <summary>
/// The ChangeScene class contains a method which changes the current scene
/// </summary>
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// The ChangeSce method which changes the current scene to one named the same as the scene string
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeSce(string scene)
    {
        //This changes the scene to one that has the same name as the string given
        SceneManager.LoadScene(scene);
    }
}
