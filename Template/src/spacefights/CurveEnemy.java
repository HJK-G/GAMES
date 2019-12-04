package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector2;

public class CurveEnemy extends Enemy
{
	private boolean dirLeft;

	public CurveEnemy(int x, int y, boolean left)
	{
		super(x, y);

		dirLeft = left;
		health = maxHealth - 1;
		bulletTimer = 1f;
		vel = new Vector2(0, -1.5f);
	}

	@Override
	public void update()
	{
		if (dirLeft)
			vel.setAngle(vel.angle() + 10 * Gdx.graphics.getDeltaTime());
		else
			vel.setAngle(vel.angle() - 10 * Gdx.graphics.getDeltaTime());

		// bullets
		bulletTimer -= Gdx.graphics.getDeltaTime();
		if (bulletTimer <= 0)
		{
			bullets.add(new Projectile(bounds.getCenter(new Vector2()), new Vector2(0, -1)));
			bulletTimer = .5f;
		}

		super.update();
	}

	@Override
	public void draw(SpriteBatch batch)
	{
		batch.setColor(Color.YELLOW);
		super.draw(batch);
		batch.setColor(Color.WHITE);
	}
}
