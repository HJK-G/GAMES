package Windows;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.GlyphLayout;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.fblagamesimulationandprogramming.game.Main;

public class Button
{
	private Texture buttonImg;
	private Rectangle dimensions;
	private String buttonText;

	public Button(String text, int x, int y, int width, int height)
	{
		buttonImg = new Texture("assets/Button.png");
		dimensions = new Rectangle(x, y, width, height);
		buttonText = text;
	}

	public Button(int x, int y, int width, int height, String imgPath)
	{
		buttonImg = new Texture(imgPath);
		dimensions = new Rectangle(x, y, width, height);
		buttonText = "";
	}

	public void draw(SpriteBatch batch)
	{
		batch.draw(buttonImg, dimensions.x, dimensions.y, dimensions.width, dimensions.height);

		// text for button
		GlyphLayout layout = new GlyphLayout(Main.gameFont, buttonText);
		Main.gameFont.draw(batch, layout, dimensions.x + (dimensions.width - layout.width) / 2,
				dimensions.y + (dimensions.height + layout.height) / 2);
	}

	public void update(Window current)
	{// if button pressed, trigger
		int mouseX = Gdx.input.getX(), mouseY = Main.windowHeight - Gdx.input.getY();
		if (Gdx.input.isTouched() && mouseX >= dimensions.x && mouseX < dimensions.x + dimensions.width
				&& mouseY >= dimensions.y && mouseY <= dimensions.y + dimensions.height)
			current.handleButton(this);
	}

	public void dispose()
	{
		buttonImg.dispose();
	}
}
