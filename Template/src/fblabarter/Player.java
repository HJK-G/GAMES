package Characters;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector3;
import com.fblagamesimulationandprogramming.game.Main;

import Windows.GameScreen;
// import Windows.GameScreen;
import Windows.InventoryScreen;

public class Player
{
	// imgs
	public static Texture[] img = new Texture[12];
	static int current = 0;
	static boolean walking = false; // walking gif
	static int walktimer = 0;

	public static Rectangle dimensions;
	public static int speed = 4;

	public static NPC closest;

	public Player()
	{
		// init imgs
		for (int i = 0; i < 12; i++)
			// img[i] = new Texture("assets/Player/Player" + i + ".png");
			img[i] = new Texture("assets/Player/Player/Player" + i + ".png");

		// dimension init
		dimensions = new Rectangle(Main.windowWidth / 2, Main.windowHeight / 2, Main.windowWidth / 20,
				Main.windowHeight / 10);
	}

	public static void draw(SpriteBatch batch)
	{
		batch.draw(img[current], dimensions.x, dimensions.y, dimensions.width, dimensions.height);

		update();
	}

	public static void update() // N=0-2,E=3-5,S=6-8,W=9-11
	{
		// pick up items
		for (int i = 0; i < GameScreen.groundItems.size(); i++)
		{
			Vector3 dim = GameScreen.groundItems.get(i);
			if (dimensions.x + dimensions.width / 2 > dim.x
					&& dimensions.x + dimensions.width / 2 < dim.x + Main.windowWidth / 64
					&& dimensions.y + dimensions.height / 2 > dim.y
					&& dimensions.y + dimensions.height / 2 < dim.y + Main.windowHeight / 64)
			{
				InventoryScreen.items.add(new Item((int) dim.z));
				GameScreen.groundItems.remove(i);
				i--;
				if (dim.z > InventoryScreen.highestVal)
					InventoryScreen.highestVal = (int) dim.z;
			}
		}

		if (Gdx.input.isKeyPressed(Keys.ANY_KEY)) // first#=still,second#=moving1,third#=moving2
		{
			int direction = 0;// moving direction
			if (closest != null && Gdx.input.isKeyPressed(Keys.ENTER))
			{
				closest.chat();
				Main.currentScreen = new InventoryScreen(1);
				Main.ingame = false;
				return;
			}
			// float scale = 2 * Main.windowWidth / Main.windowHeight;
			// if (Gdx.input.isKeyPressed(Keys.W))
			// {
			// dimensions.x += scale;
			// dimensions.y += 1;
			// direction = 1;
			// if (walktimer >= 100)
			// walktimer = 0;
			// }
			// else if (Gdx.input.isKeyPressed(Keys.S))
			// {
			// dimensions.x -= scale;
			// dimensions.y -= 1;
			// direction = 2;
			// if (walktimer >= 100)
			// walktimer = 0;
			// }
			// else if (Gdx.input.isKeyPressed(Keys.A))
			// {
			// dimensions.x -= scale;
			// dimensions.y += 1;
			// direction = 3;
			// if (walktimer >= 100)
			// walktimer = 0;
			// }
			// else if (Gdx.input.isKeyPressed(Keys.D))
			// {
			// dimensions.x += scale;
			// dimensions.y -= 1;
			// direction = 4;
			// if (walktimer >= 100)
			// walktimer = 0;
			// }
			if (Gdx.input.isKeyPressed(Keys.W))
			{
				dimensions.y += speed;
				direction = 1;
				if (walktimer >= 100)
					walktimer = 0;
			}
			else if (Gdx.input.isKeyPressed(Keys.S))
			{
				dimensions.y -= speed;
				direction = 2;
				if (walktimer >= 100)
					walktimer = 0;
			}
			else if (Gdx.input.isKeyPressed(Keys.A))
			{
				dimensions.x -= speed;
				direction = 3;
				if (walktimer >= 100)
					walktimer = 0;
			}
			else if (Gdx.input.isKeyPressed(Keys.D))
			{
				dimensions.x += speed;
				direction = 4;
				if (walktimer >= 100)
					walktimer = 0;
			}
			if (walktimer == 0)// walking gif & room switch
			{
				switch (direction)
				{// walking=moving1 !walking=moving2
					case 1:// N
						if (walking)
						{
							current = 1;
							walking = false;
						}
						else
						{
							current = 2;
							walking = true;
						}
						break;
					case 4:// E
						if (walking)
						{
							current = 4;
							walking = false;
						}
						else
						{
							current = 5;
							walking = true;
						}
						break;
					case 2:// S
						if (walking)
						{
							current = 10;
							walking = false;
						}
						else
						{
							current = 11;
							walking = true;
						}
						break;
					case 3:// W
						if (walking)
						{
							current = 7;
							walking = false;
						}
						else
						{
							current = 8;
							walking = true;
						}
						break;
					default:
						break;
				}
			}
			else
				walktimer++;
			switch (inRoom())
			{
				// case 4:
				// break;
				// case 0:
				// switchRoom(0);
				// break;
				// case 1:
				// switchRoom(0);
				// break;
				// case 2:
				// switchRoom(0);
				// break;
				// case 3:
				// switchRoom(0);
				// break;
				case 1:
					break;
				case 0:
					if (dimensions.x + dimensions.width > Main.windowWidth)
						dimensions.x = Main.windowWidth - dimensions.width;
					if (dimensions.x < 0)
						dimensions.x = 0;
					if (dimensions.y + dimensions.height > Main.windowHeight)
						dimensions.y = Main.windowHeight - dimensions.height;
					if (dimensions.y < 0)
						dimensions.y = 0;
					break;
			}
		}
		else
			switch (current % 3) // if not moving, switch to still in direction
			{
				case 1:
					current = current - 1;
					break;
				case 2:
					current = current - 2;
					break;
				default:
					break;
			}
	}

