package IRON_SNOUT;

import java.awt.Graphics2D;
import java.util.ArrayList;

public class EnemySpawner
{
	// enemies
	ArrayList<Enemy> enemies = new ArrayList<>();

	// spawn rate stuff
	private int defaultrate = 100;
	private int rate = defaultrate;
	private int counter = 0;
	private int scounter = 0;
	private int defaultspawnrate = 500;
	private int espawnrate = defaultspawnrate;

	public EnemySpawner()
	{
	}

	private void update(Player p1)
	{
		// get rid of dead enemies

		// spawn rates changing things
		scounter++;
		if (scounter >= espawnrate)
		{
			rate -= 5;
			scounter = 0;
		}
		if (rate < 30)
		{
			rate = 100;
			espawnrate -= 1;
		}

		// add new enemy after dies and counter is more than rate
		counter++;
		if (counter >= rate)
		{
			counter = 0;
			// enemy addition
			enemies.add(new Enemy((int) (Math.random() * Main.getScreenWidth()),
					(int) (Math.random() * 2) > 1 ? Main.getScreenHeight() - 100 : Main.getScreenHeight() - 200));
		}
	}

	public void draw(Graphics2D g, Player p1)
	{
		update(p1);

		// draw

	}

	public void reset()
	{
		rate = defaultrate;
		counter = 0;
		espawnrate = defaultspawnrate;
		scounter = 0;

		// remove enemies

	}

	// lots of get methods
	public ArrayList<Enemy> getEnemies()
	{
		return enemies;
	}

}
