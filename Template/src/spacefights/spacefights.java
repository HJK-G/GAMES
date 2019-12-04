package spacefights;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator.FreeTypeFontParameter;

public class spacefights extends ApplicationAdapter
{
	SpriteBatch batch;

	BitmapFont gameFont;

	// states
	enum GameState
	{
		PAUSED, PLAYING, SHOP
	}

	static GameState state = GameState.PAUSED;
	static float cooldown = 0;

	// game objects
	Player p1;
	EnemySpawner enemies;
	Background bg;

	// shop
	Shop shop;
	Button shopButton;
	Button backArrow;

	// reset
	boolean once = true;

	// music
	Music bgmusic;

	@Override
	public void create()
	{
		batch = new SpriteBatch();

		// music
		bgmusic = Gdx.audio.newMusic(Gdx.files.internal("assets/ObservingTheStar.ogg"));
		bgmusic.play();
		bgmusic.setLooping(true);
		bgmusic.setVolume(1f);

		// font (showing strings)
		FreeTypeFontGenerator generator = new FreeTypeFontGenerator(
				Gdx.files.internal("assets/good-times/good times rg.ttf"));
		FreeTypeFontParameter p = new FreeTypeFontParameter();
		p.size = 20;
		gameFont = generator.generateFont(p);
		generator.dispose();

		// game objects initialize
		p1 = new Player(Gdx.graphics.getWidth() / 2, 100);
		enemies = new EnemySpawner();
		bg = new Background();

		// shop
		shop = new Shop();
		shopButton = new Button(Gdx.graphics.getWidth() / 2 - 40, 200, 80, 40);
		backArrow = new Button(20, 20, 30, 30, new Texture("assets/backArrow.png"));
	}

	@Override
	public void render()
	{
		Gdx.gl.glClearColor(0, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

		cooldown -= Gdx.graphics.getDeltaTime();

		bg.update();
		// shop.update();

		switch (state)
		{
			case PLAYING:
				if (!once)
					once = true;
				// update
				p1.update();
				enemies.update();
				for (PowerUp pow : PowerUp.getPowerUps())
					pow.update();
				if (Gdx.input.isKeyPressed(Keys.SPACE) && cooldown <= 0)
				{
					state = GameState.PAUSED;
					once = false;
					cooldown = .75f;
				}

				// check collisions
				p1.checkCollision(enemies.getEnemies());

				// draw
				batch.begin();

				bg.draw(batch);
				p1.draw(batch);
				enemies.draw(batch);
				for (PowerUp pow : PowerUp.getPowerUps())
				{
					batch.setColor(Color.WHITE);
					pow.draw(batch);
				}
				gameFont.draw(batch, "Health: " + p1.health, 10, Gdx.graphics.getHeight() - 25);
				gameFont.draw(batch, "Score: " + p1.getScore(), 10, Gdx.graphics.getHeight() - 50);
				gameFont.draw(batch, "Bullets left: " + p1.getBullets(), Gdx.graphics.getWidth() - 350,
						Gdx.graphics.getHeight() - 25);

				batch.end();
				break;

			case PAUSED:
				if (once)
				{
					reset();
					once = false;
				}

				shopButton.update();
				if (shopButton.isPressed)
					state = GameState.SHOP;
				if (Gdx.input.isKeyPressed(Keys.SPACE) && cooldown <= 0)
				{
					state = GameState.PLAYING;
					cooldown = .5f;
				}

				batch.begin();

				bg.draw(batch);
				batch.setColor(Color.ORANGE);
				gameFont.draw(batch, "PRESS SPACE TO PLAY", Gdx.graphics.getWidth() / 2 - 150, 350);
				shopButton.draw(batch);

				batch.end();
				break;

			case SHOP:
				shop.update(p1);
				backArrow.update();
				if (backArrow.isPressed)
					state = GameState.PAUSED;

				batch.begin();

				shop.draw(batch, gameFont);
				gameFont.draw(batch, "Health: " + p1.health, 10, Gdx.graphics.getHeight() - 25);
				gameFont.draw(batch, "Score: " + p1.getScore(), 10, Gdx.graphics.getHeight() - 50);
				gameFont.draw(batch, "Bullets left: " + p1.getBullets(), Gdx.graphics.getWidth() - 350,
						Gdx.graphics.getHeight() - 25);
				backArrow.draw(batch);

				batch.end();
				break;
		}
	}

	@Override
	public void dispose()
	{
		batch.dispose();
		enemies.explode.dispose();
		enemies.explosion.dispose();
		bgmusic.dispose();
	}

	public void reset()
	{
		p1.reset();
		enemies.reset();
		PowerUp.reset();
	}
}
