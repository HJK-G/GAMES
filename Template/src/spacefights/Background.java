package spacefights;

import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class Background
{
	// same for all
	private static Texture bg = new Texture("assets/SPACE.jpg");
	private static Texture bg1 = new Texture("assets/SPACE1.png");

	private float y = 0;
	private float y1 = 0;
	private float scroll = .5f;

	public void update()
	{
		// 1st background
		y -= scroll;
		if (y <= -bg.getHeight())
			y += bg.getHeight();

		// other background
		y1 -= scroll * 2;
		if (y1 <= -bg1.getHeight())
			y1 += bg1.getHeight();
	}

	public void draw(SpriteBatch batch)
	{
		batch.setColor(Color.WHITE);
		// 1st background
		batch.draw(bg, 0, y);
		batch.draw(bg, 0, y + bg.getHeight());

		// other background
		batch.setColor(1, 1, 1, .5f);
		batch.draw(bg1, 0, y1);
		batch.draw(bg1, 0, y1 + bg1.getHeight());
		batch.draw(bg1, bg1.getWidth(), y1);
		batch.draw(bg1, bg1.getWidth(), y1 + bg1.getHeight());
		batch.setColor(Color.WHITE);
	}
}
