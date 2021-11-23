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

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
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
