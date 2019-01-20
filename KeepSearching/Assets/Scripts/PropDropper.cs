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


    private GameObject _bomberHat;
    private GameObject _bomberManual;

    public void DropProps(PropSet props)
    {
        switch (props) {
            case PropSet.BOMBER_ONBOARDING:
                _bomberHat = Instantiate(BomberHat, BomberHatSpawnPos.position, Quaternion.identity);
                _bomberManual = Instantiate(BomberManual, BomberManualSpawnPos.position, Quaternion.identity);
                break;
            case PropSet.BOMBER_TOOLS:
                    break;
        }
    }

    public void RemoveBomberOnboardingProps()
    {
        Destroy(_bomberHat);
        Destroy(_bomberManual);
    }
}
