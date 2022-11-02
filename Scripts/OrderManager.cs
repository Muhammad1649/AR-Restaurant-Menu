using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OrderManager : MonoBehaviour {
    private PaymentGateway paymentGateway;
    [SerializeField]private string username = "Muhammad Abubakar";
    [SerializeField]private string table = "6A";
    [SerializeField]private string currency = "₦";
    [SerializeField]private List<Order> orders;
    [TextArea]
    [SerializeField]private string orderSummery;
    [SerializeField]private TMP_Text orderText;
    private void Start() {
        paymentGateway = FindObjectOfType<PaymentGateway>();

        orders.Clear();
        orderSummery = "";

        Pay();
    }
    public void AddOrder(string name, int quantity, float price) {
        orders.Add(new Order(name, quantity, price));
        PlaceOrder();
    }
    public void UpdateOrder(int index, int quantity) {
        orders[index].quantity = quantity;
    }
    public void RemoveOrder(int index) {
        orders.Remove(orders[index]);
    }
    public void PlaceOrder() {
        int orderList = 1;
        float totalPrice = 0;
        orderSummery = "ORDER BY TABLE " + table + " ( " + username + " )\n\n";
        orderSummery += "NAME     QUANTITY     PRICE\n";
        foreach (Order order in orders) {
            orderSummery += orderList + ". " + order.name + "     x" + order.quantity + "     - " + currency + order.totalPrice + "\n";
            totalPrice += order.totalPrice;
            orderList ++;
        }
        orderSummery += "\nTOTAL PRICE: " + currency + totalPrice;
        orderText.text = orderSummery;
    }
    public void Pay() {
        paymentGateway.MakePayment("test@email.com",
                                    "USD",
                                    "10.0",
                                    "fingerprint",
                                    "Dish Payment",
                                    "598753957937538",
                                    "01",
                                    "23",
                                    "212");
        
    }
}
