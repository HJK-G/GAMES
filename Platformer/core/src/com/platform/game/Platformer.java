package com.platform.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator.FreeTypeFontParameter;
import com.badlogic.gdx.utils.Array;

public class Platformer extends ApplicationAdapter
{
	// looks
	SpriteBatch batch;
	OrthographicCamera camera;
	int camerabounds = 100;
	Background bg;
	BitmapFont gameFont;

	// game objects
	static Player p1;
	static Array<Block> blocks;
	static Array<Enemy> enemies;
	static Array<Coin> coins;

	@Override
	public void create()
	{
		// looks
		batch = new SpriteBatch();
		camera = new OrthographicCamera(Gdx.graphics.getWidth(), Gdx.graphics.getHeight());
		camera.position.set(Gdx.graphics.getWidth() / 2, Gdx.graphics.getHeight() / 2, 0);
		camera.update();
		bg = new Background();
		// font (showing strings)
		FreeTypeFontGenerator generator = new FreeTypeFontGenerator(
				Gdx.files.internal("assets/good-times/good times rg.ttf"));
		FreeTypeFontParameter p = new FreeTypeFontParameter();
		p.size = 20;
		gameFont = generator.generateFont(p);
		generator.dispose();

		// game objects
		p1 = new Player();
		blocks = new Array<Block>();
		enemies = new Array<Enemy>();
		coins = new Array<Coin>();

		// first blocks
		for (int i = 0; i < Gdx.graphics.getWidth() * 3; i += Block.SIZE)
			blocks.add(new Block(i, 0));
		for (int i = 0; i < Gdx.graphics.getHeight(); i += Block.SIZE)
			blocks.add(new Block(-Block.SIZE, i));
		blocks.add(new Block(200, 200));
		blocks.add(new Block(0, 60));
		blocks.add(new Block(Gdx.graphics.getWidth() - 60, 60));

		// coins
		coins.add(new Coin(250, 250));

		// enemies
		enemies.add(new Enemy(300, 200));
	}

	@Override
	public void render()
	{
		Gdx.gl.glClearColor(0, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

		// update
		p1.update(blocks);
		p1.checkCollision(enemies, coins);
		for (Enemy e : enemies)
			if (!(e.bounds.x < camera.position.x - Gdx.graphics.getWidth()
					|| e.bounds.x > camera.position.x + Gdx.graphics.getWidth()))
				e.update(blocks);
		if (p1.bounds.x > camerabounds + camera.position.x)// right
			camera.position.x = p1.bounds.x - camerabounds;
		if (p1.bounds.x < camera.position.x - camerabounds && camera.position.x - Gdx.graphics.getWidth() / 2 > 0)// left
			camera.position.x = p1.bounds.x + camerabounds;
		camera.update();
		bg.update(camera.position.x);
		for (Coin c : coins)
			c.update();

		// draw
		batch.setProjectionMatrix(camera.combined);
		batch.begin();
		bg.draw(batch);
		p1.draw(batch);
		for (Block b : blocks)
			b.draw(batch);
		for (Enemy e : enemies)
			e.draw(batch);
		for (Coin c : coins)
			c.draw(batch);
		gameFont.draw(batch, "Score: " + p1.getScore(), 10 + camera.position.x - Gdx.graphics.getWidth() / 2,
				Gdx.graphics.getHeight());
		batch.end();
	}

	@Override
	public void dispose()
	{
		batch.dispose();
	}
}
