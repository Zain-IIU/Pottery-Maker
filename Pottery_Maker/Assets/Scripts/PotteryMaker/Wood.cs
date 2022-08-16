using DG.Tweening;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer woodRenderer;
    [SerializeField] private float turningTime;
    [SerializeField] private Transform woodTransform;
    [SerializeField] private Vector3 turningDirection;
    // Start is called before the first frame update
    void Start()
    {
        woodTransform.DORotate(turningDirection, turningTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    public void CutWood(int keyIndex, float damage)
    {
        var colliderHeight = 1.96f;
        var newWeight = woodRenderer.GetBlendShapeWeight(keyIndex) + damage * (100f / colliderHeight);

        woodRenderer.SetBlendShapeWeight(keyIndex, newWeight);
    }
}
