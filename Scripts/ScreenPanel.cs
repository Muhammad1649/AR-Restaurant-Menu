using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenPanel : MonoBehaviour, IDragHandler, IEndDragHandler {
    [HideInInspector]public bool swipeForward;
    [HideInInspector]public bool swipeBackward;
    [SerializeField]private float dragThreshold = 0.1f;
    private FoodBase foodBase;
    private bool swipe;
    private void Start() {
        foodBase = FindObjectOfType<FoodBase>();
    }
    public void OnDrag(PointerEventData data) {}
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= dragThreshold && swipe) {
            if(percentage > 0 && swipeForward) { foodBase.NavigateDishes("Forward");
            } else if (percentage < 0 && swipeBackward) { foodBase.NavigateDishes("Backward"); }
        }
    }
    public void Enable(bool enable) { swipe = enable; }
}
