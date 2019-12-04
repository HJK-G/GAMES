package com.platform.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Array;

public class Moves
{
	protected Vector2 vel = new Vector2(0, 0);
	protected Rectangle bounds;
	protected Texture im;
	protected float gravity = 5f;
	protected boolean jumped = false;

	public void move(Array<Block> blocks)
	{
		boolean isTouching = false;
		for (Block b : blocks)
			if (bounds.overlaps(b.getBounds()))
				isTouching = true;

		if (jumped || !isTouching)
		{
			jumped = true;
			vel.y -= gravity;
			if (vel.y < 0)
				vel.y -= gravity;
		}

		for (Block b : blocks)
		{
			if (vel.y < 0 && (b.getBounds().contains(bounds.x, bounds.y)
					|| b.getBounds().contains(bounds.x + bounds.width / 2, bounds.y)
					|| b.getBounds().contains(bounds.x + bounds.width, bounds.y)))
			{
				jumped = false;
				vel.y = 0;
				bounds.y = b.getBounds().y + Block.SIZE;
			}

			if (bounds.overlaps(b.getBounds()) && vel.y > 0
					&& bounds.y + bounds.height <= b.getBounds().y + Block.SIZE * .25)
			{
				jumped = true;
				vel.y = 0;
			}
		}

		for (Block b : blocks)
		{
			if (vel.x > 0 && (b.getBounds().contains(bounds.x + bounds.width, bounds.y + bounds.height * .1f)
					|| b.getBounds().contains(bounds.x + bounds.width, bounds.y + bounds.height * .9f)))
			{
				vel.x = 0;
				bounds.x = b.getBounds().x - bounds.width - 1f;
			}

			if (vel.x < 0 && (b.getBounds().contains(bounds.x, bounds.y + bounds.height * .1f)
					|| b.getBounds().contains(bounds.x, bounds.y + bounds.height * .9f)))
			{
				vel.x = 0;
				bounds.x = b.getBounds().x + b.getBounds().width + 1f;
			}
		}

		vel.scl(Gdx.graphics.getDeltaTime());
		bounds.setPosition(bounds.getPosition(new Vector2()).add(vel));
		vel.scl(1 / Gdx.graphics.getDeltaTime());
	}
}
