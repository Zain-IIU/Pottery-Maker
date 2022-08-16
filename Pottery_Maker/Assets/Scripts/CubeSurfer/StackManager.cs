using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    #region Singleton
    public static StackManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
   

    [SerializeField] private List<StackCube> cubes = new List<StackCube>();
    [SerializeField] private PlayerController player;

    private bool _hasAddedFirst;

    public void AddCubeToStack(StackCube cubeToAdd)
    {
        cubeToAdd.MakePartOfStack();
        cubeToAdd.transform.parent = player.GetStackPoint();
        
        if (!_hasAddedFirst)
            _hasAddedFirst = true;
        else
        {
            cubeToAdd.transform.DOLocalMove(Vector3.zero, .05f);
            cubeToAdd.UpdateFollowTarget(cubes[cubes.Count-1].transform);
        }
        
        cubes.Add(cubeToAdd);
        player.GetCameraPoint().DOLocalMoveY(player.GetCameraPoint().localPosition.y + .5f, .04f);
        
    }

    public void RemoveItem(StackCube cube)
    {
        var index = cubes.IndexOf(cube);

        if (index == -1) return;
        
        cubes[index+1].UpdateFollowTarget(null);
        //cubes[index + 1].transform.DOLocalMove(Vector3.zero, .05f);
        cubes[index+1].GetComponent<Rigidbody>().useGravity = true;
        var count = 0;
        for (var i = index; i >= 0; i--)
        {
            player.GetCameraPoint().DOLocalMoveY(player.GetCameraPoint().localPosition.y - .5f, .04f);
            count++;
             cubes[i].transform.parent = null;
        }
        cubes.RemoveRange(0,count);
        
    }
}
