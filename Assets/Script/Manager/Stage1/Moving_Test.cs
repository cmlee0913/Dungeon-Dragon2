using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Test : MonoBehaviour
{
    // Start is called before the first frame update
    public Stage1Pattern patternManager;
    public GameObject Cursor;

    [SerializeField]
    GameObject selectedTile;

    [SerializeField]
    int selectedNumber;

    public bool isNotDelay;
    void Start()
    {
        selectedNumber = 0;
        isNotDelay = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetCursorPosition();

        if (isNotDelay)
        {
            //SetActivated();
            CheckAnswer();
        }
    }

    void SetCursorPosition()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedNumber % 5 == 0) return;
            selectedNumber -= 1;

            selectedTile = patternManager.GroundTile[selectedNumber];
            Cursor.transform.position = selectedTile.transform.localPosition;
            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedNumber % 5 == 4 ) return;
            selectedNumber += 1;

            selectedTile = patternManager.GroundTile[selectedNumber];
            Cursor.transform.position = selectedTile.transform.localPosition;
            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectedNumber > 19) return;
            selectedNumber += 5;

            selectedTile = patternManager.GroundTile[selectedNumber];
            Cursor.transform.position = selectedTile.transform.localPosition;
            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedNumber < 5) return;
            selectedNumber -= 5;

            selectedTile = patternManager.GroundTile[selectedNumber];
            Cursor.transform.position = selectedTile.transform.localPosition;
            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
    }

    void SetActivated()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            selectedTile.GetComponent<TileStatus>().isActivated = true;
        }
    }


    void CheckAnswer()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            patternManager.TakeAnswerPuzzle(patternManager.CheckPuzzleAnswer());
        }
    }
}
