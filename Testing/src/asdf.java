import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;
import java.util.StringTokenizer;

public class asdf
{
	public static void main(String[] args) throws IOException
	{
		Random rand = new Random();
		BufferedReader f = new BufferedReader(new FileReader("Map.txt"));
		StringTokenizer st;

		int[][] map = new int[50][50];
		for (int i = 0; i < 50; i++)
		{
			st = new StringTokenizer(f.readLine());
			for (int j = 0; j < 50; j++)
				map[i][j] = Integer.parseInt(st.nextToken());
		}

		// for (int i = 0; i < rand.nextInt(10000); i++)
		// map[rand.nextInt(50)][rand.nextInt(50)] = 2;
		// for (int i = 0; i < 50; i++)
		// for (int j = 0; j < 50; j++)
		// map[i][j] = rand.nextInt(4);
		// for (int i = 0; i < 7; i++)
		// map[rand.nextInt(50)][rand.nextInt(50)] = 5 + i;
		// for (int i = 0; i < 50; i++)
		// for (int j = 0; j < 50; j++)
		// {
		// int a = rand.nextInt(100);
		// if (a < 30)
		// map[i][j] = 1;
		// else if (a < 60)
		// map[i][j] = 0;
		// else if (a < 75)
		// map[i][j] = 2;
		// else
		// map[i][j] = 3;
		// }

		PrintWriter out = new PrintWriter(new BufferedWriter(new FileWriter("Map2.txt")));
		out.print("{");
		for (int i = 0; i < 50; i++)
		{
			out.print("{");
			for (int j = 0; j < 49; j++)
				out.print(2 + ",");
			out.println(map[i][49] + "},");
			// for (int j = 0; j < 50; j++)
			// out.print(map[i][j] + " ");
			// out.println();
		}
		out.print("}");
		out.close();
		f.close();

	}
}
