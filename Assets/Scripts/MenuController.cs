using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userNameField;
    public void StartNew()
    {
        if (userNameField != null) 
        {
            if (!string.IsNullOrEmpty(userNameField.text))
            {
                if (userNameField.text.Length > 1)
                {
                    UserData.Instance.UserName = userNameField.text;
                }
                else
                {
                    UserData.Instance.UserName = "User";
                }
            }
        }

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
