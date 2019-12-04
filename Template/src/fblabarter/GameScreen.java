package Windows;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector3;
import com.fblagamesimulationandprogramming.game.Main;

import Characters.Item;
import Characters.NPC;
import Characters.Player;

public class GameScreen extends Window
{
	public static Player player;
	// public static int itemTradeCount;
	// public static int eventItemCount;
	public static NPC[] npcs = new NPC[5];
	public static int highestLow = 0;

	// random item spawning
	int countdown = 1000;
	public static ArrayList<Vector3> groundItems = new ArrayList<Vector3>();

	// animation
	boolean first = true;
	int number = 1;
	int timer = 0;

	// location
	// school,fundraising,community service,sectionals,state,nationals
	// public static Texture[][] rooms = new Texture[2][9];
	public static Texture room;
	public static boolean school = true;
	// public static int room = 4;

	public GameScreen()
	{
		// location
		// for (int i = 0; i < 9; i++)
		// rooms[0][i] = new Texture("assets/Room" + i + ".png");
		// rooms[1][4] = new Texture("assets/AltRoom.png");
		room = new Texture("assets/Room.png");

		// NPCS
		newNPCs();

		// item event count
		highestLow = InventoryScreen.highestVal;

		// buttons
		buttons = new Button[1];
		buttons[0] = new Button(0, Main.windowHeight - Main.windowHeight / 20, Main.windowWidth / 32,
				Main.windowHeight / 20, "assets/PauseButton.png"); // options

		new Player();
	}

	public void draw(SpriteBatch batch)
	{
		if (first)
		{
			batch.draw(new Texture("assets/Animation/Animation_" + number + ".png"), 0, 0, Main.windowWidth,
					Main.windowHeight);
			timer++;
			if (timer >= 100 || (timer >= 20 && Gdx.input.isKeyPressed(Keys.ENTER)))
			{
				number++;
				timer = 0;
			}

			if (number == 8)
				first = false;
			return;
		}

		// batch.draw(rooms[location==1||location==2?1:0][room],0,0,Main.windowWidth,Main.windowHeight);
		batch.draw(room, 0, 0, Main.windowWidth, Main.windowHeight);
		buttons[0].draw(batch);

		for (int i = 0; i < npcs.length; i++)
			npcs[i].draw(batch);

		// random item spawner
		if (countdown <= 0 && InventoryScreen.highestVal < 38)
		{
			groundItems.add(new Vector3(
					Main.rand.nextInt(Main.windowWidth - Main.windowWidth / 64 - Main.windowWidth / 40)
							+ Main.windowWidth / 40,
					Main.rand.nextInt(Main.windowHeight - Main.windowHeight / 35 - Main.windowHeight / 20)
							+ Main.windowHeight / 20,
					InventoryScreen.highestVal + 1));
			countdown = 1000 * InventoryScreen.highestVal;
			// System.out.println("AHIW");
		}
		countdown--;
		for (Vector3 pos : groundItems)
			batch.draw(new Texture("assets/Items/Item" + (int) pos.z + ".png"), pos.x, pos.y, Main.windowWidth / 64,
					Main.windowHeight / 35);

		Player.draw(batch);

		update();
	}

	public void update()
	{
		super.update();

		if (Gdx.input.isKeyJustPressed(Keys.ESCAPE))// open options
		{
			Main.ingame = false;
			Main.currentScreen = new PauseScreen();
		}
		else if (Gdx.input.isKeyJustPressed(Keys.I))// open inventory
		{
			Main.ingame = false;
			Main.currentScreen = new InventoryScreen();
		}

		// events
		// if (school)
		// if (itemTradeCount == 150)// nationals
		// school = false;
		// else if (itemTradeCount == 100)// sectionals
		// school = false;
		// else if (itemTradeCount == 50)// state
		// school = false;
		// else if (itemTradeCount % 20 == 0)
		// school = false;
		// else if (itemTradeCount % 10 == 0)
		// school = false;
		// if (eventItemCount > 15)
		// {
		// school = true;
		// itemTradeCount++;
		// eventItemCount = 0;
		// Main.displayMessage("CONGRATULATIONS, YOU MOVE ON!");
		// }

		// event begins
		if (school)
			switch (highestLow)
			{
				case 36:
				case 35:
					Main.displayMessage("Nationals Begins!");
					school = false;
					newNPCs();
					break;
				case 31:
				case 30:
					Main.displayMessage("State Begins!");
					school = false;
					newNPCs();
					break;
				case 26:
				case 25:
					Main.displayMessage("Sectionals Begins!");
					school = false;
					newNPCs();
					break;
				case 21:
				case 20:
					Main.displayMessage("Fundraising Begins!");
					school = false;
					newNPCs();
					break;
				case 16:
				case 15:
					Main.displayMessage("Community Service Begins!");
					school = false;
					newNPCs();
					break;
				case 11:
				case 10:
					Main.displayMessage("Fundraising Begins!");
					school = false;
					newNPCs();
					break;
				case 6:
				case 5:
					Main.displayMessage("Community Service Begins!");
					school = false;
					newNPCs();
					break;
			}
		if (!school)
			switch (highestLow)
			{

				case 38:
					Main.finish();
					break;
				case 33:
				case 32:
					Main.displayMessage("State Finished! You placed " + (Main.rand.nextInt(5) + 1) + "! Good Job!");
					school = true;
					newNPCs();
					break;
				case 28:
				case 27:
					Main.displayMessage(
							"Sectionals Finished! You placed " + (Main.rand.nextInt(6) + 1) + "! Good Job!");
					school = true;
					newNPCs();
					break;
				case 24:
				case 23:
					Main.displayMessage(
							"Fundraising Completed! You raised " + (Main.rand.nextInt(1000) + 500) + " dollars!");
					school = true;
					newNPCs();
					break;
				case 18:
				case 17:
					Main.displayMessage("Community Service Completed!");
					school = true;
					newNPCs();
					break;
				case 13:
				case 12:
					Main.displayMessage(
							"Fundraising Completed! You raised " + (Main.rand.nextInt(1000) + 500) + " dollars!");
					school = true;
					newNPCs();
					break;
				case 8:
				case 7:
					Main.displayMessage("Community Service Completed!");
					school = true;
					newNPCs();
					break;
			}

	}

	public static void newNPCs()
	{
		for (int i = 0; i < npcs.length; i++)
			npcs[i] = new NPC(Main.rand.nextInt(Main.windowWidth - Main.windowWidth / 30),
					Main.rand.nextInt(Main.windowHeight - Main.windowHeight / 10));
	}

	public void handleButton(Button currentButton)
	{
		// press options
		if (currentButton.equals(buttons[0]))
		{
			Main.ingame = false;
			save();
			Main.currentScreen = new PauseScreen();
		}
	}

	public void save()
	{
		try
		{
			Main.out = new PrintWriter(new BufferedWriter(new FileWriter("assets/inventory.txt")));
		}
		catch (IOException e)
		{
		}
		Main.out.println(InventoryScreen.items.size());
		for (Item a : InventoryScreen.items)
			Main.out.println(a.tradingValue);
	}

}
