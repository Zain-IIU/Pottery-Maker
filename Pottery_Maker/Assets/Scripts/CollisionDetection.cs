using UnityEngine;


    public class CollisionDetection : MonoBehaviour
    {
        public int colIndex;
        private BoxCollider _collider;
        
        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            colIndex = transform.GetSiblingIndex();
        }

        public void HitCollider(float damageValue)
        {
            if (_collider.size.z - damageValue > 0.0f)
                _collider.size = new Vector3(_collider.size.x, _collider.size.y , _collider.size.z- damageValue);
            else
                Destroy(this);
        }
    }
