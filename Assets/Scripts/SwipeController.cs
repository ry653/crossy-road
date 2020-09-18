using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private bool isDragging, isMobilePlatform, go;
    private Vector2 tapPoint, swipeDelta;
    private float minSwipeDelta = 130;


    public enum SwipeType
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public delegate void OnSwipeInput(SwipeType type);
    public static event OnSwipeInput SwipeEvent;
 
    private void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        isMobilePlatform = false;
#else
            isMobilePlatform = true;
#endif
    }

    private void Update()
    {
        if (!isMobilePlatform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                tapPoint = Input.mousePosition;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                ResetSwipe();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    isDragging = true;
                    tapPoint = Input.touches[0].position;

                }
                else if (Input.touches[0].phase == TouchPhase.Canceled ||
                         Input.touches[0].phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }

        CalculateSwipe();
    }

    private void CalculateSwipe()
    {

        if (isDragging)
        {   go = true;
            swipeDelta = Vector2.zero;
            if (!isMobilePlatform && Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - tapPoint;
                go = false;
            }
            else if (Input.touchCount > 0)
            {
                swipeDelta = Input.touches[0].position - tapPoint;
                go = false;
            }
            
        }
        if ((swipeDelta.magnitude > minSwipeDelta ) || go)
        {
            if (SwipeEvent != null && !go)
            {
                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    SwipeEvent(swipeDelta.x < 0 ? SwipeType.LEFT : SwipeType.RIGHT);
                }
                else
                {
                    SwipeEvent(swipeDelta.y > 0 ? SwipeType.UP : SwipeType.DOWN);
                }
            }
            if (go)
            {
                SwipeEvent?.Invoke(SwipeType.UP);
            }
            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        isDragging = false;
        tapPoint = Vector2.zero;
        swipeDelta = Vector2.zero;
        go = false;
    }
}
