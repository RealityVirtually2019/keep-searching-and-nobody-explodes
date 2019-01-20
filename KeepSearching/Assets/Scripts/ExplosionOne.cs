using UnityEngine;

public class ExplosionOne : MonoBehaviour {

    public GameObject[] prefabArray;
    public GameObject bomb;
    public int burstCount = 20;
    public float fragMass = 1.0f;
    public float fragDrag = 2.0f;
    public float fragYOffset = 0.15f;
    public float radius = 5.0F;
    public float power = 5.0F;
    public float jitter = 0.25f;

    public void InitialExplosion()
    {
        Explode();
    }

    public void SecondaryExplosion()
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

    public void Explode()
    {
        var jitterMin = jitter * -1;
        var jitterMax = jitter;
        var count = 0;
        var sourcePos = bomb.transform.position;
        var bombRB = bomb.GetComponent<Rigidbody>();
        bombRB.constraints = RigidbodyConstraints.FreezeAll;
        do {
            var jitterX = Random.Range(jitterMin, jitterMax);
            var jitterY = Random.Range(jitterMin, jitterMax) + fragYOffset;
            var jitterZ = Random.Range(jitterMin, jitterMax);
            var myPos = new Vector3(sourcePos.x + jitterX, sourcePos.y + jitterY, sourcePos.z + jitterZ);
            var fragIndex = Random.Range(0, prefabArray.Length);
            var frag = Instantiate(prefabArray[fragIndex], myPos, Quaternion.identity);

            frag.AddComponent<Rigidbody>();
            //frag.AddComponent<BoxCollider>(); // Done manually
            frag.AddComponent<DestroyFragment>();

            var rb = frag.GetComponent<Rigidbody>();
            rb.AddExplosionForce(power, myPos, radius, 3.0F);
            rb.mass = fragMass;
            rb.drag = fragDrag;
            count++;
        } while (count < burstCount);
    }
}
