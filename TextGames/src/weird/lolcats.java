package weird;

import java.util.Scanner;

public class lolcats
{
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);
		System.out.println("Hello.\nMy name is Mr. Meow, and I will be your guide today.\nWhat is your name?");
		String name = scan.nextLine();
		System.out.println("Hi " + name);

		scan.close();
	}
}
