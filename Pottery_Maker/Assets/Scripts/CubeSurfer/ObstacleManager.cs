
using UnityEngine;


public class ObstacleManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out StackCube cube))
        {
            GetComponent<Collider>().enabled = false;
            StackManager.Instance.RemoveItem(cube);
        }
    }
}
