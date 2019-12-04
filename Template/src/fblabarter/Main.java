package com.fblagamesimulationandprogramming.game;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;
import java.util.StringTokenizer;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.GlyphLayout;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator.FreeTypeFontParameter;

import Characters.Item;
import Windows.GameScreen;
import Windows.InventoryScreen;
import Windows.TitleScreen;
import Windows.Window;

public class Main extends ApplicationAdapter
{
	static SpriteBatch batch;

	// text
	public static BitmapFont gameFont;
	static Texture rectangleScreen;
	static String message;
	static boolean msg = false;

	// game over
	public static boolean gameOver = false;

	// screen stuff
	public static Window currentScreen;
	public static int windowWidth;
	public static int windowHeight;
	public static float countdown = 0;
	public static GameScreen game;
	public static boolean ingame = false;

	public static Music music;

	// saving
	public static PrintWriter out;

	// rng
	public static Random rand;

	// test
	// public static Texture hL;

	@Override
	public void create()
	{
		// initialize screen stuff
		windowWidth = Gdx.graphics.getWidth();
		windowHeight = Gdx.graphics.getHeight();
		batch = new SpriteBatch();
		Gdx.graphics.setResizable(false);
		rectangleScreen = new Texture("assets/Rectangle.jpg");

		// rng
		rand = new Random();

		// music
		music = Gdx.audio.newMusic(Gdx.files.internal("assets/BGMusic.mp3"));
		music.setLooping(true);
		music.setVolume(.5f);
		music.play();

		// font (showing strings)
		FreeTypeFontGenerator generator = new FreeTypeFontGenerator(
				Gdx.files.internal("assets/good-times/good times rg.ttf"));
		FreeTypeFontParameter p = new FreeTypeFontParameter();
		p.size = 20;
		gameFont = generator.generateFont(p);
		generator.dispose();

		// title screen
		currentScreen = new TitleScreen();

		// test
		// hL = new Texture("assets/GridLineHorizontal.png");

		// saving
		try
		{
			BufferedReader f = new BufferedReader(new FileReader("assets/inventory.txt"));
			if (!f.ready())
			{
				out = new PrintWriter(new BufferedWriter(new FileWriter("assets/inventory.txt")));
				out.println(1);
				out.println(1);
				InventoryScreen.items.add(new Item(1));
				out.close();
				f.close();
				return;
			}
			StringTokenizer st = new StringTokenizer(f.readLine());

			int lines = Integer.parseInt(st.nextToken());
			for (int i = 0; i < lines; i++)
			{
				st = new StringTokenizer(f.readLine());
				int tVal = Integer.parseInt(st.nextToken());
				InventoryScreen.items.add(new Item(tVal));
				if (tVal > InventoryScreen.highestVal)
					InventoryScreen.highestVal = tVal;
			}

			f.close();
			out = new PrintWriter(new BufferedWriter(new FileWriter("assets/inventory.txt")));
		}
		catch (IOException e)
		{
			System.out.println("SAVE FILE CORRUPTED");
		}

	}

	@Override
	public void render()
	{
		// game finished
		if (gameOver)
		{
			Gdx.gl.glClearColor(1, 0, 0, 1);
			Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
			batch.begin();
			batch.draw(rectangleScreen, 0, 0, windowWidth, windowHeight);
			batch.end();
			if (countdown <= 0)
				rectangleScreen = new Texture("assets/Credits.png");
			else
				countdown -= .05f;
			return;
		}

		// dont accidentally press the button twice
		if (countdown >= 0)
		{
			countdown -= .05f;
			if (message != null)
			{
				if (Gdx.input.isKeyJustPressed(Keys.ENTER))
				{
					message = null;
					countdown = .5f;
					return;
				}
				Gdx.gl.glClearColor(1, 0, 0, 1);
				Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
				batch.begin();
				displayMessage(message);
				batch.end();
			}
			return;
		}

		// draw screen
		Gdx.gl.glClearColor(1, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
		batch.begin();
		if (ingame)
			game.draw(batch);
		else
			currentScreen.draw(batch);
		// for (int i = 10; i < windowHeight - 10; i += 10)
		// {
		// batch.draw(hL, 0, i, windowWidth, 1);
		// gameFont.draw(batch, "" + i, 0, i);
		// }
		batch.end();
	}

	public static void displayMessage(String message)
	{
		batch.draw(rectangleScreen, 0, 0, windowWidth, windowHeight);
		// text for button
		GlyphLayout layout = new GlyphLayout(Main.gameFont, message);
		Main.gameFont.draw(batch, layout, (windowWidth - layout.width) / 2, (windowHeight + layout.height) / 2);
		Main.message = message;
		countdown = 1f;
	}

	public static void finish()
	{
		rectangleScreen = new Texture("assets/NationalRecognition.png");
		gameOver = true;
		countdown = 10f;
	}

	@Override
	public void dispose()
	{
		batch.dispose();
		music.dispose();
		if (currentScreen != null)
			currentScreen.dispose();

		out.close();
	}
}
