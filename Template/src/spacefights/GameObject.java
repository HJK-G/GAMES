package spacefights;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Array;

public class GameObject
{
	// standard
	protected Texture image;
	protected Rectangle bounds = new Rectangle();
	protected Rectangle collisionRect = new Rectangle();

	// qualities
	protected boolean isDead = false;
	protected float speed = 0;
	protected Vector2 vel = new Vector2();
	protected int health = 1;
	protected boolean doesDespawn = true;

	public void update()
	{
		move(vel);
		Vector2 center = bounds.getCenter(new Vector2());
		if ((center.x < 0 || center.x > Gdx.graphics.getWidth() || center.y < 0 || center.y > Gdx.graphics.getHeight())
				&& doesDespawn)
			isDead = true;
	}

	public void draw(SpriteBatch batch)
	{
		batch.draw(image, bounds.x, bounds.y, bounds.width, bounds.height);
	}

	public boolean isColliding(GameObject obj)
	{
		return collisionRect.overlaps(obj.collisionRect);
	}

	public GameObject multipleCollision(Array<GameObject> arrObj)
	{
		for (GameObject obj : arrObj)
		{
			if (isColliding(obj))
				return obj;
		}
		return null;
	}

	// lots of set methods
	public void resize(int width, int height)
	{
		bounds.setSize(width, height);
		collisionRect.setSize(width, height);
	}

	public void move(float x, float y)
	{
		bounds.setPosition(bounds.x + x, bounds.y + y);
		collisionRect.setCenter(bounds.getCenter(new Vector2()));
	}

	public void move(Vector2 pos)
	{
		move(pos.x, pos.y);
	}
}