	public static boolean canTrade(Item trade)
	{// random unless less value
		return trade.tradingValue >= closest.trading.tradingValue || Main.rand.nextInt(3) < 1;
	}

	// public static void switchRoom(int dir)
	// {// up=0 down=2 left=3 right=1
	// if (GameScreen.location == 1 || GameScreen.location == 2)
	// return;
	// float scale = 2 * Main.windowWidth / Main.windowHeight;
	// float roomDimx = Main.windowWidth / 2;
	// float roomDimy = 6 * Main.windowHeight / 23;
	// if (dir == 0)
	// if (!(GameScreen.room <= 2))// not rooms 0,1,2
	// {
	// dimensions.x -= roomDimx;
	// dimensions.y -= roomDimy;
	// GameScreen.room -= 3;
	// }
	// else
	// {
	// dimensions.x -= scale;
	// dimensions.y -= 1;
	// return;
	// }
	// else if (dir == 1)
	// if (!((GameScreen.room + 1) % 3 == 0))
	// {
	// dimensions.x -= roomDimx;
	// dimensions.y += roomDimy;
	// GameScreen.room += 1;
	// }
	// else
	// {
	// dimensions.x -= scale;
	// dimensions.y += 1;
	// return;
	// }
	// else if (dir == 2)
	// if (!(GameScreen.room >= 6))
	// {
	// dimensions.x += roomDimx;
	// dimensions.y += roomDimy;
	// GameScreen.room += 3;
	// }
	// else
	// {
	// dimensions.x += scale;
	// dimensions.y += 1;
	// return;
	// }
	// else
	// {
	// if (!(GameScreen.room % 3 == 0))
	// {
	// dimensions.x += roomDimx;
	// dimensions.y -= roomDimy;
	// GameScreen.room -= 1;
	// }
	// else
	// {
	// dimensions.x += scale;
	// dimensions.y -= 1;
	// return;
	// }
	// }
	// }

	public static int inRoom()
	{
		// boolean outsideCircle = Math.pow(dimensions.x + dimensions.width / 2
		// - Main.windowWidth / 2, 2)
		// / Math.pow(Main.windowWidth / 2, 2)
		// + Math.pow(dimensions.y + dimensions.height / 2 - Main.windowHeight /
		// 2, 2)
		// / Math.pow(6 * Main.windowHeight / 23, 2) > 1;
		//
		// if (!outsideCircle)
		// return 4;
		// if (dimensions.x > Main.windowWidth / 2)
		// if (dimensions.y > Main.windowHeight / 2) // ur
		// return 0;
		// else // lr
		// return 1;
		// else
		// {
		// if (dimensions.y > Main.windowHeight / 2) // ul
		// return 3;
		// else // ll
		// return 2;
		// }

		if (dimensions.x + dimensions.width < Main.windowWidth && dimensions.x > 0
				&& dimensions.y + dimensions.height < Main.windowHeight && dimensions.y > 0)
			return 1;
		return 0;
	}
}
