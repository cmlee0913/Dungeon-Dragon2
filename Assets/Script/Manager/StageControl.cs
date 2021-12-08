using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    private static StageControl _instance;

    public static StageControl Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(StageControl)) as StageControl;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    [SerializeField]
    public bool stage1Clear;
    [SerializeField]
    public bool stage2Clear;
    [SerializeField]
    public bool stage3Clear;
    [SerializeField]
    public bool stage4Clear;
    [SerializeField]
    public bool bossClear;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        stage1Clear = false;
        stage2Clear = false;
        stage3Clear = false;
        stage4Clear = false;
        bossClear = false;
    }

    public bool CheckStageClear(int stageNumber) //�������� Ŭ���� üũ
    {
        switch(stageNumber)
        {
            case 1:
                if (stage1Clear) return true;
                else return false;
            case 2:
                if (stage2Clear) return true;
                else return false;
            case 3:
                if (stage3Clear) return true;
                else return false;
            case 4:
                if (stage4Clear) return true;
                else return false;
        }


        return false;
    }

    public void StageClear(int stageNumber)
    {
        switch(stageNumber)
        {
            case 1:
                stage1Clear = true;
                break;
            case 2:
                stage2Clear = true;
                break;
            case 3:
                stage3Clear = true;
                break;
            case 4:
                stage4Clear = true;
                break;
        }
    }
}
