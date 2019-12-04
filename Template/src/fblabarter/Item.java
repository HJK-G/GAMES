package Characters;

import com.badlogic.gdx.graphics.Texture;
import com.fblagamesimulationandprogramming.game.Main;

import Windows.InventoryScreen;

public class Item
{
	public Texture img;
	public int tradingValue;

	public Item(int tValue)
	{
		img = new Texture("assets/Items/Item" + tValue + ".png");
		tradingValue = tValue;
	}

	public Item()
	{
		// random img & trading value
		int val;
		if (InventoryScreen.highestVal == 37)
			val = Main.rand.nextInt(7) - 5 + InventoryScreen.highestVal;
		else if (InventoryScreen.highestVal > 5)
			val = Main.rand.nextInt(8) - 5 + InventoryScreen.highestVal;
		else if (InventoryScreen.highestVal == 1)
			val = InventoryScreen.highestVal + Main.rand.nextInt(2);
		else
			val = InventoryScreen.highestVal + Main.rand.nextInt(3) - 1;
		img = new Texture("assets/Items/Item" + val + ".png");
		tradingValue = val;
	}
}
