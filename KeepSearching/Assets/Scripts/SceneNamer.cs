using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SceneNamer : MonoBehaviour {

    void Start ()
    {
        GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }
}
