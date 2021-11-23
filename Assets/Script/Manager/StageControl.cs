using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    private static StageControl _instance;
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static StageControl Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(StageControl)) as StageControl;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    bool stage1Clear;
    bool stage2Clear;
    bool stage3Clear;
    bool stage4Clear;
    bool bossClear;

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

        // �ٸ��� �Է� ��
        return false;
    }

    public void StageClear(int stageNumber) // �������� Ŭ���� ��, bool ���� ���� ��
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
