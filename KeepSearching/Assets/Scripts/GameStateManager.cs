using UnityEngine;

[RequireComponent(typeof(PropDropper))]
public class GameStateManager : MonoBehaviour {

    public enum Phase
    {
        PLACING_BOMB,ONBOARDING_P1,HIDING_CUTTERS,ONBOARDING_P2,FINDING_CUTTERS
    }

    public static GameStateManager instance;
    public Phase currentGamePhase
    {
        set { HandleGamePhaseChange(_currentGamePhase, value); }
        get { return _currentGamePhase; }
    }

    public GameObject BomberHatInstance
    {
        get { return _propDropper._bomberHatInstance; }
    }

    public GameObject DefuserHatInstance
    {
        get { return _propDropper._defuserHatInstance; }
    }

    private PropDropper _propDropper;

    private void HandleGamePhaseChange(Phase from, Phase to)
    {
        Debug.LogFormat("Game phase changed from {0} to {1}", from, to);
        _currentGamePhase = to;
        switch (_currentGamePhase) {
                case Phase.PLACING_BOMB:
                    _propDropper.RemoveBomberOnboardingProps();
                    break;
                case Phase.ONBOARDING_P1:
                    _propDropper.DropProps(PropDropper.PropSet.BOMBER_ONBOARDING);
                    break;
                case Phase.HIDING_CUTTERS:
                    _propDropper.DropProps(PropDropper.PropSet.BOMBER_TOOLS);
                    break;
                case Phase.ONBOARDING_P2:
                    _propDropper.DropProps(PropDropper.PropSet.DEFUSER_ONBOARDING);
                    _propDropper.PrepareCutters();
                    break;
        }
    }

    private Phase _currentGamePhase;

    void Awake () {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        _propDropper = GetComponent<PropDropper>();
    }
}
