[System.Serializable]
public class Order {
    public string name;
    public int quantity;
    public float totalPrice;
    public Order(string name, int quantity, float price) {
        this.name = name;
        this.quantity = quantity;
        totalPrice = price * quantity;
    }
}
