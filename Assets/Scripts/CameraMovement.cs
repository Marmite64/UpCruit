using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float minZoomDist;
    [SerializeField] private float maxZoomDist;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float moveSpeed;

    [Header("References")]
    public Tilemap tilemap;

    private float size;
    private Camera cam;
    private float height;
    private float width;

    void Awake()
    {
        cam = Camera.main;
        size = Camera.main.orthographicSize;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        Move();
        Zoom();
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.up * zInput + transform.right * xInput;

        transform.position += dir * moveSpeed * Time.deltaTime;

        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        float x = Mathf.Clamp(transform.position.x, tilemap.cellBounds.xMin + (width / 2), tilemap.cellBounds.xMax - (width / 2));
        float y = Mathf.Clamp(transform.position.y, tilemap.cellBounds.yMin + (height / 2), tilemap.cellBounds.yMax - (height / 2));

        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Zoom()
    {
        size += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        size = Mathf.Clamp(size, minZoomDist, maxZoomDist);
        cam.orthographicSize = size;
    }
}