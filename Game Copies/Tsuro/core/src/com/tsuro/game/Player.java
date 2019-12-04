package com.tsuro.game;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class Player
{
	public static Texture playerPic;

	private Tile[] tiles = new Tile[3];
	private int row, col;// 0-23  y,  0-11  x

	public Player(int row, int col)
	{
		playerPic = new Texture("assets/Player.png");
		this.row = row;
		this.col = col;
	}

	public void draw(SpriteBatch batch)
	{
		batch.draw(playerPic, col%12==0?*8, row*, 7, 7);
	}
}
