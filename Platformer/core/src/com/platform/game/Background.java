package com.platform.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class Background
{
	// same for all
	private static Texture bg = new Texture("assets/background.gif");

	private float x = 0;
	private float scroll = .5f;

	public void update(float camPos)
	{
		// 1st background
		int width = Gdx.graphics.getWidth();
		x = scroll * camPos;
		while (x > camPos - width / 2)
			x -= bg.getWidth();
		while (x + bg.getWidth() * 2 < camPos + width / 2)
			x += bg.getWidth();
	}

	public void draw(SpriteBatch batch)
	{
		batch.setColor(Color.WHITE);
		batch.draw(bg, x, 0);
		batch.draw(bg, x + bg.getWidth(), 0);
	}
}
