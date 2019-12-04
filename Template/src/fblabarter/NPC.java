package Characters;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.fblagamesimulationandprogramming.game.Main;

public class NPC
{
	Texture img;
	public Rectangle dimensions;
	public Item trading;

	public NPC(int x, int y)
	{
		// stationary NPC
		img = new Texture("assets/NPC/NPC" + Main.rand.nextInt(5) + ".png");
		dimensions = new Rectangle(x, y, Main.windowWidth / 30, Main.windowHeight / 10);
	}

	public void draw(SpriteBatch batch)
	{
		batch.draw(img, dimensions.x, dimensions.y, dimensions.width, dimensions.height);

		update();
	}

	public void update()
	{// distance to player is < 10 pixels
		if (Math.sqrt(Math
				.pow(Player.dimensions.x + Player.dimensions.width / 2 - (dimensions.x + dimensions.width / 2), 2)
				+ Math.pow(Player.dimensions.y + Player.dimensions.height / 2 - (dimensions.y + dimensions.height / 2),
						2)) < Main.windowHeight / 30)
		{
			Player.closest = this;
		}
		else if (Player.closest != null && Player.closest.equals(this))
			Player.closest = null;
	}

	public void chat()
	{// random item generation
		trading = new Item();
		Main.countdown = 1f;
	}
}
