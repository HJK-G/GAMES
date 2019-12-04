package com.sudoku.game;

import java.util.Random;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.GlyphLayout;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator.FreeTypeFontParameter;

public class Main extends ApplicationAdapter
{
	SpriteBatch batch;

	// preset board
	public static int[][] valid =
		{
				{ 0, 5, 4, 3, 0, 0, 7, 9, 0 },
				{ 6, 0, 0, 1, 9, 0, 5, 0, 0 },
				{ 9, 0, 0, 0, 5, 8, 0, 0, 2 },
				{ 0, 6, 1, 0, 0, 0, 0, 0, 0 },
				{ 0, 3, 0, 0, 0, 0, 0, 4, 0 },
				{ 0, 0, 0, 0, 0, 0, 1, 2, 0 },
				{ 3, 0, 0, 9, 1, 0, 0, 0, 5 },
				{ 0, 0, 6, 0, 4, 7, 0, 0, 3 },
				{ 0, 8, 9, 0, 0, 5, 6, 7, 0 } };

	public static int[][] solution =
		{
				{ 8, 5, 4, 3, 6, 2, 7, 9, 1 },
				{ 6, 7, 2, 1, 9, 4, 5, 3, 8 },
				{ 9, 1, 3, 7, 5, 8, 4, 6, 2 },
				{ 2, 6, 1, 4, 8, 9, 3, 5, 7 },
				{ 7, 3, 5, 6, 2, 1, 8, 4, 9 },
				{ 4, 9, 8, 5, 7, 3, 1, 2, 6 },
				{ 3, 4, 7, 9, 1, 6, 2, 8, 5 },
				{ 5, 2, 6, 8, 4, 7, 9, 1, 3 },
				{ 1, 8, 9, 2, 3, 5, 6, 7, 4 } };

	public static int[][] curr;

	int incorrect = 49;

	public static long starttime;

	public static BitmapFont text;
	public static BitmapFont numbers;

	int window = 0;
	// title=0 game=1 win=2

	int width;
	int height;

	// imgs
	Texture hl;
	Texture vl;
	Texture button;
	Texture cursor;

	int[] time = new int[4];

	@Override
	public void create()
	{
		// drawing
		batch = new SpriteBatch();

		// text
		FreeTypeFontGenerator generator = new FreeTypeFontGenerator(Gdx.files.internal("assets/brigadom.ttf"));
		FreeTypeFontParameter p = new FreeTypeFontParameter();
		p.color = Color.BLACK;
		p.size = 100;
		text = generator.generateFont(p);
		p.color = Color.BLACK;
		p.size = 50;
		numbers = generator.generateFont(p);

		// textures
		hl = new Texture("assets/hl.png");
		vl = new Texture("assets/vl.png");
		button = new Texture("assets/button.png");
		cursor = new Texture("assets/cursor.png");

		// dimension
		width = Gdx.graphics.getWidth();
		height = Gdx.graphics.getHeight();
	}

