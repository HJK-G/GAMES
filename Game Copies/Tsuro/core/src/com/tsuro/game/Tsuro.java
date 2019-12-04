package com.tsuro.game;

import java.util.ArrayList;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class Tsuro extends ApplicationAdapter
{
	SpriteBatch batch;

	// board
	Tile[][] board;
	Texture boardBg;
	Tile[] deck;

	// players
	ArrayList<Player> players;

	// game state
	enum GameState
	{
		PLAYERSELECT, SELECTTILE, DRAW, MOVE, END
	}

	GameState state = GameState.PLAYERSELECT;

	@Override
	public void create()
	{
		batch = new SpriteBatch();

		// board
		board = new Tile[6][6];
		boardBg = new Texture("TileBg.tif");

		// players
		players = new ArrayList<Player>();

		state = GameState.DRAW;
	}

	@Override
	public void render()
	{
		Gdx.gl.glClearColor(1, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

		switch (state)
		{
			case SELECTTILE:
			case DRAW:
			case MOVE:
				batch.begin();
				// draw boards
				batch.draw(boardBg, 0, 0, 360, 360);
				for (Tile[] row : board)
					for (Tile tile : row)
						tile.draw(batch);

				// draw players
				for (Player p : players)
					p.draw(batch);
				batch.end();
				break;
			case END:
				break;
			default:
				reset();
		}

	}

	public void reset()
	{
		create();
	}

	@Override
	public void dispose()
	{
		batch.dispose();
	}
}
