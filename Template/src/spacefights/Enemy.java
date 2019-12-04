package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.Array;

public class Enemy extends GameObject
{
	// all enemy same
	protected static Texture enemyTexture = new Texture("assets/EnemyShip.gif");
	protected static int maxHealth = 3;
	protected float timer = 20f;
	// bullet stuff
	protected static Array<Projectile> bullets = new Array<Projectile>();
	protected float bulletTimer;

	public Enemy(int x, int y)
	{
		// image stuff
		image = enemyTexture;

		health = maxHealth;
		move(x, y);
		doesDespawn = false;
		resize(image.getWidth() / 5, image.getHeight() / 5);
		vel.y = -1;
	}

	public void update()
	{
		timer -= Gdx.graphics.getDeltaTime();
		if (timer <= 0)
			doesDespawn = true;
		super.update();
	}

	public static void updateBullets()
	{
		for (int i = 0; i < bullets.size; i++)
		{
			Projectile bullet = bullets.get(i);
			bullet.update();
			if (bullet.isDead)
				bullets.removeIndex(i--);
		}
	}

	public static void drawBullets(SpriteBatch batch)
	{
		batch.setColor(Color.BLUE);
		for (Projectile bullet : bullets)
			bullet.draw(batch);
	}

	// lots of get methods
	public static Array<Projectile> getEnemyBullets()
	{
		return bullets;
	}

	// lots of set methods
	public static void increaseMaxHealth()
	{
		maxHealth++;
	}
}
