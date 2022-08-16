using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private SwerveControl swerveControl;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float horizontalSpeed;
        private Vector3 _moveVector;
        public void MovePlayer()
        {
            var horizontal = swerveControl.MoveFactorX;
            _moveVector.z = moveSpeed * Time.deltaTime;
            _moveVector.y = 0;
            _moveVector.x = horizontal * horizontalSpeed * Time.deltaTime;
            transform.Translate(_moveVector);
        }
    }
