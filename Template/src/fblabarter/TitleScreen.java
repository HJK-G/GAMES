package Windows;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.fblagamesimulationandprogramming.game.Main;

public class TitleScreen extends Window
{
	public TitleScreen()
	{
		background = new Texture("assets/TitleScreenBackground.png");

		// buttons
		buttons = new Button[3];
		buttons[0] = new Button("Start Game [ENTER]", Main.windowWidth / 2 - Main.windowWidth / 6,
				Main.windowHeight / 5 * 2, Main.windowWidth / 3, Main.windowHeight / 10); // start
		buttons[1] = new Button("OPTIONS [CTRL]", Main.windowWidth / 2 - Main.windowWidth / 6, Main.windowHeight / 4,
				Main.windowWidth / 3, Main.windowHeight / 10); // options
		buttons[2] = new Button("QUIT GAME [ESC]", Main.windowWidth / 2 - Main.windowWidth / 6, Main.windowHeight / 9,
				Main.windowWidth / 3, Main.windowHeight / 10); // quit
	}

	public void update()
	{
		// so don't press buttons twice
		if (Main.countdown >= 0)
			return;

		super.update();

		if (Gdx.input.isKeyJustPressed(Keys.ESCAPE))// quit game
			Gdx.app.exit();
		else if (Gdx.input.isKeyJustPressed(Keys.CONTROL_LEFT) || Gdx.input.isKeyJustPressed(Keys.CONTROL_RIGHT))// options
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = new OptionsScreen(0);
		}
		else if (Gdx.input.isKeyJustPressed(Keys.ENTER))// start game
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.ingame = true;
			Main.game = new GameScreen();
			Main.currentScreen = null;
		}
	}

	public void handleButton(Button currentButton)
	{
		if (currentButton.equals(buttons[0]))// start game
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = null;
			Main.ingame = true;
			Main.game = new GameScreen();
		}
		else if (currentButton.equals(buttons[1]))// options
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			Main.currentScreen = new OptionsScreen(0);
		}
		else if (currentButton.equals(buttons[2]))// quit game
			Gdx.app.exit();
	}
}
