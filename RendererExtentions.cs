using UnityEngine;
using System.Collections;

public static class RendererExtentions 
{
    // This class is designed to return a value on whether or not the object is currently visible from the camera or not

    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
