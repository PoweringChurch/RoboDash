/* PositionClamp Class
 * Unity Game Programming
 * CompuScholar, Inc.
 * 
 * This class limits the position of a sprite or camera
 * to fall entirely within defined world boundaries.
 */
using UnityEngine;

public class PositionClamp
{
    // adjusted boundaries in world coordinates so no part
    // of the sprite or camera goes out of bounds
    private float minX;
    private float minY;

    private float maxX;
    private float maxY;

    // constructor used to clamp a sprite
    public PositionClamp(float worldMinX, float worldMinY, float worldMaxX, float worldMaxY, Renderer r)
    {
        // calculate half sprite width and height from renderer
        float halfSpriteWidth = r.bounds.size.x / 2.0f;
        float halfSpriteHeight = r.bounds.size.y / 2.0f;

        // calculate and save min/max boundaries for this sprite
        minX = worldMinX + halfSpriteWidth;
        minY = worldMinY + halfSpriteHeight;

        maxX = worldMaxX - halfSpriteWidth;
        maxY = worldMaxY - halfSpriteHeight;
    }

    // constructor used to clamp a camera
    public PositionClamp(float worldMinX, float worldMinY, float worldMaxX, float worldMaxY, Camera cam)
    {
        // calculate half camera width and height, in world dimensions
        float halfCameraHeight = cam.orthographicSize;
        float halfCameraWidth = halfCameraHeight * cam.aspect;

        // calculate and save min/max boundaries for this camera
        minX = worldMinX + halfCameraWidth;
        minY = worldMinY + halfCameraHeight;

        maxX = worldMaxX - halfCameraWidth;
        maxY = worldMaxY - halfCameraHeight;
    }

    // limit the position in the input transform to the defined world boundaries
    // and update the provided Transform with the results
    public void limitPosition(Transform t)
    {
        // Clamp the X and Y coordinates and make sure they
        // do not go beyond calculated boundaries
        float clampedX = Mathf.Clamp(t.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(t.position.y, minY, maxY);

        // update transform position
        t.position = new Vector3(clampedX, clampedY, t.position.z);
    }

    // limit the input position to the defined world boundaries
    // and update the provided Transform with the results
    public void limitPosition(Vector3 position, Transform t)
    {
        // Clamp the X and Y coordinates and make sure they
        // do not go beyond calculated boundaries
        float clampedX = Mathf.Clamp(position.x, minX, maxX);
        float clampedY = Mathf.Clamp(position.y, minY, maxY);

        // update transform position
        t.position = new Vector3(clampedX, clampedY, t.position.z);
    }
}
