using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {


    private string[] canvasArray = new string [10];
    public string bombPlace, grabP1, hatOn, wcPlace, touchBomb, grabP2, wcCollect, bombDiff, diff, switchP, boom;
    public int state = 0;

	// Use this for initialization
	void Start () {

    
        canvasArray[0] = bombPlace;
        canvasArray[1] = grabP1;
        canvasArray[2] = hatOn;
        canvasArray[3] = wcPlace;
        canvasArray[4] = touchBomb;
        canvasArray[5] = grabP2;
        canvasArray[6] = wcCollect;
        canvasArray[7] = bombDiff;
        canvasArray[8] = diff;
        canvasArray[9] = switchP; 
        canvasArray[10] = boom;



    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (GameStateManager.instance.currentGamePhase)
        {
            case GameStateManager.Phase.PLACING_BOMB:
                state = 0;
                ChangeCanvasText(state);
                break;
            case GameStateManager.Phase.ONBOARDING_P1:
                state = 2;
                ChangeCanvasText(state);
                break;
            case GameStateManager.Phase.HIDING_CUTTERS:
                state = 3;
                ChangeCanvasText(state);
                break;
//            case GameStateManager.Phase.ACTIVATING_BOMB:
//                state = 4;
//                ChangeCanvasText(state);
//                break;
            case GameStateManager.Phase.ONBOARDING_P2:
                state = 6;
                ChangeCanvasText(state);
                break;
        }
    }
    private void ChangeCanvasText(int st)
    {
        GetComponent<Text>().text = "  ---- " + canvasArray[st] + "\n" + "/";
    }
}
