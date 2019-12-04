package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.Texture.TextureFilter;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Array;
import com.spacefights.game.spacefights.GameState;

public class Player extends GameObject
{
	private static int defaultHealth = 10;
	// bullets
	private Array<Projectile> bullets = new Array<Projectile>();
	private float defaultCooldown = .3f;
	private float cooldown = defaultCooldown;
	private int numBullets = 100;

	private int score = 0;

	private enum PlayerMode
	{
		NORMAL, FOCUSED, SUPERCHEATMODE
	};

	private PlayerMode mode = PlayerMode.NORMAL;
	private boolean focusedModeBought = false;

	public Player(int x, int y)
	{
		// image stuff
		image = new Texture("assets/SPACESHIP.png");
		resize(image.getWidth() / 5, image.getHeight() / 5);
		image.setFilter(TextureFilter.Linear, TextureFilter.Linear);
		collisionRect.width = collisionRect.width - 50;

		health = defaultHealth;
		speed = 250;
		move(x - bounds.width / 2, y);
	}

	public void checkInput()
	{
		// input
		vel.set(0, 0);
		// super cheat mode
		if (Gdx.input.isKeyPressed(Keys.GRAVE))
		{
			health = 0x3f3f3f3f;
			defaultCooldown = .001f;
			score = 0x3f3f3f3f;
			mode = PlayerMode.SUPERCHEATMODE;
			speed = 300;
			numBullets = 0x3f3f3f3f;
		}
		if (Gdx.input.isKeyPressed(Keys.RIGHT))
			vel.x += 1;
		if (Gdx.input.isKeyPressed(Keys.LEFT))
			vel.x -= 1;
		if (Gdx.input.isKeyPressed(Keys.UP))
			vel.y += 1;
		if (Gdx.input.isKeyPressed(Keys.DOWN))
			vel.y -= 1;
		if (Gdx.input.isKeyPressed(Keys.Z) && cooldown <= 0 && numBullets > 0)
		{
			if (mode == PlayerMode.NORMAL && numBullets >= 3)
			{
				bullets.add(new Projectile(bounds.getCenter(new Vector2()), new Vector2(0, 1)));
				bullets.add(new Projectile(bounds.getCenter(new Vector2()), new Vector2(-.7f, 1)));
				bullets.add(new Projectile(bounds.getCenter(new Vector2()), new Vector2(.7f, 1)));
				cooldown = defaultCooldown;
				numBullets -= 3;
			}
			else if (mode == PlayerMode.FOCUSED && numBullets >= 3)
			{
				bullets.add(new Projectile(bounds.getCenter(new Vector2()).add(-20, 0), new Vector2(0, 1)));
				bullets.add(new Projectile(bounds.getCenter(new Vector2()).add(-10, 10), new Vector2(0, 1)));
				bullets.add(new Projectile(bounds.getCenter(new Vector2()).add(0, 15), new Vector2(0, 1)));
				bullets.add(new Projectile(bounds.getCenter(new Vector2()).add(10, 10), new Vector2(0, 1)));
				bullets.add(new Projectile(bounds.getCenter(new Vector2()).add(20, 0), new Vector2(0, 1)));
				cooldown = defaultCooldown;
				numBullets -= 5;
			}
			else if (mode == PlayerMode.SUPERCHEATMODE)
			{
				for (int i = 0; i < Gdx.graphics.getWidth(); i += 10)
				{
					bullets.add(new Projectile(new Vector2(i, bounds.y), new Vector2(0, 1)));
					numBullets -= .1f;
				}
			}
			else
			{
				numBullets--;
				bullets.add(new Projectile(bounds.getCenter(new Vector2()), new Vector2(0, 1)));
				cooldown = defaultCooldown;
			}
		}
		if (mode != PlayerMode.SUPERCHEATMODE)
			if (Gdx.input.isKeyPressed(Keys.X) && focusedModeBought)
				mode = PlayerMode.FOCUSED;
			else
				mode = PlayerMode.NORMAL;
	}

	public void update()
	{
		// boundaries
		int sWidth = Gdx.graphics.getWidth();
		int sHeight = Gdx.graphics.getHeight();
		if (bounds.x + bounds.width > sWidth)
			bounds.x = sWidth - bounds.width;
		else if (bounds.x < 0)
			bounds.x = 1;
		if (bounds.y + bounds.height > sHeight)
			bounds.y = sHeight - bounds.height;
		else if (bounds.y < 0)
			bounds.y = 1;

		checkInput();

		if (health <= 0)
		{
			spacefights.state = GameState.PAUSED;
			health = defaultHealth;
		}

		// bullet update
		for (Projectile bul : bullets)
			bul.update();
		if (cooldown > 0)
			cooldown -= Gdx.graphics.getDeltaTime();
		// remove bullets
		for (int i = 0; i < bullets.size; i++)
			if (bullets.get(i).isDead)
				bullets.removeIndex(i--);

		vel.nor();
		vel.scl(speed);
		if (mode == PlayerMode.FOCUSED)
			vel.scl(.5f);
		vel.scl(Gdx.graphics.getDeltaTime());
		super.update();
	}

	public void draw(SpriteBatch batch)
	{
		batch.setColor(Color.WHITE);
		for (Projectile bul : bullets)
			bul.draw(batch);

		super.draw(batch);
	}

	public void reset()
	{
		if (mode != PlayerMode.SUPERCHEATMODE)
		{
			health = defaultHealth;
			cooldown = defaultCooldown;
			mode = PlayerMode.NORMAL;
			score = 0;
			numBullets = 100;
			focusedModeBought = false;
		}
		bullets = new Array<Projectile>();
	}

	public void checkCollision(Array<GameObject> enemies)
	{
		// if player hits enemy
		for (GameObject e : enemies)
			if (e.isColliding(this))
			{
				this.health -= e.health;
				e.health -= this.health / 2 + 10;
			}

		// if player gets powerup
		for (PowerUp pow : PowerUp.getPowerUps())
			if (pow.isColliding(this))
			{
				pow.isDead = true;
				health += 1;
			}

		// if player hits enemy with bullet
		for (Projectile bullet : bullets)
		{
			Enemy e = (Enemy) bullet.multipleCollision(enemies);
			if (e != null)
			{
				bullet.isDead = true;
				e.health--;
				if (e.health == 0)
					score += e.maxHealth;
			}
		}

		// if player hits enemy bullet with bullet
		// if enemy bullet hits player
		for (Projectile bullet : Enemy.getEnemyBullets())
			if (bullet.isColliding(this))
			{
				health--;
				bullet.isDead = true;
			}
	}

	// lots of get methods
	public int getScore()
	{
		return score;
	}

	public boolean getFocusedMode()
	{
		return focusedModeBought;
	}

	public int getBullets()
	{
		return numBullets;
	}

	// lots of set methods
	public void setBulletAmount(int amount)
	{
		numBullets += amount;
	}

	public void setHealth(int amount)
	{
		health += amount;
	}

	public void focused()
	{
		focusedModeBought = true;
	}

	public void setScore(int amount)
	{
		score += amount;
	}
}
