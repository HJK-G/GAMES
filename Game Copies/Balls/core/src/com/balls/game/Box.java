package com.balls.game;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.utils.Array;

public class Box
{
	public static Array<Box> boxes = new Array<Box>();
	private static Texture boxim = new Texture("assets/Box.png");

	private Rectangle bounds;

	public Box(float x, float y)
	{
		bounds = new Rectangle(x, y, 30, 30);
	}

	public static void draw(SpriteBatch batch)
	{
		for (Box b : boxes)
			batch.draw(boxim, b.bounds.x, b.bounds.y, 30, 30);
	}

	public void dead()
	{
		boxes.removeValue(this, true);
	}

	// getter methods
	public Rectangle getBounds()
	{
		return bounds;
	}
}
