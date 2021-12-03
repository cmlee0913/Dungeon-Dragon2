using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;


    void Awake()
    {
        if (null == instance)
        {
            
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
          
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public float soundVol;
    public float musicVol;

    // Start is called before the first frame update
    void Start()
    {
        soundVol = 0.5f;
        musicVol = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
