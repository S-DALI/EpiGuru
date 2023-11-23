using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DraggingController : MonoBehaviour
{
    [SerializeField] private float dragHorizontalSpeed = 5f;
    [SerializeField] private float lerpSpeed = 5f;

    private Vector2 touchStartPos;
    private Vector3 objectStartPos;
    private Vector3 targetPosition;
    private bool isDragging = false;
    private float minX = -5f, maxX = 5f;
    private float raycastDistance = 1f;

    private float buttonHorizontalSpeed = 0.5f;
    private void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartDrag(touch);
                    break;
                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Drag(touch);
                        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    EndDrag();
                    break;
            }
        }
    }

    private void StartDrag(Touch touch)
    {
        touchStartPos = touch.position;
        objectStartPos = transform.position;
        isDragging = true;
    }

    private void Drag(Touch touch)
    {
        Vector2 touchDelta = touch.position - touchStartPos;
        float dragDistanceX = touchDelta.x / Screen.width;

        float targetX = objectStartPos.x + dragDistanceX * dragHorizontalSpeed;
        targetX = Mathf.Clamp(targetX, minX, maxX);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(targetX - transform.position.x, 0, 0), out hit, raycastDistance))
        {
            targetPosition = transform.position;
        }
        else
        {
            targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }

    private void EndDrag()
    {
        isDragging = false;
    }
}