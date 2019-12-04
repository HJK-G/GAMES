package com.balls.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.TextureRegion;

public class Balls extends ApplicationAdapter
{
	SpriteBatch batch;

	TextureRegion shootLine;
	float x = Gdx.graphics.getWidth() / 2;
	float angle = 90;
	int level = 1;

	boolean start = false;

	@Override
	public void create()
	{
		batch = new SpriteBatch();
		shootLine = new TextureRegion();
		shootLine.setRegion(new Texture("assets/DottedLine.png"));
	}

	@Override
	public void render()
	{
		Gdx.gl.glClearColor(1, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
		// update
		Projectiles.update();
		if (!start)
			changeAngle();
		if (Gdx.input.isKeyJustPressed(Keys.SPACE))
			start = true;

		// draw
		batch.begin();
		Projectiles.draw(batch);
		Box.draw(batch);
		if (!start)
			batch.draw(shootLine, x, 10, 0, 0, shootLine.getRegionWidth(), shootLine.getRegionHeight(), 1, 15, angle);
		batch.end();
	}

	@Override
	public void dispose()
	{
		batch.dispose();
	}

	private void changeAngle()
	{
		if (Gdx.input.isKeyPressed(Keys.RIGHT) && angle < 180)
		{
			angle++;
			for (Projectiles b : Projectiles.balls)
				b.setAngle(angle);
		}
		else if (Gdx.input.isKeyPressed(Keys.LEFT) && angle > 0)
		{
			angle--;
			for (Projectiles b : Projectiles.balls)
				b.setAngle(angle);
		}
	}

	public void newLvl()
	{
		Projectiles.balls.add(new Projectiles(0, 0));
		Projectiles.newLvl(x);
		for(int i=0;i<j)
	}
}
