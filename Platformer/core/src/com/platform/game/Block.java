package com.platform.game;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;

public class Block
{
	private static Texture im = new Texture("assets/block.png-c200");
	private Rectangle bounds = new Rectangle();
	public static final int SIZE = 60;

	private boolean isDead = false;

	public Block(int x, int y)
	{
		bounds.setPosition(x, y);
		bounds.setSize(SIZE, SIZE);
	}

	public void draw(SpriteBatch batch)
	{
		if (isDead)
		{
			Platformer.coins.add(new Coin(bounds.getCenter(new Vector2())));
			Platformer.blocks.removeValue(this, true);
		}
		else
			batch.draw(im, bounds.x, bounds.y, bounds.width, bounds.height);
	}

	// lots of get methods
	public Rectangle getBounds()
	{
		return bounds;
	}

	public boolean isDead()
	{
		return isDead;
	}

	// setter methods
	public void dead()
	{
		isDead = true;
	}
}
