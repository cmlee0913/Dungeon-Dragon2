using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Title : MonoBehaviour
{
    public void BTN_GameStart() { // GameStart 버튼
        SceneManager.LoadScene("Lobby");
    }

    public void BTN_Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void BTN_Exit() { // Exit 버튼
    #if UNITY_EDITOR // 유니티 에디터 안에서
        UnityEditor.EditorApplication.isPlaying = false;
    #else // 빌드된 어플리케이션 안에서
        Application.Quit();
    #endif
    }
}