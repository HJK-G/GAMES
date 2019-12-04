package Windows;

import java.util.ArrayList;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.fblagamesimulationandprogramming.game.Main;

import Characters.Item;
import Characters.Player;

public class InventoryScreen extends Window
{
	// inventory general
	public static ArrayList<Item> items = new ArrayList<Item>();
	public static int highestVal = 1;
	// public static int currPage = 0;

	// trading
	public static boolean isTrading = false;
	public static int row = 0;
	public static int col = 0;
	public static Texture highlight;

	// button
	public int lastkey = 0;

	public InventoryScreen()
	{
		background = new Texture("assets/InventoryBackground.png");
		isTrading = false;

		// no buttons
		buttons = null;
	}

	public InventoryScreen(int trading)
	{
		background = new Texture("assets/InventoryBackground.png");
		highlight = new Texture("assets/fakeimg5.png");

		isTrading = true;

		// buttons
		buttons = new Button[2];
		buttons[0] = new Button("CANCEL [BACKSPACE]", Main.windowWidth / 3, Main.windowHeight / 40,
				Main.windowWidth / 4, Main.windowHeight / 10); // cancel
		buttons[1] = new Button("ACCEPT [ENTER]", 2 * Main.windowWidth / 3, Main.windowHeight / 40,
				Main.windowWidth / 5, Main.windowHeight / 10); // accept
	}

	public void draw(SpriteBatch batch)
	{
		super.draw(batch);

		if (isTrading)
		{
			batch.draw(highlight, Main.windowWidth / 50 + col * 5 * Main.windowWidth / 51,
					Main.windowHeight / 5 + (4 - row) * 5 * Main.windowHeight / 31, Main.windowWidth / 13,
					Main.windowHeight / 9);
			batch.draw(Player.closest.trading.img, Main.windowWidth / 10, Main.windowHeight / 40, Main.windowWidth / 20,
					Main.windowHeight / 10);
			Main.gameFont.draw(batch, "Value: " + Player.closest.trading.tradingValue, 0, Main.windowHeight / 10);
			// on highlight value
			Main.gameFont.draw(batch,
					"Value: " + (items.size() > row * 10 + col ? items.get(row * 10 + col).tradingValue : 0),
					Main.windowWidth / 50 + col * 5 * Main.windowWidth / 51 + Main.windowWidth / 13,
					Main.windowHeight / 5 + (4 - row) * 5 * Main.windowHeight / 31 + Main.windowHeight / 9);
		}
		for (int i = 0; i < 5; i++)// rows
			for (int j = 0; j < 10 && items.size() > i * 10 + j; j++)// cols
				// batch.draw(items.get(currPage * 50 + i * 10 + j).img, i *
				// Main.windowWidth / 256 + 1,
				// Main.windowHeight - j * Main.windowHeight / 138 + 1,
				// (int) (Main.windowWidth / 172.5),
				// Main.windowHeight / 320);
				batch.draw(items.get(i * 10 + j).img, Main.windowWidth / 50 + j * 5 * Main.windowWidth / 51,
						Main.windowHeight / 5 + (4 - i) * 5 * Main.windowHeight / 31, Main.windowWidth / 13,
						Main.windowHeight / 9);
	}

	public void update()
	{
		super.update();

		if (Gdx.input.isKeyJustPressed(Keys.I))// close inventory
		{
			if (buttons != null)
				for (int i = 0; i < buttons.length; i++)
					buttons[i].dispose();
			Main.ingame = true;
			Main.currentScreen = null;
			Main.countdown = 1f;
		}
		// if (Gdx.input.isKeyPressed(Keys.DOWN))// scroll down
		// currPage--;
		// else if (Gdx.input.isKeyPressed(Keys.UP) && currPage > 0)// scroll up
		// currPage++;

		if (isTrading)	// selecting wasd
		{
			if (row > 0 && Gdx.input.isKeyJustPressed(Keys.W))
				row--;
			else if (row < 4 && Gdx.input.isKeyJustPressed(Keys.S))
				row++;
			else if (col > 0 && Gdx.input.isKeyJustPressed(Keys.A))
				col--;
			else if (col < 9 && Gdx.input.isKeyJustPressed(Keys.D))
				col++;
			if (Gdx.input.isKeyJustPressed(Keys.ENTER) && ((lastkey != 0 && lastkey != Keys.ENTER) || lastkey == 0))
				// if (Player.canTrade(items.get(currPage*100+row*10+col)))
				if (items.size() > 10 * row + col && Player.canTrade(items.get(row * 10 + col)))
				{
					for (int i = 0; i < buttons.length; i++)
						buttons[i].dispose();
					Main.ingame = true;
					Main.currentScreen = null;
					items.remove(row * 10 + col);
					items.add(Player.closest.trading);
					if (Player.closest.trading.tradingValue > highestVal)
					{
						highestVal = Player.closest.trading.tradingValue;
						GameScreen.highestLow = highestVal;
					}
					// System.out.println(highestVal);
					// if (GameScreen.school)
					// GameScreen.itemTradeCount++;
					// else
					// GameScreen.eventItemCount++;
					Main.countdown = 1f;
				}
				else
					Main.displayMessage("I don't want that!");
			else if (Gdx.input.isKeyJustPressed(Keys.BACKSPACE))
			{
				for (int i = 0; i < buttons.length; i++)
					buttons[i].dispose();
				Main.ingame = true;
				Main.currentScreen = null;
			}
		}
	}

	public void handleButton(Button currentButton)
	{
		if (buttons == null)
			return;
		if (currentButton.equals(buttons[0]))
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = null;
			Main.ingame = true;
		}
		else if (currentButton.equals(buttons[1]))
			// if (Player.canTrade(items.get(currPage*50+row*10+col)))
			if (items.size() > 10 * row + col && Player.canTrade(items.get(row * 10 + col)))
			{
				for (int i = 0; i < buttons.length; i++)
					buttons[i].dispose();
				Main.ingame = true;
				Main.currentScreen = null;
				items.remove(row * 10 + col);
				items.add(Player.closest.trading);
				if (Player.closest.trading.tradingValue > highestVal)
				{
					highestVal = Player.closest.trading.tradingValue;
					GameScreen.highestLow=highestVal;
				}
				// if (GameScreen.school)
				// GameScreen.itemTradeCount++;
				// else
				// GameScreen.eventItemCount++;
				Main.countdown = 1f;
			}
			else
				Main.displayMessage("I don't want that!");
	}
}
