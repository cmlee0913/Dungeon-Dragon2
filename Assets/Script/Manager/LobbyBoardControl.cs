using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBoardControl : MonoBehaviour
{
    public GameObject Stage1ClearPannel;
    public GameObject Stage2ClearPannel;
    public GameObject Stage3ClearPannel;
    public GameObject Stage4ClearPannel;
    // Start is called before the first frame update
    void Start()
    {
        if (StageControl.Instance.CheckStageClear(1))
            Stage1ClearPannel.SetActive(true);
        if (StageControl.Instance.CheckStageClear(2))
            Stage2ClearPannel.SetActive(true);
        if (StageControl.Instance.CheckStageClear(3))
            Stage3ClearPannel.SetActive(true);
        if (StageControl.Instance.CheckStageClear(4))
            Stage4ClearPannel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
