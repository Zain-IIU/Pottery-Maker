using System;
using UnityEngine;


public class Knife : MonoBehaviour
{
    [SerializeField] private Wood wood;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damageAmount;
    [SerializeField] private Vector2 clampValues;

    private bool _isMoving;
    private Vector3 _moveVector;

    

    private void Update()
    {
        ClampMovement();
        _isMoving = Input.GetMouseButton(0);
        if (!_isMoving) return;
        
        _moveVector = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")) * moveSpeed*Time.deltaTime;
        
        transform.Translate(_moveVector);
        
    }

    private void ClampMovement()
    {
        var localPosition = transform.position;
        localPosition.x = Mathf.Clamp(localPosition.x, -clampValues.x, clampValues.x);
        localPosition.z = Mathf.Clamp(localPosition.z, -clampValues.y, clampValues.y);
        transform.position = localPosition;
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.gameObject.TryGetComponent(out CollisionDetection col)) return;
        col.HitCollider(damageAmount);
        wood.CutWood(col.GetColIndex(),damageAmount);
    }
}
