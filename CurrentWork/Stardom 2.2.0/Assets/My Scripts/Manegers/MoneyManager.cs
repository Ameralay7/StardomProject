using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {

	public UILabel moneyLabel;
	public int money;

	public UILabel spinPriceLabel;
	private float spinPriceFactor = 1;

	void Start () {
		money = 500000;
		UpdateMoney(0);
	}
	
	public void UpdateMoney (int amount) {
	
		money += amount;

		moneyLabel.text = "$ " + money;
	}

	public void SlotMoney(){

		int price = 500;
		spinPriceFactor += 1;
		price += (int)spinPriceFactor*500;
		spinPriceLabel.text = "$" + price;
		UpdateMoney(-1*price);
	}


}
