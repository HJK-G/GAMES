package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class Shop
{
	private Button buyBullets;
	private Button buyHealth;
	private Button buyFocusedMode;
	private float cooldown = .5f;
	boolean focusedBought = false;

	public Shop()
	{
		buyBullets = new Button(100, 350, 20, 15, new Texture("assets/BULLET.png"));
		buyHealth = new Button(100, 250, 20, 15, new Texture("assets/Heart.png"));
		buyFocusedMode = new Button(90, 150, 20, 15, new Texture("assets/SPACESHIP.png"));
	}

	public void update(Player p1)
	{
		buyBullets.update();
		buyHealth.update();
		buyFocusedMode.update();
		int score = p1.getScore();
		cooldown -= Gdx.graphics.getDeltaTime();
		focusedBought = p1.getFocusedMode();

		if (cooldown <= 0)
		{
			if (buyBullets.isPressed && score >= 1)
			{
				p1.setBulletAmount(10);
				p1.setScore(-1);
				cooldown = .5f;
				buyBullets.isPressed = false;
			}
			if (buyHealth.isPressed && score >= 2)
			{
				p1.setHealth(1);
				p1.setScore(-2);
				cooldown = .5f;
				buyHealth.isPressed = false;
			}
			if (buyFocusedMode.isPressed && score >= 15 && !focusedBought)
			{
				p1.focused();
				p1.setScore(-15);
				cooldown = .5f;
				buyFocusedMode.isPressed = false;
			}
		}
	}

	public void draw(SpriteBatch batch, BitmapFont gamefont)
	{
		batch.draw(buyBullets.im, buyBullets.bounds.x, buyBullets.bounds.y, 20, 20);
		gamefont.draw(batch, "Buy bullets: 1 score per 10 bullets", buyBullets.bounds.x - 20, buyBullets.bounds.y - 10);
		batch.draw(buyHealth.im, buyHealth.bounds.x, buyHealth.bounds.y, 20, 20);
		gamefont.draw(batch, "Buy health: 2 score per health", buyHealth.bounds.x - 20, buyHealth.bounds.y - 10);
		if (!focusedBought)
		{
			batch.draw(buyFocusedMode.im, buyFocusedMode.bounds.x, buyFocusedMode.bounds.y, 40, 30);
			gamefont.draw(batch, "Buy focused mode: 15 score per game", buyFocusedMode.bounds.x - 20,
					buyFocusedMode.bounds.y - 10);
		}
	}
}
