using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public int fireForce;
    
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * fireForce);
        
        Destroy(gameObject, 2);
    }
}
