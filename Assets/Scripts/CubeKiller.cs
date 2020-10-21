using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKiller : MonoBehaviour
{
    [SerializeField] private Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var ray = camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return;

        var rig = hit.collider.attachedRigidbody;
        if (rig != null)
        {
            var dir = (hit.point - transform.position).normalized * 10f;
            rig.AddForceAtPosition(dir, hit.point, ForceMode.Impulse);
        }
    }
}
