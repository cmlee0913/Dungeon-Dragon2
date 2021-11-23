using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStage3Player : MonoBehaviour
{
    public int test_stage3_hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TestPoison.is_poison)
        {
            test_stage3_hp -= 1;
        }
    }


    // hp È®ÀÎ¿ë 
    float baseWidth = 854f;
    float baseHeight = 480f;

    public Texture test_player_icon;
    public GUIStyle test_player_label;

    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(
            Vector3.zero,
            Quaternion.identity,
            new Vector3(Screen.width / baseWidth, Screen.height / baseHeight, 1f));

        GUI.Label(
            new Rect(8f, 8f, 128f, 48f),
            new GUIContent(test_stage3_hp.ToString("0"), test_player_icon),
            test_player_label);
    }
}
