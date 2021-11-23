using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Pattern : MonoBehaviour
{
    public int puzzleLevel;

    public GameObject Cursor;
    public GameObject Door;
    public GameObject Camera;

    public List<GameObject> GroundTile;
    public List<GameObject> AnswerTile;
    // Start is called before the first frame update
    void Start()
    {
        puzzleLevel = 1;

        SettingTileNumber();
        SettingPuzzle(puzzleLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingTileNumber()
    {
        for(int i = 0; i < GroundTile.Count; i++)
        {
            GroundTile[i].GetComponent<TileStatus>().tileNumber = i;
            AnswerTile[i].GetComponent<TileStatus>().tileNumber = i;
        }
    }

    public void SettingPuzzle(int puzzleLevel)
    {
        for(int i= 0; i < GroundTile.Count; i++)
        {
            AnswerTile[i].GetComponent<TileStatus>().isActivated = false;
            GroundTile[i].GetComponent<TileStatus>().isActivated = false;
        }
        switch(puzzleLevel)
        {
            case 1:
                for(int i = 0; i < GroundTile.Count; i++)
                {
                    if(i == 0 || i == 4 || i == 6 || i == 8 || i == 9 || i == 12 || i == 14 || i == 16 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24)
                    {
                        AnswerTile[i].GetComponent<TileStatus>().isActivated = true;
                    }

                    if (i == 4 || i == 6 || i == 8 || i == 12 || i == 16 || i == 18 || i == 20 || i == 23)
                    {
                        GroundTile[i].GetComponent<TileStatus>().isActivated = true;
                    }
                 
                }
                break;
            case 2:
                for (int i = 0; i < GroundTile.Count; i++)
                {
                    if (i == 2 || i == 3 || i == 4 || i == 7 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 17 || i == 20 || i == 21 || i == 22)
                    {
                        AnswerTile[i].GetComponent<TileStatus>().isActivated = true;
                    }
               

                    if (i == 2 || i == 3 || i == 4 || i == 9 || i == 10 || i == 11 || i == 12 || i == 14 || i == 17 || i == 20)
                    {
                        GroundTile[i].GetComponent<TileStatus>().isActivated = true;
                    }
                 
                }
                break;
            case 3:
                for (int i = 0; i < GroundTile.Count; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 8 || i == 10 || i == 12 || i == 14 || i == 15 || i == 18 || i == 19 || i == 20 || i == 24)
                    {
                        AnswerTile[i].GetComponent<TileStatus>().isActivated = true;
                    }
                  
                    if (i == 0 || i == 3 || i == 4 || i == 5 || i == 8 || i == 10 || i == 12 || i == 14 || i == 20)
                    {
                        GroundTile[i].GetComponent<TileStatus>().isActivated = true;
                    }
                  
                }
                break;
            case 4:
                for (int i = 0; i < GroundTile.Count; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 6 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 14 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24) 
                    {
                        AnswerTile[i].GetComponent<TileStatus>().isActivated = true;
                    }
                
                    if (i == 0 || i == 2 || i == 3 || i == 6 || i == 8 || i == 9 || i == 11 || i == 14 || i == 21 || i == 22 || i == 24)
                    {
                        GroundTile[i].GetComponent<TileStatus>().isActivated = true;
                    }
                }
                break;
        }
    }

    public bool CheckPuzzleAnswer()
    {
        for(int i = 0; i < GroundTile.Count; i++)
        {
            if (GroundTile[i].GetComponent<TileStatus>().isActivated 
                != AnswerTile[i].GetComponent<TileStatus>().isActivated)
                return false;   
        }
        return true;
    }

  
    IEnumerator PuzzleRemix(bool puzzleClear)
    {
        Cursor.GetComponent<Moving_Test>().isNotDelay = false;


        if (puzzleClear)
        {
            puzzleLevel++;
            for (int i = 0; i < GroundTile.Count; i++)
            {
                GroundTile[i].GetComponent<TileStatus>().isBlue = true;
                AnswerTile[i].GetComponent<TileStatus>().isBlue = true;
            }
        }
        else
        {
            for (int i = 0; i < GroundTile.Count; i++)
            {
                GroundTile[i].GetComponent<TileStatus>().isRed = true;
                AnswerTile[i].GetComponent<TileStatus>().isRed = true;
            }
        }

        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < GroundTile.Count; i++)
        {
            GroundTile[i].GetComponent<TileStatus>().isBlue = false;
            AnswerTile[i].GetComponent<TileStatus>().isBlue = false;
            GroundTile[i].GetComponent<TileStatus>().isRed = false;
            AnswerTile[i].GetComponent<TileStatus>().isRed = false;
        }

        SettingPuzzle(puzzleLevel);
        Cursor.GetComponent<Moving_Test>().isNotDelay = true;

        if(puzzleLevel == 5)
        {
            ClearPuzzle();
        }
    }

    IEnumerator OpenDoor()
    {
        Door.GetComponent<OpenDoor>().Clear();
        Camera.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        Camera.SetActive(false);
    }
    public void TakeAnswerPuzzle(bool puzzleClear)
    {
        StartCoroutine(PuzzleRemix(puzzleClear));
    }

    public void ClearPuzzle()
    {
        if (puzzleLevel < 5)
            return;

        StartCoroutine(OpenDoor());

    }
}
