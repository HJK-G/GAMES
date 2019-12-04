package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.files.FileHandle;
import com.badlogic.gdx.graphics.g2d.ParticleEffect;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Array;

public class EnemySpawner
{
	// game object
	private Array<GameObject> enemies = new Array<GameObject>();

	// explosion
	Sound explode = Gdx.audio.newSound(new FileHandle("assets/EXPLOSION.mp3"));
	ParticleEffect explosion;

	// spawn rates
	private int defaultRate = 100;
	private int rate = defaultRate;
	private int counter = 0;
	private int scounter = 0;
	private int defaultSpawnRate = 500;
	private int espawnrate = defaultSpawnRate;

	// boss
	private boolean bossSpawned = false;
	private int defaultBossCounterTimer = 100;
	private int bossCounterTimer = defaultBossCounterTimer;

	// changing enemies
	private float likelihood = .9f;

	public EnemySpawner()
	{
		explosion = new ParticleEffect();
		explosion.load(Gdx.files.internal("assets/Explosion"), Gdx.files.internal("assets/Particles"));
	}

	public void update()
	{
		// get rid of dead enemies
		for (int i = 0; i < enemies.size; i++)
		{
			Enemy e = (Enemy) enemies.get(i);
			if (e.health <= 0)
			{
				if (Math.random() < .3)
					new PowerUp(e.bounds.getCenter(new Vector2()).add(-5, -5));
				e.isDead = true;
				explosion.start();
				Vector2 center = e.bounds.getCenter(new Vector2());
				explosion.setPosition(center.x, center.y);
				explode.play(.1f);
			}
			if (e.isDead)
			{
				enemies.removeIndex(i);
				i--;
			}

			e.update();
		}
		if (enemies.size == 0)
			bossSpawned = false;

		// spawn rates changing things
		scounter++;
		if (scounter >= espawnrate)
		{
			rate -= 5;
			scounter = 0;
		}
		if (rate < 30)
		{
			rate = 100;
			espawnrate -= 1;
		}

		// shooting enemy bullets
		Enemy.updateBullets();

		// add new enemy after dies and counter is more than rate
		counter++;
		if (counter >= rate && !bossSpawned)
		{
			// boss
			if (bossCounterTimer <= 0)
			{
				if (enemies.size == 0)
				{
					bossCounterTimer = defaultBossCounterTimer;
					reset();
					enemies.add(new BossEnemy(Gdx.graphics.getWidth() / 2 - Enemy.enemyTexture.getWidth() / 2,
							Gdx.graphics.getHeight() + 200));
					bossSpawned = true;
					Enemy.maxHealth++;
				}
				return;
			}

			counter = 0;
			if (Math.random() < likelihood)
				enemies.add(new Enemy((int) (Math.random() * Gdx.graphics.getWidth()) - 50,
						(int) (Math.random() * 100 + Gdx.graphics.getHeight())));
			else if (Math.random() > .5)
				enemies.add(new FightingEnemy((int) (Math.random() * Gdx.graphics.getWidth()) - 50,
						(int) Gdx.graphics.getHeight()));
			else
				enemies.add(new CurveEnemy((int) (Math.random() * Gdx.graphics.getWidth()) - 50,
						(int) Gdx.graphics.getHeight(), Math.random() > .5));

			bossCounterTimer--;
			likelihood *= .95;
		}
	}

	public void draw(SpriteBatch batch)
	{
		for (GameObject e : enemies)
			e.draw(batch);

		// fighting enemy bullets
		Enemy.drawBullets(batch);

		explosion.draw(batch, Gdx.graphics.getDeltaTime());
	}

	public void reset()
	{
		enemies = new Array<GameObject>();
		Enemy.bullets = new Array<Projectile>();
		rate = defaultRate;
		counter = 0;
		scounter = 0;
		espawnrate = defaultSpawnRate;
		explosion.reset();
	}

	// lots of get methods
	public Array<GameObject> getEnemies()
	{
		return enemies;
	}
}
