using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public float minZ;
    public float maxZ;
    public float forwardRoadX;
    public float backRoadX;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed);

        Vector3 transformPosition = transform.position;

        if (transformPosition.z > maxZ)
        {
            transform.Rotate(0, 180, 0);

            transformPosition.x = backRoadX;
        }
        else if (transformPosition.z < minZ)
        {
            transform.Rotate(0, 180, 0);

            transformPosition.x = forwardRoadX;
        }

        transform.position = transformPosition;
    }
}