package com.platform.game;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;

public class Coin
{
	// same for all
	private static final Texture im = new Texture("assets/Coin.png");

	// individual
	private boolean isDead = false;
	private Rectangle bounds = new Rectangle(0, 0, 50, 50);

	public Coin(Vector2 pos)
	{
		bounds.setPosition(pos);
	}

	public Coin(float x, float y)
	{
		bounds.setPosition(x, y);
	}

	public void update()
	{
		if (isDead)
			Platformer.coins.removeValue(this, true);
	}

	public void draw(SpriteBatch batch)
	{
		batch.draw(im, bounds.x, bounds.y, bounds.width, bounds.height);
	}

	// getter methods
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
