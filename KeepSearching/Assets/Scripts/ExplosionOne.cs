using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOne : MonoBehaviour {

    public ExplosionController expControl;
    public GameObject[] prefabArray;
    public GameObject bomb;
    public bool explodedOne;
    public float radius = 5.0F;
    public float power = 10.0F;
    public bool explodedTwo;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        

        if (expControl.bumperPressed)
        {
            InitialExplosion();
            //explodedOne = true;
        }
        if (expControl.buttonPressed)
        {
            SecondaryExplosion();
            explodedTwo = true;
        }

    }

    void InitialExplosion()
    {
        for(int i = 0; i < prefabArray.Length; i++)
        {
            GameObject frag = Instantiate(prefabArray[i], bomb.transform.position, Quaternion.identity);

            frag.AddComponent<Rigidbody>();
            //frag.AddComponent<BoxCollider>();
            frag.AddComponent<DestroyFragment>();

            Rigidbody rb = frag.GetComponent<Rigidbody>();
            rb.drag = 2f;
        }
    }

    void SecondaryExplosion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }
}
