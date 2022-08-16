using System;
using UnityEngine;


    public class EventsManager : MonoBehaviour
    {

        public static event Action<int> OnAddCubeToStack;

        public static  void AddToStack(int obj)
        {
            OnAddCubeToStack?.Invoke(obj);
        }
    }
