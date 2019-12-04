import java.util.ArrayList;
import java.util.Random;

public class s
{
	public static void main(String[] args)
	{
		Tile[] a = Tile.randomTiles(20);
		for (Tile b : a)
			System.out.println(b.connection);
	}

}

class Tile
{
	// tiles
	private static Random rand = new Random();

	// specific tiles
	public int[] connection = new int[8];
	private int row, col;

	public Tile(int[] connection)
	{
		this.connection = connection;
	}

	public void place(int row, int col)
	{
		this.col = col;
		this.row = row;
	}

	public static Tile[] randomTiles(int num)
	{
		Tile[] tiles = new Tile[num];
		for (int i = 0; i < num; i++)
		{
			// add numbers to remove and randomize
			ArrayList<Integer> numbers = new ArrayList<Integer>();
			for (int j = 0; j < 8; j++)
				numbers.add(j);

			// connections
			int[] connections = new int[8];
			for (int j = 4; j >= 0 && numbers.size() > 0; j--)
			{
				int ranum = rand.nextInt(numbers.size());
				while (ranum == j)
					ranum = rand.nextInt(numbers.size());
				int remover = numbers.remove(ranum);
				if (j >= numbers.size())
					j = numbers.size() - 1;
				int removej = numbers.remove(j);
				connections[removej] = remover;
				connections[remover] = removej;
			}
			tiles[i] = new Tile(connections);
		}

		return tiles;
	}
}
