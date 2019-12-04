package IRON_SNOUT;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import javax.swing.JComponent;
import javax.swing.JFrame;
import javax.swing.WindowConstants;

public class Main extends JComponent
{
	private final static int WIDTH = 600;
	private final static int HEIGHT = 600;

	private static int score = 0;

	// game objects
	Player p1;
	EnemySpawner spawn;

	public Main()
	{
		// set game objects
		p1 = new Player();
		spawn = new EnemySpawner();
	}

	public static void main(String[] args)
	{
		JFrame f = new JFrame("FE NOSE");
		Main te = new Main();

		f.setSize(WIDTH, HEIGHT + 20);
		f.setLocation(100, 100);
		f.add(te);
		f.setVisible(true);
		f.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
		f.addKeyListener(te.p1);
	}

	private void update()
	{
		// update
		if (p1.getHealth() <= 0)
		{
			p1.reset();
			spawn.reset();
			score = 0;
		}

	}

	@Override
	public void paintComponent(Graphics g)
	{
		Graphics2D g2 = (Graphics2D) g;

		update();

		// draw
		p1.draw(g2);
		spawn.draw(g2, p1);

		// stats
		g2.setColor(Color.black);
		g2.drawString("Score: " + score, 10, 10);
		g2.drawString("Health: " + p1.getHealth(), WIDTH - 75, 10);

		repaint();
	}

	// lots of get methods
	public static int getScreenWidth()
	{
		return WIDTH;
	}

	public static int getScreenHeight()
	{
		return HEIGHT;
	}

	public static int getScore()
	{
		return score;
	}

	// lots of set methods
	public static void setScore(int s)
	{
		score += s;
	}

}
