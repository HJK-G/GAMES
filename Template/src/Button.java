

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector2;
import com.fblagamesimulationandprogramming.game.Main;

public class Button
{
	private Texture buttonImg;
	private Vector2 pos;
	private Vector2 dimensions;

	public Button(String imgPath, int x, int y, int width, int height)
	{
		buttonImg = new Texture(imgPath);
		pos.x = x;
		pos.y = y;
		dimensions.x = width;
		dimensions.y = height;
	}

	public void draw(SpriteBatch batch)
	{
		batch.draw(buttonImg, pos.x, pos.y, dimensions.x, dimensions.y);
	}

	public void update(Window current)
	{
		int mouseX = Main.windowWidth - Gdx.input.getX(), mouseY = Main.windowHeight - Gdx.input.getY();
		if (mouseX >= pos.x && mouseX < pos.x + dimensions.x && mouseY >= pos.y && mouseY <= pos.y + dimensions.y)
			current.handleButton(this);
	}
}
