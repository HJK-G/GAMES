package com.tsuro.game;

import java.util.ArrayList;
import java.util.Random;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class Tile
{
	// tiles
	private static Random rand = new Random();
	private static Texture tile = new Texture("assets/Tile.tif");
	private static Texture connector = new Texture("assets/Connector.png");

	// specific tiles
	private int[] connection = new int[8];
	private int row, col;

	public Tile(int[] connection)
	{
		this.connection = connection;
	}

	public void draw(SpriteBatch batch)
	{
		batch.draw(tile, row * 60 + 60, col * 60 + 60, 60, 60);
	}

	public void place(int row, int col)
	{
		this.col = col;
		this.row = row;
	}

	public void drawConnections(SpriteBatch batch)
	{

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
