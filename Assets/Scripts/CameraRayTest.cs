using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class CameraRayTest : MonoBehaviour
{

    private GameObject[] _spheres;

    void Start()
    {
        //PointTest();
    }

    void Update()
    {
        _spheres = GameObject.FindGameObjectsWithTag("Sphere");

        foreach (GameObject _sphere in _spheres)
            DestroyImmediate(_sphere);

        PointTest();
    }

    void PointTest()
    {
        Camera camera = Camera.main;
        Transform cameraTransform = camera.transform;

        float planeHeight = 2 * Mathf.Tan((camera.fieldOfView * Mathf.Deg2Rad) / 2) * camera.nearClipPlane;
        float planeWidth = camera.aspect * planeHeight;

        Vector3 bottomLeft = new Vector3(-planeWidth / 2, -planeHeight / 2, camera.nearClipPlane);

        int xPoints = 16, yPoints = 9;

        float dx = planeWidth / (xPoints - 1);
        float dy = planeHeight / (yPoints - 1);

        for (int i = 0; i < xPoints; i++)
        {
            for (int j = 0; j < yPoints; j++)
            {
                Vector3 pointLocal = bottomLeft + new Vector3(dx * i, dy * j, 0);
                Vector3 point = cameraTransform.position + cameraTransform.right * pointLocal.x + cameraTransform.up * pointLocal.y + cameraTransform.forward * pointLocal.z;

                DrawPoint(point);
            }
        }
    }

    void DrawPoint(Vector3 point)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.tag = "Sphere";
        sphere.transform.position = point;
        sphere.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
    }
}
