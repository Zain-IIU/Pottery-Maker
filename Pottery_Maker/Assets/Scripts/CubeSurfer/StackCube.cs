using System;
using System.Diagnostics.Tracing;
using UnityEngine;


    public class StackCube : MonoBehaviour
    {
        [SerializeField] private Transform targetToFollow;

        [SerializeField] private float followSpeed;
        [SerializeField] private float offset;

        [SerializeField] private bool isPartOfStack;

        private static int _cubeID;

        [SerializeField] private int curId;

        private void Awake()
        {
            curId = _cubeID++;
        }

        private void Start()
        {
            
            EventsManager.OnAddCubeToStack += AddCubeToStack;
        }

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (!targetToFollow) return;
            
            var transforms = transform.position;

            transforms.y = Mathf.Lerp(transforms.y, targetToFollow.transform.position.y +offset, followSpeed * Time.deltaTime);
            transform.position = transforms;
        }


        public void UpdateFollowTarget(Transform newTarget) => targetToFollow = newTarget;

        public bool IsPartOfStack() => isPartOfStack;
        public void MakePartOfStack() => isPartOfStack =true;


       
        private void OnTriggerEnter(Collider other)
        {
           
            if(other.gameObject.CompareTag("Player"))
            {
                if (isPartOfStack) return;
                EventsManager.AddToStack(curId);
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                if (!isPartOfStack) return;
                other.transform.tag = "NoCollision";
                StackManager.Instance.RemoveItem(this);
            }
        }
        private void AddCubeToStack(int id)
        {
            if (id == curId)
            {
                StackManager.Instance.AddCubeToStack(this);
            }
        }
    }
