using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyControl : MonoBehaviour
{
    public GameObject OptionUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OptionUI.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        OptionUI.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
