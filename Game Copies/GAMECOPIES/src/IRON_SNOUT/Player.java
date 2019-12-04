package IRON_SNOUT;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Rectangle;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Player implements KeyListener
{
	// pig
	private int timer = 0;// jumping
	private int width = 100;
	private int defaultHeight = 100;
	private int height = defaultHeight;
	private Rectangle collisionRect; // also pig

	// coors
	private int x = Main.getScreenWidth() / 2 - width / 2;
	private int defaultY = Main.getScreenHeight() - 150;
	private int y = defaultY;

	private Color pink = new Color(255, 103, 166);

	// fighting
	private boolean[] fightDir =
			{ false, false, false, false };
	private boolean[] dir =
			{ true, true, true, true };

	// health
	private int defaultHealth = 10;
	private int health = defaultHealth;

	public Player()
	{
		collisionRect = new Rectangle(x, y, width, height);
	}

	private void update()
	{
		if (timer > 0)
			timer--;

		if (timer <= 0)
		{
			timer = 0;
			dir[0] = true;
			fightDir[0] = false;
			if (dir[2])
				y = defaultY;
		}

		collisionRect.setLocation(x, y);
		collisionRect.setSize(width, height);
	}

	public void draw(Graphics2D g)
	{
		update();

		// draw
		g.setColor(pink);
		g.fill(collisionRect);
	}

	public void reset()
	{
		health = defaultHealth;
		y = defaultY;
		height = defaultHeight;
		timer = 0;
	}

	// key listener
	@Override
	public void keyTyped(KeyEvent e)
	{

	}

	@Override
	public void keyPressed(KeyEvent e)
	{
		if (e.getKeyCode() == KeyEvent.VK_UP && dir[0] && dir[2])
		{
			fightDir[0] = true;
			dir[0] = false;
			y = y - height * 2;
			timer = 200;
		}
		if (e.getKeyCode() == KeyEvent.VK_DOWN && dir[2] && dir[0])
		{
			fightDir[2] = true;
			dir[2] = false;
			height = height / 2;
			y += height;
		}
		if (e.getKeyCode() == KeyEvent.VK_RIGHT && dir[1])
		{
			fightDir[1] = true;
			dir[1] = false;
		}
		if (e.getKeyCode() == KeyEvent.VK_LEFT && dir[3])
		{
			fightDir[3] = true;
			dir[3] = false;
		}
	}

	@Override
	public void keyReleased(KeyEvent e)
	{
		if (e.getKeyCode() == KeyEvent.VK_RIGHT)
		{
			dir[1] = true;
			fightDir[1] = false;
		}
		if (e.getKeyCode() == KeyEvent.VK_DOWN)
		{
			fightDir[2] = false;
			height = defaultHeight;
			dir[2] = true;
		}
		if (e.getKeyCode() == KeyEvent.VK_LEFT)
		{
			dir[3] = true;
			fightDir[3] = false;
		}
	}

	// lots of get methods
	public Rectangle getCollRect()
	{
		return collisionRect;
	}

	public int getHealth()
	{
		return health;
	}

	// lots of set methods
	public void lowerHealth()
	{
		health--;
	}
}
