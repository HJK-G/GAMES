

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.fblagamesimulationandprogramming.game.Main;

public abstract class Window
{
	protected static Texture background;
	protected static Button[] buttons;

	public void draw(SpriteBatch batch)
	{
		batch.draw(background, 0, 0, Main.windowWidth, Main.windowHeight);
		for (int i = 0; i < buttons.length; i++)
			buttons[i].draw(batch);

		update();
	}

	public abstract void update();

	public abstract void handleButton(Button currentButton);
}
