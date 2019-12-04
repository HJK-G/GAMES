package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector2;

public class FightingEnemy extends Enemy
{
	// all enemy same
	private static enum ai
	{
		GOING, FIGHTING, RETREAT
	};

	// ai
	private ai currState = ai.GOING;
	private float timer = 2.5f;

	public FightingEnemy(int x, int y)
	{
		super(x, y);

		health = maxHealth + 2;
		vel.y = -1.5f;
		bulletTimer = .5f;
	}

	public void update()
	{
		switch (currState)
		{
			case GOING:
				timer -= Gdx.graphics.getDeltaTime();
				if (timer <= 0)
				{
					currState = ai.FIGHTING;
					timer = 2.5f;
					vel.y = -.5f;
				}
				break;

			case FIGHTING:
				// bullets
				bulletTimer -= Gdx.graphics.getDeltaTime();
				if (bulletTimer <= 0)
				{
					bullets.add(new Projectile(bounds.getCenter(new Vector2()), new Vector2(0, -1)));
					bulletTimer = .5f;
				}

				// switch state
				timer -= Gdx.graphics.getDeltaTime();
				if (timer <= 0)
				{
					currState = ai.RETREAT;
					vel.y = 1.5f;
				}
				break;

			case RETREAT:
				if (bounds.y > Gdx.graphics.getHeight())
					isDead = true;
				break;
		}

		super.update();
	}

	@Override
	public void draw(SpriteBatch batch)
	{
		batch.setColor(Color.RED);
		super.draw(batch);
		batch.setColor(Color.WHITE);
	}
}
