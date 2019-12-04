

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

import Windows.TitleScreen;
import Windows.Window;

public class Main extends ApplicationAdapter
{
	SpriteBatch batch;

	public static Window currentScreen;
	public static int windowWidth;
	public static int windowHeight;

	 public static Music music;

	@Override
	public void create()
	{
		// initialize
		batch = new SpriteBatch();
		windowWidth = Gdx.graphics.getWidth();
		windowHeight = Gdx.graphics.getHeight();

		// music
		music = Gdx.audio.newMusic(Gdx.files.internal(""));
		music.play();
		music.setLooping(true);
		music.setVolume(1f);

		// title screen
		currentScreen = new TitleScreen();

	}

	@Override
	public void render()
	{
		Gdx.gl.glClearColor(1, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
		batch.begin();
		currentScreen.draw(batch);
		batch.end();
	}

	@Override
	public void dispose()
	{
		batch.dispose();
	}
}
