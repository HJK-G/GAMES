package spacefights;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Array;

public class PowerUp extends GameObject
{
	// same for all
	private static final Texture im = new Texture("assets/Heart.png");

	// list
	private static Array<PowerUp> powerUps = new Array<PowerUp>();

	public PowerUp(Vector2 pos)
	{
		this.image = im;
		powerUps.add(this);
		vel.y = -.5f;
		doesDespawn = false;
		move(pos);
		resize(50, 50);
	}

	@Override
	public void update()
	{
		if (isDead)
			powerUps.removeValue(this, true);
		super.update();
	}

	public static void reset()
	{
		powerUps = new Array<PowerUp>();
	}

	// lots of get methods
	public static Array<PowerUp> getPowerUps()
	{
		return powerUps;
	}
}
