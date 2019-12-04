package Windows;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.fblagamesimulationandprogramming.game.Main;

public class OptionsScreen extends Window
{
	int prevScreen = 0;

	public OptionsScreen(int ps)
	{
		// background = new Texture("assets/OptionScreenBackground.png");
		background = new Texture("assets/ControlsBackground.png");
		prevScreen = ps;// 1=pause screen 0=title screen

		// buttons
		buttons = new Button[3];
		buttons[0] = new Button("VOLUME UP [+]", Main.windowWidth / 5, Main.windowHeight / 10 * 9, Main.windowWidth / 5,
				Main.windowHeight / 15); // volumeup
		buttons[1] = new Button("VOLUME DOWN [-]", Main.windowWidth / 5 * 3, Main.windowHeight / 10 * 9,
				Main.windowWidth / 5, Main.windowHeight / 15); // volumedown
		buttons[2] = new Button(0, Main.windowHeight - Main.windowHeight / 20, Main.windowWidth / 32,
				Main.windowHeight / 20, "assets/BackButton.png"); // titlescreen/pausescreen
	}

	public void update()
	{
		super.update();

		if (Gdx.input.isKeyJustPressed(Keys.ESCAPE))// title screen/pause screen
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			if (prevScreen == 0)
				Main.currentScreen = new TitleScreen();
			else if (prevScreen == 1)
				Main.currentScreen = new PauseScreen();
		}
		else if (Gdx.input.isKeyJustPressed(Keys.PLUS) || Gdx.input.isKeyPressed(Keys.EQUALS))
			Main.music.setVolume(Main.music.getVolume() + .1f);// volumeup
		else if (Gdx.input.isKeyJustPressed(Keys.MINUS))// volumedown
			Main.music.setVolume(Main.music.getVolume() - .1f);
	}

	public void handleButton(Button currentButton)
	{
		if (currentButton.equals(buttons[0]))// volumeup
			Main.music.setVolume(Main.music.getVolume() + .01f);
		else if (currentButton.equals(buttons[1]))// volumedown
			Main.music.setVolume(Main.music.getVolume() - .01f);
		else if (currentButton.equals(buttons[2]))// prevscreen
		{
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
			if (prevScreen == 0)
				Main.currentScreen = new TitleScreen();
			else if (prevScreen == 1)
				Main.currentScreen = new PauseScreen();
		}
	}

}
