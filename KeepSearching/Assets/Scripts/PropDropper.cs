using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDropper : MonoBehaviour
{
    public enum PropSet
    {
        BOMBER_ONBOARDING, BOMBER_TOOLS, DEFUSER_ONBOARDING
    }

    public Transform Anchor;
    public GameObject BomberHat;
    public Transform BomberHatSpawnPos;
    public GameObject BomberManual;
    public Transform BomberManualSpawnPos;
    public GameObject Cutters;
    public Transform CuttersSpawnPos;
    public GameObject DefuserHat;
    public Transform DefuserHatSpawnPos;
    public GameObject DefuserManual;
    public Transform DefuserManualSpawnPos;


    public GameObject _bomberHat;
    public GameObject _bomberManual;
    public GameObject _cutters;

    public void DropProps(PropSet props)
    {
        switch (props) {
            case PropSet.BOMBER_ONBOARDING:
                _bomberHat = Instantiate(BomberHat, BomberHatSpawnPos.position, Quaternion.identity);
                _bomberManual = Instantiate(BomberManual, BomberManualSpawnPos.position, Quaternion.identity);
                break;
            case PropSet.BOMBER_TOOLS:
                _cutters = Instantiate(Cutters, CuttersSpawnPos.position, Quaternion.identity);
                break;
        }
    }

    public void RemoveBomberOnboardingProps()
    {
        if (_bomberHat != null) Destroy(_bomberHat);
        if (_bomberManual != null) Destroy(_bomberManual);
    }
}
