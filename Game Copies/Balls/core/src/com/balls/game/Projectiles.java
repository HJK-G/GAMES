package com.balls.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Circle;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.utils.Array;

public class Projectiles
{
	public static Array<Projectiles> balls = new Array<Projectiles>();
	private static Texture ballim = new Texture("assets/Ballz.png");

	private Circle bounds;
	private float angle;
	private boolean moving;
	private float timer;

	public Projectiles(float x, float y)
	{
		bounds = new Circle(x, y, 5);
		timer = balls.size;
	}

	public static void update()
	{
		for (Projectiles ball : balls)
		{
			if (ball.moving)
			{
				ball.bounds.setPosition(ball.bounds.x + (float) Math.cos(ball.angle) * Gdx.graphics.getDeltaTime(),
						ball.bounds.y + (float) Math.sin(ball.angle) * Gdx.graphics.getDeltaTime());
				ball.angle = ball.angle >= 360 ? ball.angle - 360 : ball.angle;
			}
			else
			{
				ball.timer -= Gdx.graphics.getDeltaTime();
				if (ball.timer <= 0)
					ball.moving = true;
			}
		}
	}

	public static void draw(SpriteBatch batch)
	{
		for (Projectiles ball : balls)
			batch.draw(ballim, ball.bounds.x, ball.bounds.y);
	}

	public static void checkCollision(Array<Box> boxes)
	{
		for (Box b : boxes)
			for (Projectiles ba : balls)
				if (b.getBounds().contains(ba.bounds))
					bounce(ba, b);
	}

	private static void bounce(Projectiles ball, Box box)
	{
		Circle collBall = ball.bounds;
		Rectangle collBox = box.getBounds();

		// left right sides
		if (collBall.x < collBox.x + 2 || collBall.x > collBox.x - 2)
		{
			// up
			if (ball.angle < 180)
				ball.angle = 180 - ball.angle;

			// down
			if (ball.angle < 360)
				ball.angle = 540 - ball.angle;
		}

		// top bottom
		if (collBall.y < collBox.y + 2 || collBall.y > collBox.y - 2)
		{
			// bottom
			if (ball.angle < 180)
				ball.angle = 360 - ball.angle;

			// top
			if (ball.angle < 360)
				ball.angle = ball.angle - 180;
		}
	}

	public static void newLvl(float x)
	{
		for (Projectiles b : balls)
			b.bounds.setPosition(x, 10);
	}

	// lots of setter methods
	public void setAngle(float ang)
	{
		angle = ang;
	}

	public void startMove()
	{
		moving = true;
	}
}
