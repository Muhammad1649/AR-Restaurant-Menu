using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    private FoodBase foodBase;
    private ScreenPanel screenPanel;
    private OrderManager orderManager;
    [SerializeField]private GameObject forwardBtn;
    [SerializeField]private GameObject forwardImage;
    [SerializeField]private GameObject backwardBtn;
    [SerializeField]private GameObject backwardImage;
    [SerializeField]private TMP_Text dishName;
    [SerializeField]private TMP_Text dishPrice;
    [SerializeField]private GameObject dishPriceBar;
    [SerializeField]private TMP_Text promptText;
    [SerializeField]private GameObject promptBar;
    [SerializeField]private GameObject focusableLayer;
    private Dish viewedDish;

    private void Start() {
        foodBase = FindObjectOfType<FoodBase>();
        screenPanel = FindObjectOfType<ScreenPanel>();
        orderManager = FindObjectOfType<OrderManager>();
    }
    public void SelectCategory(string category) { foodBase.SelectCategory(category); }
    public void UpdateDishInfo(string dishIndex, Dish dish = null) {
        if (dish == null) {
            dishName.text = "No dishes available.";
            dishPrice.text = "₦ 0.00";
            viewedDish = null;
        } else {
            dishName.text = dishIndex + " " + dish.name;
            dishPrice.text = "₦ " + dish.price.ToString();
            viewedDish = dish;
        }
    }
    public void UpdateNavigation(bool forward, bool backward) {
        forwardBtn.SetActive(forward);
        backwardBtn.SetActive(backward);
        forwardImage.SetActive(forward);
        backwardImage.SetActive(backward);
        screenPanel.swipeForward = forward;
        screenPanel.swipeBackward = backward;
    }
    public void Prompt(string prompt = "") {
        promptText.text = prompt;
        promptBar.SetActive(prompt != "");
    }
    public void Prompt(float duration, string prompt = "") {
        promptText.text = prompt;
        promptBar.SetActive(prompt != "");
        if (duration != 0) { Invoke("PromptTimeOut", duration); }
    }
    private void PromptTimeOut() { Prompt(); }
    public void Focus() { focusableLayer.SetActive(false); }
    public void Unfocus() { focusableLayer.SetActive(true); }
    public void AddOrder() {
        if (viewedDish == null) {
            Prompt(2, "No dishes available.");
        } else {
            Prompt(2, "Item added to order list.");
            orderManager.AddOrder(viewedDish.name, 1, viewedDish.price);
        }
    }
}
