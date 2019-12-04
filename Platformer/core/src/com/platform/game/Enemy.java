package com.platform.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.utils.Array;

public class Enemy extends Moves
{
	enum GameState
	{
		LEFT, RIGHT
	};

	GameState state = GameState.LEFT;

	private float speed = 20f;
	private boolean isDead = false;
	private float walkFlipTimer = .75f;
	private boolean walkFlip = false;

	public Enemy(float x, float y)
	{
		im = new Texture("assets/Enemy.gif");
		bounds = new Rectangle(x, y, 50, 50);
		vel.x = -speed;
	}

	public void update(Array<Block> blocks)
	{
		if (isDead)
		{
			vel.y = -1;
			bounds.y += vel.y;
			return;
		}
		move(blocks);
		walkFlipTimer -= Gdx.graphics.getDeltaTime();

		switch (state)
		{
			case LEFT:
				if (vel.x == 0)
				{
					state = GameState.RIGHT;
					vel.x = speed;
				}
				break;
			case RIGHT:
				if (vel.x == 0)
				{
					state = GameState.LEFT;
					vel.x = -speed;
				}
		}
	}

	public void draw(SpriteBatch batch)
	{
		if (walkFlipTimer <= 0)
		{
			walkFlipTimer = .75f;
			walkFlip = !walkFlip;
		}
		batch.draw(im, bounds.x, bounds.y, bounds.width, bounds.height, 0, 0, im.getWidth(), im.getHeight(), walkFlip,
				isDead);
	}

	// setter methods
	public void dead()
	{
		isDead = true;
	}

	// getter methods
	public boolean isDead()
	{
		return isDead;
	}
}
