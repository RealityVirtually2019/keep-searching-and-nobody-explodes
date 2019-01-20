using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {


    private string[] canvasArray = new string [10];
    public string intro, onP1, bPlace, wcPlace, onP2, wcCollect, bombDiff, diff, switchP, boom;
    public int state = 0;
    private bool triggerPressed;

	// Use this for initialization
	void Start () {

    
        canvasArray[0] = intro;
        canvasArray[1] = onP1;
        canvasArray[2] = bPlace;
        canvasArray[3] = wcPlace;
        canvasArray[4] = onP2;
        canvasArray[5] = wcCollect;
        canvasArray[6] = bombDiff;
        canvasArray[7] = diff;
        canvasArray[8] = switchP; 
        canvasArray[9] = boom;



    }
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            state ++;
            if (state > 9) state = 0;
            ChangeCanvasText(state);
        }


    }
    private void ChangeCanvasText(int st)
    {
        GetComponent<Text>().text = canvasArray[st];
    }
}
