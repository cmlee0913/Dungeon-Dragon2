using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Pattern : MonoBehaviour
{
    public int puzzleLevel;

    public List<GameObject> GroundTile;
    public List<GameObject> AnswerTile;


    // Start is called before the first frame update
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
        for (int i = 0; i < GroundTile.Count; i++)
        {
            GroundTile[i].GetComponent<TileStatus>().tileNumber = i;
            AnswerTile[i].GetComponent<TileStatus>().tileNumber = i;
        }
    }

    public void SettingPuzzle(int puzzleLevel)
    {
        for (int i = 0; i < GroundTile.Count; i++)
        {
            AnswerTile[i].GetComponent<TileStatus>().isActivated = false;
            GroundTile[i].GetComponent<TileStatus>().isActivated = false;
        }
        switch (puzzleLevel)
        {
            case 1:
                for (int i = 0; i < GroundTile.Count; i++)
                {
                    if (i == 0 || i == 4 || i == 6 || i == 8 || i == 3)
                    {
                        AnswerTile[i].GetComponent<TileStatus>().isActivated = true;
                    }

                    if (i == 0 || i == 4 || i == 8)
                    {
                        GroundTile[i].GetComponent<TileStatus>().isActivated = true;
                    }

                }
                break;

            case 2:
                for (int i = 0; i < GroundTile.Count; i++)
                {
                    if (i == 1 || i == 3 || i == 2 || i == 0)
                    {
                        AnswerTile[i].GetComponent<TileStatus>().isActivated = true;
                    }

                    if (i == 0 || i == 1)
                    {
                        GroundTile[i].GetComponent<TileStatus>().isActivated = true;
                    }

                }
                break;
        }
    }

    public bool CheckPuzzleAnswer()
    {
        for (int i = 0; i < GroundTile.Count; i++)
        {
            if (GroundTile[i].GetComponent<TileStatus>().isActivated
                != AnswerTile[i].GetComponent<TileStatus>().isActivated)
                return false;
        }
        return true;
    }


    IEnumerator PuzzleRemix(bool puzzleClear)
    {


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

        if (puzzleLevel == 3)
        {
            ClearPuzzle();
        }
    }

    public void TakeAnswerPuzzle(bool puzzleClear)
    {
        StartCoroutine(PuzzleRemix(puzzleClear));
    }

    public void ClearPuzzle()
    {
        if (puzzleLevel < 3)
            return;

    }
}
