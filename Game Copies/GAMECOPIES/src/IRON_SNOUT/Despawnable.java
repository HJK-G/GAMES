package IRON_SNOUT;

import java.awt.Rectangle;

public class Despawnable
{
	private Rectangle collisionRect;

	private boolean isDead = false;

	// lots of get methods
	public Rectangle getCollRect()
	{
		return collisionRect;
	}

	public boolean isDead()
	{
		return isDead;
	}

	// lots of set methods
	public void dead()
	{
		isDead = true;
	}

	public void setCollRect(Rectangle collRect)
	{
		collisionRect = collRect;
	}

	public void moveCollRect(int x, int y)
	{
		collisionRect.setLocation(x, y);
	}
}
