using System.Collections.Generic;
using UnityEngine;

public class FoodBase : MonoBehaviour {
    private UIManager uIManager;
    private ScreenPanel screenPanel;
    private Animator animator;
    public float rotationSpeed = 1f;
    [SerializeField]private GameObject defaultObject;

    [Header("Dish Categories")]
    [SerializeField]private List<Dish> mainCourse = new List<Dish>();
    [SerializeField]private List<Dish> desert = new List<Dish>();
    [SerializeField]private List<Dish> snacks = new List<Dish>();
    [SerializeField]private List<Dish> drinks = new List<Dish>();

    private Dictionary<string, List<Dish>> categories = new Dictionary<string, List<Dish>>();

    private List<Dish> selectedCategory;
    private int selectedDish;
    private GameObject dish;
    private bool instantiated;

    private void Start() {
        uIManager = FindObjectOfType<UIManager>();
        screenPanel = FindObjectOfType<ScreenPanel>();
        animator = GetComponent<Animator>();

        categories.Add("Main Course", mainCourse);
        categories.Add("Desert", desert);
        categories.Add("Snacks", snacks);
        categories.Add("Drinks", drinks);

        selectedCategory = categories["Main Course"];
        selectedDish = 0;

        uIManager.UpdateDishInfo((1 + selectedDish).ToString() + "/" + selectedCategory.Count.ToString(), selectedCategory[selectedDish]);
        RefreshDish();
        Enable(false);
    }
    private void Update() {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
        uIManager.UpdateNavigation(selectedDish < selectedCategory.Count - 1, selectedDish > 0);
    }
    public void SelectCategory(string category) {
        selectedCategory = categories[category];
        if (selectedCategory.Count < 1) {
            LoadDefaultObject();
        } else {
            selectedDish = 0;
            animator.SetTrigger("Pop Out"); 
            instantiated = false;
        }
    }
    public void NavigateDishes(string direction) {
        if(direction == "Forward") { selectedDish++; animator.SetTrigger("Pop Out"); instantiated = false;
        } else if(direction == "Backward") { selectedDish--; animator.SetTrigger("Pop Out"); instantiated = false; }
    }
    private void RefreshDish() {
        if(!instantiated) {
            animator.SetTrigger("Pop In");
            instantiated = true;
        }
        if(this.transform.childCount > 0) {
            Destroy(transform.GetChild(0).gameObject);
        }
        dish = Instantiate(selectedCategory[selectedDish].dish, this.transform);
        uIManager.UpdateDishInfo((1 + selectedDish).ToString() + "/" + selectedCategory.Count.ToString(), selectedCategory[selectedDish]);
    }
    private void LoadDefaultObject() {
        if(this.transform.childCount > 0) {
            Destroy(transform.GetChild(0).gameObject);
        }
        dish = Instantiate(defaultObject, this.transform);
        uIManager.UpdateDishInfo("0");
    }
    public void Enable(bool enable) { dish.SetActive(enable); }
}
