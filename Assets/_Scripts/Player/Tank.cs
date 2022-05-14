using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    [Header("Movement")]
    public int speed;
    public int turnSpeed;
    public int headTurnSpeed;
    
    [Header("Attack")] 
    public GameObject prefab;
    public Transform posRotCanonBall;
    public Transform posRotTankHead;
    public LayerMask layerTank;
    
    private Ray _ray;
    private RaycastHit _hit;
    private GameObject _target;

    private void Update()
    {
        Move();
        Attack();
        FindTarget();
        AutoAimToTarget();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * (v * speed * Time.deltaTime));
        transform.Rotate(Vector3.up * (h * turnSpeed * Time.deltaTime));
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, posRotCanonBall.position, posRotCanonBall.rotation);
        }
    }
    
    /*
     * FindTarget() & AutoAimToTarget()
     * ---
     * Using Raycast mainly, it makes a ray from camera to mouse and checks if there's an enemy tank,
     * if it's so, it rotates our tank's head smoothly in order to make it easy to aim.
     */ 
    private void FindTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, layerTank))
            {
                _target = _hit.collider.gameObject;
            } 
        }
    }

    private void AutoAimToTarget()
    {
        if (_target)
        {
            // Look to target
            Quaternion targetRotation = Quaternion.LookRotation(_target.transform.position - transform.position);
            posRotTankHead.rotation =
                Quaternion.Slerp(posRotTankHead.rotation, targetRotation, headTurnSpeed * Time.deltaTime);
        }


        if (_target.IsDestroyed())
        {
            CorrectAimPosition();
        }
        
    }

    private void CorrectAimPosition()
    {
        posRotTankHead.rotation = Quaternion.Slerp(posRotTankHead.rotation, transform.rotation, headTurnSpeed * Time.deltaTime);
    }
}
