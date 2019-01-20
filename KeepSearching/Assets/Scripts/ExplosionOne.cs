using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOne : MonoBehaviour {

    public ExplosionController expControl;
    public GameObject[] prefabArray;
    public GameObject bomb;
    public int burstCount = 20;
    public bool explodedOne;
    public float radius = 5.0F;
    public float power = 10.0F;
    public bool explodedTwo;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (expControl.bumperPressed && !explodedOne)
        {
            InitialExplosion();
            explodedOne = true;
        }
        if (expControl.buttonPressed && !explodedTwo)
        {
            SecondaryExplosion();
            explodedTwo = true;
        }

    }

    void InitialExplosion()
    {
        Explode();
    }

    void SecondaryExplosion()
    {
        Explode();
//        var explosionPos = bomb.transform.position;
//        var colliders = Physics.OverlapSphere(explosionPos, radius);
//        foreach (var hit in colliders)
//        {
//            var rb = hit.GetComponent<Rigidbody>();
//
//            if (rb != null)
//                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
//        }
    }

    private void Explode()
    {
        var count = 0;
        var explosionPos = bomb.transform.position;
        do {
            foreach (var prefab in prefabArray) {
                if (count >= burstCount) continue;
                var frag = Instantiate(prefab, explosionPos, Quaternion.identity);

                frag.AddComponent<Rigidbody>();
                //frag.AddComponent<BoxCollider>(); // Done manually
                frag.AddComponent<DestroyFragment>();

                var rb = frag.GetComponent<Rigidbody>();
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                rb.drag = 2f;
                count++;
            }
        } while (count < burstCount);
    }
}
