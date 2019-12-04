package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.math.Vector2;

public class BossEnemy extends Enemy
{
	// all enemy same
	private static enum ai
	{
		GOING, FIGHTING, MOREFIGHTING
	};

	// ai
	private ai currState = ai.GOING;
	private int dir = 0;

	public BossEnemy(int x, int y)
	{
		super(x, y);

		resize(image.getWidth(), image.getHeight());
		collisionRect.height -= 150;
		maxHealth = 1000;
		health = 1000;
		vel.y = -.75f;
	}

	@Override
	public void update()
	{
		switch (currState)
		{
			case GOING:
				// switch state
				if (bounds.y <= Gdx.graphics.getHeight() * 2 / 3)
				{
					currState = ai.FIGHTING;
					dir = -1;
					vel.y = 0;
				}
				break;

			case FIGHTING:
				// bullets
				bulletTimer -= Gdx.graphics.getDeltaTime();
				if (bulletTimer <= 0)
				{
					for (int i = 0; i < 10; i++)
						bullets.add(new Projectile(bounds.getCenter(new Vector2()),
								new Vector2((float) (Math.random() * 7) - 3.5f, -1)));

					bulletTimer = .5f;
				}

				// dir
				vel.x = dir;
				if (bounds.x < 0)
					dir = 1;
				else if (bounds.x + bounds.width > Gdx.graphics.getWidth())
					dir = -1;

				// switch state
				if (health <= maxHealth / 2 && (bounds.getCenter(new Vector2()).x >= Gdx.graphics.getWidth() / 2 - 10)
						|| bounds.getCenter(new Vector2()).x <= Gdx.graphics.getWidth() / 2 + 10)
				{
					currState = ai.MOREFIGHTING;
					vel.x = 0;
				}

				break;

			case MOREFIGHTING:
				// bullets
				bulletTimer -= Gdx.graphics.getDeltaTime();
				if (bulletTimer <= 0)
				{
					for (int i = 0; i < 20; i++)
						bullets.add(new Projectile(bounds.getCenter(new Vector2()),
								new Vector2((float) (Math.random() * 7) - 3.5f, -1)));

					bulletTimer = .5f;
				}
				break;
		}

		super.update();
	}
}
