package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;

public class Button
{
	protected Rectangle bounds;
	protected Texture im;
	protected Color buttonColor = Color.WHITE;
	protected boolean entered = false;
	protected boolean isPressed = false;

	public Button(int x, int y, int width, int height)
	{
		im = new Texture("assets/shopButton.png");
		bounds = new Rectangle(x, y, width, height);
	}

	public Button(int x, int y, int width, int height, Texture t)
	{
		im = t;
		bounds = new Rectangle(x, y, width, height);
	}

	public void update()
	{
		if (bounds.contains(Gdx.input.getX(), Gdx.graphics.getHeight() - Gdx.input.getY()))
		{
			if (!entered)
			{
				handleEnter();
				entered = true;
			}
			if (Gdx.input.justTouched())
				handleTouch();
		}
		else if (entered)
		{
			handleExit();
			entered = false;
		}
	}

	protected void handleTouch()
	{
		isPressed = true;
	}

	protected void handleEnter()
	{
	}

	protected void handleExit()
	{
		isPressed = false;
	}

	public void draw(SpriteBatch batch)
	{
		batch.setColor(buttonColor);
		batch.draw(im, bounds.x, bounds.y, bounds.width, bounds.height);
		batch.setColor(Color.WHITE);
	}
}
