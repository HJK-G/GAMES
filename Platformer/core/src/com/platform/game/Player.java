package com.platform.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.utils.Array;

public class Player extends Moves
{
	private float speedLimit = 60f;
	private float acceleration = 30f;
	private int score = 0;

	public Player()
	{
		im = new Texture("assets/Player.png");
		bounds = new Rectangle(200, 300, im.getWidth() / 5, im.getHeight() / 5);
	}

	public void update(Array<Block> blocks)
	{
		boolean applyFriction = true;
		if (Gdx.input.isKeyPressed(Keys.LEFT) && vel.x >= -speedLimit)
		{
			vel.add(-acceleration * Gdx.graphics.getDeltaTime(), 0);
			applyFriction = !applyFriction;
		}
		if (Gdx.input.isKeyPressed(Keys.RIGHT) && vel.x <= speedLimit)
		{
			vel.add(acceleration * Gdx.graphics.getDeltaTime(), 0);
			applyFriction = !applyFriction;
		}
		if (applyFriction)
			vel.x *= 1 - (.75f * Gdx.graphics.getDeltaTime());

		// jump
		if (Gdx.input.isKeyJustPressed(Keys.UP) && !jumped)
		{
			jumped = true;
			vel.y = 250f;
		}

		for (Block b : blocks)
			if (bounds.overlaps(b.getBounds()) && vel.y > 0
					&& bounds.y + bounds.height <= b.getBounds().y + Block.SIZE * .25)
			{
				jumped = true;
				vel.y = 0;
				b.dead();
			}

		move(blocks);
	}

	public void draw(SpriteBatch batch)
	{
		if (vel.x < 0)
			batch.draw(im, bounds.x, bounds.y, bounds.width, bounds.height, 0, 0, im.getWidth(), im.getHeight(), true,
					false);
		else
			batch.draw(im, bounds.x, bounds.y, bounds.width, bounds.height);
	}

	public void checkCollision(Array<Enemy> enemies, Array<Coin> coins)
	{
		for (Enemy e : enemies)
			if (!e.isDead() && jumped
					&& (e.bounds.contains(bounds.x, bounds.y)
							|| e.bounds.contains(bounds.x + bounds.width / 2, bounds.y)
							|| e.bounds.contains(bounds.x + bounds.width, bounds.y)))
			{
				e.dead();
				score += 5;
			}

		for (Coin c : coins)
			if (!c.isDead() && c.getBounds().overlaps(bounds))
			{
				c.dead();
				score += 15;
			}
	}

	// getter methods
	public int getScore()
	{
		return score;
	}
}
