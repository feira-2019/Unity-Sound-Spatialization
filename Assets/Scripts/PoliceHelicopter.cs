using UnityEngine;

public class PoliceHelicopter : MonoBehaviour
{
    private void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, -1f);
    }
}