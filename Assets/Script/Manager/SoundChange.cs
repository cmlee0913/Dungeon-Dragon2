using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SoundChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusicVol()
    {
        SoundManager.Instance.musicVol = GetComponent<Scrollbar>().value;
    }

    public void ChangeSoundVol()
    {
        SoundManager.Instance.soundVol = GetComponent<Scrollbar>().value;
    }
}
