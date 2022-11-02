using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Paymentwall;
public class PaymentGateway : MonoBehaviour {
    private string email;
    private string currency;
    private string amount;
    private string fingerprint;
    private string description;
    public void MakePayment(string email, string currency, string amount, string fingerprint, string description, string cardNumber, string expMonth, string expYear, string cvv) {
        
        this.email = email;
        this.currency = currency;
        this.amount = amount;
        this.fingerprint = fingerprint;
        this.description = description;
        
        // PWBase.SetApiMode(API_MODE.TEST);
        // PWBase.SetAppKey("t_9d2f3c386b9ddcc3d06a56e22b04fc");
        // PWBase.SetSecretKey("t_950052e1d57da295b2ca802e1c7062");
        // PWOneTimeToken tokenModel = new PWOneTimeToken ();
        // tokenModel.Create (PWBase.GetAppKey(), cardNumber, expMonth, expYear, cvv);
        // PWCharge charge = gameObject.AddComponent<PWCharge> ();

        // StartCoroutine(PaymentRoutine(charge, tokenModel));
    }

    // private IEnumerator PaymentRoutine(PWCharge charge, PWOneTimeToken tokenModel) {
    //     Debug.LogError("Payment Sent");
    //     yield return StartCoroutine(charge.Create(tokenModel, email, currency, amount, fingerprint, description));
    // }
}