package IRON_SNOUT;

import java.awt.Graphics2D;
import java.awt.Rectangle;

public class Enemy extends Despawnable
{
	// enemy stuff
	private float velx = 1;
	private float x;
	private float y;
	private int width = 50;
	private int height = 50;

	public Enemy(int x, int y)
	{
		setCollRect(new Rectangle(x, y, width, height));
	}

	public void draw(Graphics2D g)
	{
		// update
		if (isDead())
			return;
		x += velx;
		moveCollRect((int) x, (int) y);
		if (x < 0 || x > Main.getScreenWidth())
			dead();

		// draw
		g.fill(getCollRect());
	}

	public void checkCollide(Player p1)
	{
		if (getCollRect().intersects(p1.getCollRect()))
		{
			p1.lowerHealth();
			dead();
		}
	}
}