	@Override
	public void render()
	{
		// clear screen
		Gdx.gl.glClearColor(1, 1, 1, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

		// update and draw
		width = Gdx.graphics.getWidth();
		height = Gdx.graphics.getHeight();
		switch (window)
		{
			case 0:
			{
				batch.begin();

				GlyphLayout layout = new GlyphLayout(text, "Sudoku");
				text.draw(batch, layout, width / 2 - layout.width / 2, height * 9 / 10 + layout.height / 2);

				batch.draw(button, width / 3, height / 2, width / 3, height / 6);
				layout = new GlyphLayout(text, "Start");
				text.draw(batch, layout, width / 2 - layout.width / 2, height * 7 / 12 + layout.height / 2);

				batch.draw(button, width / 3, height / 6, width / 3, height / 6);
				layout = new GlyphLayout(text, "Quit");
				text.draw(batch, layout, width / 2 - layout.width / 2, height / 4 + layout.height / 2);

				batch.end();

				int mouseX = Gdx.input.getX(), mouseY = height - Gdx.input.getY();
				if (Gdx.input.isTouched() && mouseX >= width / 3 && mouseX < width * 2 / 3 && mouseY >= height / 2
						&& mouseY <= height * 2 / 3)
				{
					// make new sudoku board
					createSudoku();
					curr = new int[9][9];
					for (int i = 0; i < 9; i++)
						for (int j = 0; j < 9; j++)
							curr[i][j] = valid[i][j];
					window = 1;
					starttime = System.nanoTime();
				}
				else if (Gdx.input.isTouched() && mouseX >= width / 3 && mouseX < width * 2 / 3 && mouseY >= height / 6
						&& mouseY <= height / 3)
					Gdx.app.exit();
				break;
			}

			case 1:
			{
				long elapsed = (System.nanoTime() - starttime) / 1000000;
				time[0] = (int) (elapsed / 3600000);
				time[1] = (int) ((elapsed / 60000) - time[0] * 60);
				time[2] = (int) ((elapsed / 1000) - time[0] * 3600 - time[1] * 60);
				time[3] = (int) (elapsed - time[0] * 3600000 - time[1] * 60000 - time[2] * 1000);

				int mouseX = Gdx.input.getX();
				int mouseY = height - Gdx.input.getY();
				float sql = height / 10;

				batch.begin();

				text.draw(batch, " " + time[0] + ":" + time[1] + ":" + time[2] + "." + time[3], 0, height / 2);
				text.draw(batch, " Incorrect: " + incorrect, 0, height / 3);

				if (mouseX >= width - height && mouseX <= width && mouseY >= 0 && mouseY <= height)
				{
					int c = (int) ((mouseX - (width - height) - sql / 16) / (height / 9));
					int r = (int) ((mouseY) / (height / 9));
					if (r >= 0 && r < 9 && c >= 0 && c < 9)
					{
						batch.draw(cursor, width - height + ((height - sql * 5 / 8) / 9 + sql / 16) * c,
								((height - sql * 5 / 8) / 9 + sql / 16) * r, height / 9, height / 9);
						checkInput(c, 8 - r);
					}
				}

				batch.draw(vl, width - height, 0, sql / 8, height);
				batch.draw(hl, width - height, height - sql / 8, height, sql / 8);
				batch.draw(vl, width - sql / 8, 0, sql / 8, height);
				batch.draw(hl, width - height, 0, height, sql / 8);
				for (int i = 1; i < 3; i++)
				{
					batch.draw(vl, width - height + height * i / 3, 0, sql / 8, height);
					batch.draw(hl, width - height, height * i / 3, height, sql / 8);
				}
				for (int i = 1; i < 10; i++)
				{
					batch.draw(vl, width - height + height * i / 9, 0, sql / 16, height);
					batch.draw(hl, width - height, height * i / 9, height, sql / 16);
				}

				for (int i = 0; i < 9; i++)
					for (int j = 0; j < 9; j++)
						if (curr[i][j] != 0)
							numbers.draw(batch, "" + curr[i][j],
									width - height + ((height - sql * 5 / 8) / 9 + sql / 16) * i + sql / 4,
									height - ((height - sql * 5 / 8) / 9 + sql / 16) * j - sql / 8);

				batch.end();

				if (incorrect == 0)
					window = 2;
				break;
			}

			case 2:
			{
				batch.begin();

				GlyphLayout layout = new GlyphLayout(text, "You Win!");
				text.draw(batch, layout, width / 2 - layout.width / 2, height * 15 / 16 + layout.height / 2);
				layout = new GlyphLayout(text,
						"Your time was " + time[0] + ":" + time[1] + ":" + time[2] + "." + time[3]);
				text.draw(batch, layout, width / 2 - layout.width / 2, height * 3 / 4 + layout.height / 2);

				batch.draw(button, width / 3, height / 2, width / 3, height / 6);
				layout = new GlyphLayout(text, "New Game");
				text.draw(batch, layout, width / 2 - layout.width / 2, height * 7 / 12 + layout.height / 2);

				batch.draw(button, width / 3, height / 6, width / 3, height / 6);
				layout = new GlyphLayout(text, "Quit");
				text.draw(batch, layout, width / 2 - layout.width / 2, height / 4 + layout.height / 2);

				batch.end();

				int mouseX = Gdx.input.getX();
				int mouseY = height - Gdx.input.getY();
				if (Gdx.input.isTouched() && mouseX >= width / 3 && mouseX < width * 2 / 3 && mouseY >= height / 2
						&& mouseY <= height * 2 / 3)
				{
					// make new sudoku board
					createSudoku();
					curr = new int[9][9];
					for (int i = 0; i < 9; i++)
						for (int j = 0; j < 9; j++)
							curr[i][j] = valid[i][j];
					time = new int[3];
					window = 1;
					starttime = System.nanoTime();
					
				}
				else if (Gdx.input.isTouched() && mouseX >= width / 3 && mouseX < width * 2 / 3 && mouseY >= height / 6
						&& mouseY <= height / 3)
					Gdx.app.exit();
				break;
			}
		}
	}

	public void checkInput(int r, int c)
	{
		if (valid[r][c] == 0 && Gdx.input.isKeyPressed(Keys.ANY_KEY))
		{
			int num = 0;
			if (Gdx.input.isKeyPressed(Keys.NUM_1))
				num = 1;
			else if (Gdx.input.isKeyPressed(Keys.NUM_2))
				num = 2;
			else if (Gdx.input.isKeyPressed(Keys.NUM_3))
				num = 3;
			else if (Gdx.input.isKeyPressed(Keys.NUM_4))
				num = 4;
			else if (Gdx.input.isKeyPressed(Keys.NUM_5))
				num = 5;
			else if (Gdx.input.isKeyPressed(Keys.NUM_6))
				num = 6;
			else if (Gdx.input.isKeyPressed(Keys.NUM_7))
				num = 7;
			else if (Gdx.input.isKeyPressed(Keys.NUM_8))
				num = 8;
			else if (Gdx.input.isKeyPressed(Keys.NUM_9))
				num = 9;

			if (num == 0)
				return;
			if (curr[r][c] == num)
				return;
			if (solution[r][c] == num)
				incorrect--;
			if (curr[r][c] == solution[r][c])
				incorrect++;
			curr[r][c] = num;
		}
	}

	public static void createSudoku()
	{
		Random rand = new Random();
		int times = rand.nextInt(100);
		for (int i = 0; i < times; i++)
			switch (rand.nextInt(5))
			{
				case 0:
					swapNums(rand.nextInt(9) + 1, rand.nextInt(9) + 1);
					break;
				case 1:
					int lcol = rand.nextInt(3) * 3;
					swapSmallCols(lcol + rand.nextInt(3), lcol + rand.nextInt(3));
					break;
				case 2:
					int lrow = rand.nextInt(3) * 3;
					swapSmallRows(lrow + rand.nextInt(3), lrow + rand.nextInt(3));
					break;
				case 3:
					swapLargeCols(rand.nextInt(3), rand.nextInt(3));
					break;
				case 4:
					swapLargeRows(rand.nextInt(3), rand.nextInt(3));
					break;
			}
	}

	public static void swapNums(int a, int b)
	{
		for (int i = 0; i < 9; i++)
			for (int j = 0; j < 9; j++)
			{
				if (valid[i][j] == a)
					valid[i][j] = b;
				else if (valid[i][j] == b)
					valid[i][j] = a;

				if (solution[i][j] == a)
					solution[i][j] = b;
				else if (solution[i][j] == b)
					solution[i][j] = a;
			}
	}

	public static void swapSmallCols(int c1, int c2)
	{
		for (int i = 0; i < 9; i++)
		{
			int temp = valid[i][c1];
			valid[i][c1] = valid[i][c2];
			valid[i][c2] = temp;

			temp = solution[i][c1];
			solution[i][c1] = solution[i][c2];
			solution[i][c2] = temp;
		}
	}

	public static void swapSmallRows(int r1, int r2)
	{
		int[] temp = valid[r1];
		valid[r1] = valid[r2];
		valid[r2] = temp;

		temp = solution[r1];
		solution[r1] = solution[r2];
		solution[r2] = temp;
	}

	public static void swapLargeCols(int c1, int c2)
	{
		for (int i = 0; i < 9; i++)
			for (int j = 0; j < 3; j++)
			{
				int temp = valid[i][c1 * 3 + j];
				valid[i][c1 * 3 + j] = valid[i][c2 * 3 + j];
				valid[i][c2 * 3 + j] = temp;

				temp = solution[i][c1 * 3 + j];
				solution[i][c1 * 3 + j] = solution[i][c2 * 3 + j];
				solution[i][c2 * 3 + j] = temp;
			}
	}

	public static void swapLargeRows(int r1, int r2)
	{
		for (int i = 0; i < 3; i++)
		{
			int[] temp = valid[r1 * 3 + i];
			valid[r1 * 3 + i] = valid[r2 * 3 + i];
			valid[r2 * 3 + i] = temp;

			temp = solution[r1 * 3 + i];
			solution[r1 * 3 + i] = solution[r2 * 3 + i];
			solution[r2 * 3 + i] = temp;
		}
	}

	@Override
	public void dispose()
	{
		batch.dispose();
		text.dispose();
		numbers.dispose();
		cursor.dispose();
		hl.dispose();
		vl.dispose();
		button.dispose();
	}
}
