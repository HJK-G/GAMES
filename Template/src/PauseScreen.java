

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.fblagamesimulationandprogramming.game.Main;

public class PauseScreen extends Window
{
	public PauseScreen()
	{
		background = new Texture("");

		// buttons
		buttons = new Button[3];
		buttons[0] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // resume
		buttons[1] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // options
		buttons[2] = new Button("", Main.windowWidth, Main.windowHeight, Main.windowWidth, Main.windowHeight); // titlescreen
	}

	public void update()
	{
		for (int i = 0; i < buttons.length; i++)
			buttons[i].update(this);

		if (Gdx.input.isKeyPressed(Keys.ESCAPE))
			Main.currentScreen = new TitleScreen();
		else if (Gdx.input.isKeyPressed(Keys.CONTROL_LEFT) || Gdx.input.isKeyPressed(Keys.CONTROL_RIGHT))
			Main.currentScreen = new OptionsScreen(1);
		else if (Gdx.input.isKeyPressed(Keys.ENTER))
			Main.currentScreen = new GameScreen();
	}

	public void handleButton(Button currentButton)
	{
		if (currentButton.equals(buttons[0]))
			Main.currentScreen = new GameScreen();
		else if (currentButton.equals(buttons[1]))
			Main.currentScreen = new OptionsScreen(1);
		else if (currentButton.equals(buttons[2]))
			Main.currentScreen = new TitleScreen();
	}

}
