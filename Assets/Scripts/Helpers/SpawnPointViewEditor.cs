using UnityEditor;
using UnityEngine;
using Views;

namespace Helpers
{
    [CustomEditor(typeof(SpawnPointView))]
    public class SpawnPointViewEditor : Editor
    {
#if UNITY_EDITOR

        // private float _radius = 1f;
        // public void OnSceneGUI()
        // {
        //     if (target is SpawnPointView view)
        //     {
        //         Handles.color = new Color(0, 1, 0, 0.7f);
        //         var position = view.transform.position;
        //         Handles.DrawSolidDisc(position, Vector3.up, _radius);
        //         
        //         if (view.Side != 0)
        //         {
        //             Handles.color = new Color(1f, 0.7f, 0.1f, 1);
        //             Handles.Label(position, view.Side.ToString());
        //         }
        //     }
        // }
#endif
    }
}