package rnd;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.ParticleEffect;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.ith.game.Main;

import CriticalSupport.Map;
import Player.Player;

public class Melee
{
	final static Texture mimg = new Texture("assets/Items/Ranged0.png");
	public static ParticleEffect electricity = new ParticleEffect();

	public final static float damage = 10;

	Melee.electricity.load(Gdx.files.internal("assets/Misc/LightningEffectMelee"),
			Gdx.files.internal("assets/Misc"));
	public static void draw(SpriteBatch batch)
	{
		// item img
		batch.draw(mimg, Map.offshiftX + Map.width * 4 / 9, 0, Main.width / 5, Main.height / 15);

		electricity.draw(batch, Gdx.graphics.getDeltaTime());
	}

	public static void swing()
	{
		if (Player.selection == 1 && Main.timerChecks[2])
		{
			electricity.reset();
			electricity.start();
			electricity.setPosition(Player.x, Player.y);
			electricity.setDuration(1000);
			Main.resetTimer(2, 1200);
		}
	}

	public static void newRoom()
	{
		electricity.reset();
	}
}
