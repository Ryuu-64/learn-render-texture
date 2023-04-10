using System;
using UnityEngine;
using static System.Math;
using static UnityEngine.Mathf;

public class RenderSizeGetter : MonoBehaviour
{
    [SerializeField] private double focalLength;

    private void Awake()
    {
        float fieldOfView = GetComponentInChildren<Camera>().fieldOfView;
        Vector3 quadSize = GetComponent<Renderer>().bounds.size;
        double filmWidth = quadSize.x;
        double filmHeight = quadSize.y;
        focalLength = CalculateFocalLength(filmWidth, filmHeight, fieldOfView);
    }

    private static double CalculateFocalLength(double filmWidth, double filmHeight, double fov)
    {
        double fovRadians = Deg2Rad * fov;
        double diagonalFilmLength = Sqrt(Pow(filmWidth, 2) + Pow(filmHeight, 2));
        double focalLength = diagonalFilmLength / 2 * Tan(fovRadians / 2);
        return focalLength;
    }
}