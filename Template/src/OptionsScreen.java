

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.fblagamesimulationandprogramming.game.Main;

public class OptionsScreen extends Window
{
	int prevScreen = 0;

	public OptionsScreen(int ps)
	{
		background = new Texture("");
		prevScreen = ps;

		// buttons
		buttons = new Button[3];
		if (ps == 0)
		{
			buttons[0] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // volumeup
			buttons[1] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // volumedown
			buttons[2] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // titlescreen
		}
		else if (ps == 1)
		{
			buttons[0] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // volumeup
			buttons[1] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // volumedown
			buttons[2] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // pausescreen
		}
	}

	public void update()
	{
		for (int i = 0; i < buttons.length; i++)
			buttons[i].update(this);

		if (Gdx.input.isKeyPressed(Keys.ESCAPE))
		{
			if (prevScreen == 0)
				Main.currentScreen = new TitleScreen();
			else if (prevScreen == 1)
				Main.currentScreen = new PauseScreen();
		}
		else if (Gdx.input.isKeyPressed(Keys.PLUS) || Gdx.input.isKeyPressed(Keys.EQUALS))
			Main.music.setVolume(Main.music.getVolume() + .1f);
		else if (Gdx.input.isKeyPressed(Keys.MINUS))
			Main.music.setVolume(Main.music.getVolume() - .1f);
	}

	public void handleButton(Button currentButton)
	{
		if (currentButton.equals(buttons[0]))
			Main.music.setVolume(Main.music.getVolume() + .1f);
		else if (currentButton.equals(buttons[1]))
			Main.music.setVolume(Main.music.getVolume() - .1f);
		else if (currentButton.equals(buttons[2]))
		{
			if (prevScreen == 0)
				Main.currentScreen = new TitleScreen();
			else if (prevScreen == 1)
				Main.currentScreen = new PauseScreen();
		}
	}

}
