package Windows;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.fblagamesimulationandprogramming.game.Main;

public class PauseScreen extends Window
{
	boolean first = true;

	public PauseScreen()
	{
		background = new Texture("assets/fakeimg.png");

		// buttons
		buttons = new Button[4];
		buttons[0] = new Button("RESUME [ENTER]", Main.windowWidth / 2 - Main.windowWidth / 6,
				Main.windowHeight / 5 * 4, Main.windowWidth / 3, Main.windowHeight / 10); // resume
		buttons[1] = new Button("OPTIONS [CTRL]", Main.windowWidth / 2 - Main.windowWidth / 6,
				Main.windowHeight / 5 * 3, Main.windowWidth / 3, Main.windowHeight / 10); // options
		buttons[2] = new Button("QUIT TO TITLE [BKSPCE]", Main.windowWidth / 2 - Main.windowWidth / 6,
				Main.windowHeight / 5 * 2, Main.windowWidth / 3, Main.windowHeight / 10); // titlescreen
		buttons[3] = new Button("QUIT GAME [ESC]", Main.windowWidth / 2 - Main.windowWidth / 6, Main.windowHeight / 5,
				Main.windowWidth / 3, Main.windowHeight / 10); // desktop
	}

	public void update()
	{
		super.update();

		// first entry
		if (first)
		{
			first = false;
			Main.game.save();
		}

		if (Gdx.input.isKeyJustPressed(Keys.ESCAPE))// quit game
			Gdx.app.exit();
		else if (Gdx.input.isKeyJustPressed(Keys.BACKSPACE))// back to title
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = new TitleScreen();
		}
		else if (Gdx.input.isKeyJustPressed(Keys.CONTROL_LEFT) || Gdx.input.isKeyJustPressed(Keys.CONTROL_RIGHT))// options
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = new OptionsScreen(1);
		}
		else if (Gdx.input.isKeyJustPressed(Keys.ENTER))// back to game
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = null;
			Main.ingame = true;
		}
	}

	public void handleButton(Button currentButton)
	{
		if (currentButton.equals(buttons[0]))// back to game
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.ingame = true;
			Main.currentScreen = null;
			Main.music.play();
			Main.countdown = 1f;
		}
		else if (currentButton.equals(buttons[1]))// options
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = new OptionsScreen(1);
		}
		else if (currentButton.equals(buttons[2]))// back to title
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = new TitleScreen();
			Main.countdown = 1f;
		}
		else if (currentButton.equals(buttons[3]))// quit game
			Gdx.app.exit();
	}
}
