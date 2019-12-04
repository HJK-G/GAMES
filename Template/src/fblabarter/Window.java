package Windows;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.fblagamesimulationandprogramming.game.Main;

public abstract class Window
{
	protected Texture background;
	protected Button[] buttons;

	public void draw(SpriteBatch batch)
	{
		batch.draw(background, 0, 0, Main.windowWidth, Main.windowHeight);
		if (buttons != null)
			for (int i = 0; i < buttons.length; i++)
				buttons[i].draw(batch);

		update();
	}

	public void update()
	{
		if (buttons != null)
			for (int i = 0; i < buttons.length; i++)
				buttons[i].update(this);
	}

	public abstract void handleButton(Button currentButton);

	public void dispose()
	{
		background.dispose();
		if (buttons != null)
			for (int i = 0; i < buttons.length; i++)
				buttons[i].dispose();
	}
}
