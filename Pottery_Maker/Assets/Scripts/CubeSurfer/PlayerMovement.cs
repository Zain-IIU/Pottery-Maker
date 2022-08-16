using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private SwerveControl swerveControl;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float lerpTime;
        [SerializeField] private float clampValues;
        [SerializeField] private float horizontalSpeed;
        private Vector3 _moveVector;
        
        public void MovePlayer()
        {
            var horizontal = swerveControl.MoveFactorX;
            _moveVector.z = moveSpeed * Time.deltaTime;
            _moveVector.y = 0;
            var xMove = horizontal * horizontalSpeed *Time.deltaTime;
            _moveVector.x = Mathf.Lerp(_moveVector.x, xMove, lerpTime * Time.deltaTime);
            transform.Translate(_moveVector);
            ClampMovement();
        }

        private void ClampMovement()
        {
            var transforms = transform.position;

            transforms.x = Mathf.Clamp(transforms.x, -clampValues, clampValues);
            transform.position = transforms;
        }
    }   
