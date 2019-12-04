package spacefights;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.math.Vector2;

public class Projectile extends GameObject
{
	// all projectile same
	private static final Texture projectileImage = new Texture("assets/BULLET.png");
	private static final float velScale = 10f;

	public Projectile(Vector2 pos, Vector2 vel)
	{
		// image
		image = projectileImage;

		move(pos);
		this.vel = vel.nor().scl(velScale);
		resize(10, 10);
	}

	// lots of get methods
	public static float getVelScale()
	{
		return velScale;
	}
}
