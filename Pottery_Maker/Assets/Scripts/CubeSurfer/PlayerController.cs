using UnityEngine;


    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Transform stackPoint;
        [SerializeField] private Transform cameraFollowPoint;
        private void Update()
        {
           playerMovement.MovePlayer();
        }
        public Transform GetStackPoint() => stackPoint;
        
        public Transform GetCameraPoint() => cameraFollowPoint;

    }