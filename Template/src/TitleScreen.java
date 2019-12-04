

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Texture;
import com.fblagamesimulationandprogramming.game.Main;

public class TitleScreen extends Window
{
	public TitleScreen()
	{
		background = new Texture("assets/fakeimg.png");

		// buttons
		buttons = new Button[3];
		buttons[0] = new Button("assets/fakeimg.png", Main.windowWidth / 10, Main.windowHeight / 10,
				Main.windowWidth / 10, Main.windowHeight / 10); // start
		buttons[1] = new Button("assets/fakeimg.png", Main.windowWidth / 20, Main.windowHeight / 20,
				Main.windowWidth / 20, Main.windowHeight / 20); // options
		buttons[2] = new Button("assets/fakeimg.png", Main.windowWidth / 40, Main.windowHeight / 40,
				Main.windowWidth / 40, Main.windowHeight / 40); // quit
	}

	public void update()
	{
		for (int i = 0; i < buttons.length; i++)
			buttons[i].update(this);

		if (Gdx.input.isKeyPressed(Keys.ESCAPE))
			Gdx.app.exit();
		else if (Gdx.input.isKeyPressed(Keys.CONTROL_LEFT) || Gdx.input.isKeyPressed(Keys.CONTROL_RIGHT))
			Main.currentScreen = new OptionsScreen(0);
		else if (Gdx.input.isKeyPressed(Keys.ENTER))
			Main.currentScreen = new GameScreen();
	}

	public void handleButton(Button currentButton)
	{
		if (currentButton.equals(buttons[0]))
			Main.currentScreen = new GameScreen();
		else if (currentButton.equals(buttons[1]))
			Main.currentScreen = new OptionsScreen(0);
		else if (currentButton.equals(buttons[2]))
			Gdx.app.exit();
	}
}
