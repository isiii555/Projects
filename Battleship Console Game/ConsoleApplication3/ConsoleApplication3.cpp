#include <iostream>
#include <windows.h> 
using namespace std;

#pragma region Colors

enum Colors
{
	Green = 2,
	Black = 0,
	White = 7,
	Aqua = 3,
	Purple = 5,
	Red = 4
};


void changeColor(int y) {
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hConsole, y);
}
#pragma endregion

#pragma region introFunc
void introFunc() {
	string intro = "\t\t\t\tWelcome to battleship game!\n";
	for (int i = 0; i < intro[i]; i++) {

		cout << intro[i];

		Sleep(100);
	}
	cout << "\n\t\t\t\t";
	system("pause");
}
#pragma endregion

#pragma region FillBoardFunction

void fillBoard(char arr[10][10]) {
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			arr[i][j] = char(254);
		}
	}
}
#pragma endregion

#pragma region checkareaFunction

bool checkarea(char arr[10][10], int x, int y, int boatsize, char updown, char vertichoriz) {
	bool check = false;
	if (vertichoriz == 'v' || vertichoriz == 'V') {
		if (updown == 'u' || updown == 'U') {
			for (int i = x; i > x - boatsize; i--) {
				if (arr[i][y] == char(254)) {
					check = true;
					if (y + 1 <= 9) {
						if (arr[i][y + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (y - 1 >= 0) {
						if (arr[i][y - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i + 1 <= 9) {
						if (arr[i + 1][y] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (y + 1 <= 9 && i + 1 <= 9) {
						if (arr[i + 1][y + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i + 1 <= 9 && y - 1 >= 0) {
						if (arr[i + 1][y - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0) {
						if (arr[i - 1][y] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0 && y + 1 <= 9) {
						if (arr[i - 1][y + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0 && y - 1 >= 0) {
						if (arr[i - 1][y - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
				}
				else
					return false;
			}
		}
		else if (updown == 'd' || updown == 'D') {
			for (int i = x; i < x + boatsize; i++) {

				if (arr[i][y] == char(254)) {
					check = true;
					if (y + 1 <= 9) {
						if (arr[i][y + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (y - 1 >= 0) {
						if (arr[i][y - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i + 1 <= 9) {
						if (arr[i + 1][y] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (y + 1 <= 9 && i + 1 <= 9) {
						if (arr[i + 1][y + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i + 1 <= 9 && y - 1 >= 0) {
						if (arr[i + 1][y - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0) {
						if (arr[i - 1][y] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0 && y + 1 <= 9) {
						if (arr[i - 1][y + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0 && y - 1 >= 0) {
						if (arr[i - 1][y - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
				}
				else
					return false;
			}
		}
	}
	else if (vertichoriz == 'h' || vertichoriz == 'H') {
		if (updown == 'u' || updown == 'U') {
			for (int i = y; i < y + boatsize; i++) {
				if (arr[x][i] == char(254) && y + boatsize < 10) {
					check = true;
					if (i + 1 <= 9) {
						if (arr[x][i + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0) {
						if (arr[x][i - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x + 1 <= 9) {
						if (arr[x + 1][i] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i + 1 <= 9 && x + 1 <= 9) {
						if (arr[x + 1][i + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x + 1 <= 9 && i - 1 >= 0) {
						if (arr[x + 1][i - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x - 1 >= 0) {
						if (arr[x - 1][i] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x - 1 >= 0 && i + 1 <= 9) {
						if (arr[x - 1][i + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x - 1 >= 0 && i - 1 >= 0) {
						if (arr[x - 1][i - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
				}
				else
					return false;
			}
		}
		else if (updown == 'd' || updown == 'D') {
			for (int i = y; i > y - boatsize; i--)
			{
				if (arr[x][i] == char(254) && y - boatsize >= 0) {
					check = true;
					if (i + 1 <= 9) {
						if (arr[x][i + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i - 1 >= 0) {
						if (arr[x][i - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x + 1 <= 9) {
						if (arr[x + 1][i] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (i + 1 <= 9 && x + 1 <= 9) {
						if (arr[x + 1][i + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x + 1 <= 9 && i - 1 >= 0) {
						if (arr[x + 1][i - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x - 1 >= 0) {
						if (arr[x - 1][i] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x - 1 >= 0 && i + 1 <= 9) {
						if (arr[x - 1][i + 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
					if (x - 1 >= 0 && i - 1 >= 0) {
						if (arr[x - 1][i - 1] == char(254)) {
							check = true;
						}
						else
							return false;
					}
					else
						check = true;
				}
				else
					return false;
			}
		}
	}
	return check;
}
#pragma endregion

#pragma region fillBoatFunction

bool fillBoat(char arr[10][10], char arr2[10][10], char vertichoriz, char updown, int x, int y, int boatsize) {
	if (vertichoriz == 'v' || vertichoriz == 'V') {
		if (updown == 'u' || updown == 'U') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = x; i > x - boatsize; i--)
				{
					arr[i][y] = char(83);
					arr2[i][y] = char(83);
				}
				return true;
			}
			else {
				cout << "\nYou entered wrong cordinates! Please enter correct cordinates" << endl;
				return false;
			}
		}
		else if (updown == 'd' || updown == 'U') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = x; i < x + boatsize; i++)
				{
					arr[i][y] = char(83);
					arr2[i][y] = char(83);
				}
				return true;
			}
			else {
				cout << "\nYou entered wrong cordinates! Please enter correct cordinates" << endl;
				return false;
			}
		}
	}
	else if (vertichoriz == 'h' || vertichoriz == 'H') {
		if (updown == 'u' || updown == 'U') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = y; i < y + boatsize; i++)
				{
					arr[x][i] = char(83);
					arr2[x][i] = char(83);
				}
				return true;
			}
			else {
				cout << "\nYou entered wrong cordinates! Please enter correct cordinates" << endl;
				return false;
			}
		}
		else if (updown == 'd' || updown == 'D') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = y; i > y - boatsize; i--)
				{
					arr[x][i] = char(83);
					arr2[x][i] = char(83);
				}
				return true;
			}
			else {
				cout << "\nYou entered wrong cordinates! Please enter correct cordinates" << endl;
				return false;
			}
		}
	}
}
#pragma endregion

#pragma region fillboatuser

bool fillBoatRandomUser(char arr[10][10], char arr2[10][10], char vertichoriz, char updown, int x, int y, int boatsize) {
	if (vertichoriz == 'v') {
		if (updown == 'u') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = x; i > x - boatsize; i--)
				{
					arr[i][y] = char(83);
					arr2[i][y] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
		else if (updown == 'd') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = x; i < x + boatsize; i++)
				{
					arr[i][y] = char(83);
					arr2[i][y] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
	}
	else if (vertichoriz == 'h') {
		if (updown == 'u') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = y; i < y + boatsize; i++)
				{
					arr[x][i] = char(83);
					arr2[x][i] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
		else if (updown == 'd') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = y; i > y - boatsize; i--)
				{
					arr[x][i] = char(83);
					arr2[x][i] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
	}
}
#pragma endregion

#pragma region fillBoatRandomFunction

bool fillBoatRandom(char arr[10][10], char vertichoriz, char updown, int x, int y, int boatsize) {
	if (vertichoriz == 'v') {
		if (updown == 'u') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = x; i > x - boatsize; i--)
				{
					arr[i][y] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
		else if (updown == 'd') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = x; i < x + boatsize; i++)
				{
					arr[i][y] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
	}
	else if (vertichoriz == 'h') {
		if (updown == 'u') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = y; i < y + boatsize; i++)
				{
					arr[x][i] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
		else if (updown == 'd') {
			if (checkarea(arr, x, y, boatsize, updown, vertichoriz)) {
				for (int i = y; i > y - boatsize; i--)
				{
					arr[x][i] = char(83);
				}
				return true;
			}
			else {
				return false;
			}
		}
	}
}

#pragma endregion

#pragma region printBoardFunction

void printBoard(char arr[10][10], char arr2[10][10]) {
	system("cls");
	char num[10]{ 'A','B','C','D','E','F','G','H','I','J' };
	cout << "  0 1 2 3 4 5 6 7 8 9 \t  0 1 2 3 4 5 6 7 8 9" << endl;
	for (int i = 0; i < 10; i++)
	{
		cout << num[i] << " ";
		for (int j = 0; j < 10; j++)
		{
			if (arr[i][j] == char(72)) {
				changeColor(Green);
				cout << arr[i][j] << " ";
				changeColor(White);

			}
			else if (arr[i][j] == char(77)) {
				changeColor(Red);
				cout << arr[i][j] << " ";
				changeColor(White);
			}
			else
				cout << arr[i][j] << " ";
		}
		cout << "\t";
		cout << num[i] << " ";
		for (int j = 0; j < 10; j++)
		{
			if (arr2[i][j] == char(72)) {
				changeColor(Green);
				cout << arr2[i][j] << " ";
				changeColor(White);

			}
			else if (arr2[i][j] == char(77)) {
				changeColor(Red);
				cout << arr2[i][j] << " ";
				changeColor(White);
			}
			else
				cout << arr2[i][j] << " ";
		}
		cout << endl;
	}
}
#pragma endregion

#pragma region hitShip

bool hitShip(char arr[10][10], char arr3[10][10], int x, int y, int& bots, char arr2[10][10]) {
	if (arr[x][y] == char(83)) {
		if (y + 1 <= 9) {
			if (arr[x][y + 1] != char(72) && arr[x][y + 1] != char(83) && arr[x][y + 1] != char(77))
			{
				arr[x][y + 1] = char(248);
			}
		}
		if (y - 1 >= 0) {
			if (arr[x][y - 1] != char(72) && arr[x][y - 1] != char(83) && arr[x][y - 1] != char(77))
			{
				arr[x][y - 1] = char(248);
			}
		}
		if (x + 1 <= 9) {
			if (arr[x + 1][y] != char(72) && arr[x + 1][y] != char(83) && arr[x + 1][y] != char(77))
			{
				arr[x + 1][y] = char(248);
			}
		}
		if (x + 1 <= 9 && y - 1 >= 0) {
			if (arr[x][y - 1] != char(72) && arr[x][y - 1] != char(83) && arr[x][y - 1] != char(77))
			{
				arr[x][y - 1] = char(248);
			}
		}
		if (x + 1 <= 9 && y + 1 <= 9) {
			if (arr[x + 1][y + 1] != char(72) && arr[x + 1][y + 1] != char(83) && arr[x + 1][y + 1] != char(77))
			{
				arr[x + 1][y + 1] = char(248);
			}
		}
		if (x - 1 >= 0) {
			if (arr[x - 1][y] != char(72) && arr[x - 1][y] != char(83) && arr[x - 1][y] != char(77))
			{
				arr[x - 1][y] = char(248);
			}
		}
		if (x - 1 >= 0 && y + 1 <= 9) {
			if (arr[x - 1][y + 1] != char(72) && arr[x - 1][y + 1] != char(83) && arr[x - 1][y + 1] != char(77))
			{
				arr[x - 1][y + 1] = char(248);
			}
		}
		if (x - 1 >= 0 && y - 1 >= 0) {
			if (arr[x - 1][y - 1] != char(72) && arr[x - 1][y - 1] != char(83) && arr[x - 1][y - 1] != char(77))
			{
				arr[x - 1][y - 1] = char(248);
			}
		}
		arr[x][y] = char(72);
		arr3[x][y] = char(72);
		changeColor(Green);
		cout << "Bot hit ship, cordinates (X): " << char(x + 65) << " (Y): " << y << endl;
		changeColor(White);
		printBoard(arr3, arr2);
		bots--;
		return true;
	}
	else if (arr[x][y] == char(254) || arr[x][y] == char(248)) {
		arr[x][y] = char(77);
		arr3[x][y] = char(77);
		return false;
	}
	else if (arr[x][y] == char(77))
		return true;
}

#pragma endregion

#pragma region hitShipBotFunction

bool hitShipBot(char arr[10][10], char arr2[10][10], int x, int y) {
	if (arr[x][y] == char(83)) {
		arr[x][y] = char(72);
		arr2[x][y] = char(72);
		return true;
	}
	else if (arr[x][y] == char(254)) {
		arr[x][y] = char(77);
		arr2[x][y] = char(77);
		return false;
	}
	else if (arr[x][y] == char(72)) {
		return false;
	}
	else if (arr[x][y] == char(77))
		return false;
}

#pragma endregion

#pragma region checkHitFunction

void checkHit(char arr[10][10], int& x, int& y, int& brain) {
	bool find = false;
	while (true) {
		if (y + 1 <= 9) {
			if (arr[x][y + 1] == char(83)) {
				y = y + 1;
				brain++;
				find = true;
				break;
			}

			else if (arr[x][y + 1] != char(72) && arr[x][y + 1] != char(83) && arr[x][y + 1] != char(77)) {
				arr[x][y + 1] = char(248);
			}
		}
		if (y - 1 >= 0) {
			if (arr[x][y - 1] == char(83)) {
				y = y - 1;
				brain++;
				find = true;
				break;
			}
			else if (arr[x][y - 1] != char(72) && arr[x][y - 1] != char(83) && arr[x][y - 1] != char(77))
				arr[x][y - 1] = char(248);
		}
		if (x - 1 >= 0) {
			if (arr[x - 1][y] == char(83)) {
				x = x - 1;
				brain++;
				find = true;
				break;
			}
			else if (arr[x - 1][y] != char(72) && arr[x - 1][y] != char(83) && arr[x - 1][y] != char(77))
				arr[x - 1][y] = char(248);
		}
		if (x + 1 <= 9) {
			if (arr[x + 1][y] == char(83)) {
				x = x + 1;
				brain++;
				find = true;
				break;
			}
			else if (arr[x + 1][y] != char(72) && arr[x + 1][y] != char(83) && arr[x + 1][y] != char(77))
				arr[x + 1][y] = char(248);
		}
		if (x + 1 <= 9 && y + 1 <= 9) {
			if (arr[x + 1][y + 1] == char(83)) {
				x = x + 1;
				y = y + 1;
				brain++;
				find = true;
				break;
			}
			else if (arr[x + 1][y + 1] != char(72) && arr[x + 1][y + 1] != char(83) && arr[x + 1][y + 1] != char(77))
				arr[x + 1][y + 1] = char(248);
		}
		if (x + 1 <= 9 && y - 1 >= 0) {
			if (arr[x + 1][y - 1] == char(83)) {
				x = x + 1;
				y = y - 1;
				brain++;
				find = true;
				break;
			}
			else if (arr[x + 1][y - 1] != char(72) && arr[x + 1][y - 1] != char(83) && arr[x + 1][y - 1] != char(77))
				arr[x + 1][y - 1] = char(248);
		}
		if (x - 1 >= 0 && y + 1 <= 9) {
			if (arr[x - 1][y + 1] == char(83)) {
				x = x - 1;
				y = y + 1;
				brain++;
				find = true;
				break;
			}
			else if (arr[x - 1][y + 1] != char(72) && arr[x - 1][y + 1] != char(83) && arr[x - 1][y + 1] != char(77))
				arr[x - 1][y + 1] = char(248);
		}
		if (x - 1 >= 0 && y - 1 >= 0) {
			if (arr[x - 1][y - 1] == char(83)) {
				x = x - 1;
				y = y - 1;
				brain++;
				find = true;
				break;
			}
			else if (arr[x - 1][y - 1] != char(72) && arr[x - 1][y - 1] != char(83) && arr[x - 1][y - 1] != char(77))
				arr[x - 1][y - 1] = char(248);
		}
		break;
	}
	if (!find) {
		brain = 0;
	}
}
#pragma endregion

#pragma region MainFunction

int main() {
	introFunc();
	srand(time(0));
	const int size = 10;
	char choices[2] = { 'v','h' };
	char choicess[2] = { 'u' , 'd' };
	char userBoard[size][size]{};
	char userBoardS[size][size]{};
	char botBoard[size][size]{};
	char botBoardS[size][size]{};
	fillBoard(userBoard);
	fillBoard(userBoardS);
	fillBoard(botBoard);
	fillBoard(botBoardS);
	printBoard(userBoardS, botBoard);
	int botShips = 30;
	int userShips = 30;
	int choice;
	int countboat = 14;
	int cell4 = 2;
	int cell3 = 3;
	int cell2 = 4;
	int cell1 = 5;
	int x;
	int y;
	char vh;
	char ud;
	int ship;
	int num = 0;
	while (true) {
		cout << "\n1.Random fill" << endl;
		cout << "2.Manual fill" << endl;
		cin >> choice;
		if (choice == 1) {
			cout << "You selected random fill!" << endl;
			Sleep(1000);
			system("cls");
			printBoard(userBoardS, botBoard);
			while (countboat > 0) {
				if (num > 50 && countboat > 0) {
					fillBoard(userBoard);
					fillBoard(userBoardS);
					num = 0;
					countboat = 14;
					cell4 = 2;
					cell3 = 3;
					cell2 = 4;
					cell1 = 5;
				}
				if (cell4 > 0) {
					ship = 4;
				}
				else if (cell3 > 0) {
					ship = 3;
				}
				else if (cell2 > 0) {
					ship = 2;
				}
				else if (cell1 > 0) {
					ship = 1;
				}
				vh = choices[rand() % 2];
				ud = choicess[rand() % 2];
				x = rand() % 9;
				y = rand() % 9;
				switch (ship) {
				case 1:
					if (cell1 > 0) {
						if (fillBoatRandomUser(userBoard, userBoardS, vh, ud, x, y, ship) && cell1 > 0) {
							countboat--;
							cell1--;
						}
						else
							num++;
					}
					break;
				case 2:
					if (cell2 > 0) {
						if (fillBoatRandomUser(userBoard, userBoardS, vh, ud, x, y, ship) && cell2 > 0) {
							cell2--;
							countboat--;
						}
						else
							num++;
					}
					break;
				case 3:
					if (cell3 > 0) {
						if (fillBoatRandomUser(userBoard, userBoardS, vh, ud, x, y, ship) && cell3 > 0) {
							cell3--;
							countboat--;
						}
						else
							num++;
					}
					break;
				case 4:
					if (cell4 > 0) {
						if (fillBoatRandomUser(userBoard, userBoardS, vh, ud, x, y, ship) && cell4 > 0) {
							countboat--;
							cell4--;
						}
						else
							num++;
					}
					break;
				}
			}
			num = 0;
			countboat = 14;
			cell4 = 2;
			cell3 = 3;
			cell2 = 4;
			cell1 = 5;
			srand(time(0));
			while (countboat > 0) {
				if (num > 50 && countboat > 0) {
					fillBoard(botBoardS);
					num = 0;
					countboat = 14;
					cell4 = 2;
					cell3 = 3;
					cell2 = 4;
					cell1 = 5;
				}
				if (cell4 > 0) {
					ship = 4;
				}
				else if (cell3 > 0) {
					ship = 3;
				}
				else if (cell2 > 0) {
					ship = 2;
				}
				else if (cell1 > 0) {
					ship = 1;
				}
				vh = choices[rand() % 2];
				ud = choicess[rand() % 2];
				x = rand() % 9;
				y = rand() % 9;
				switch (ship) {
				case 1:
					if (cell1 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell1 > 0) {
							countboat--;
							cell1--;
						}
						else
							num++;
					}
					break;
				case 2:
					if (cell2 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell2 > 0) {
							cell2--;
							countboat--;
						}
						else
							num++;
					}
					break;
				case 3:
					if (cell3 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell3 > 0) {
							cell3--;
							countboat--;
						}
						else
							num++;
					}
					break;
				case 4:
					if (cell4 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell4 > 0) {
							countboat--;
							cell4--;
						}
						else
							num++;
					}
					break;
				}
			}
			printBoard(userBoardS, botBoard);
			cout << "Finished!" << endl;
		}
		else if (choice == 2) {
			cout << "You selected manual fill!" << endl;
			Sleep(1000);
			system("cls");
			printBoard(userBoardS, botBoard);
			char x;
			int x1;
			while (countboat > 0) {
				bool choice1 = true;
				cout << "Which ship do you want to place?\n";
				cout << "\n1.1cell : " << cell1;
				cout << "\n2.2cell : " << cell2;
				cout << "\n3.3cell : " << cell3;
				cout << "\n4.4cell : " << cell4 << endl;
				while (true) {
					cout << "\nEnter your choice : ";
					cin >> ship;
					if (ship < 1 || ship > 4)
					{
						choice1 = false;
						printBoard(userBoardS, botBoard);
						break;
					}
					cout << "Vertical or horizontal ?(v/h)";
					cin >> vh;
					if (vh != 'v' && vh != 'h' && vh != 'V' && vh != 'H')
					{
						choice1 = false;
						printBoard(userBoardS, botBoard);
						break;
					}
					cout << "Upright or downleft ?(u/d)";
					cin >> ud;
					if (ud != 'u' && ud != 'U' && ud != 'd' && ud != 'D')
					{
						choice1 = false;
						printBoard(userBoardS, botBoard);
						break;
					}
					cout << "Enter pos(x)(A-J)";
					cin >> x;
					if (!((int(x) >= 65 && int(x) <= 74) || (int(x) >= 97 && int(x) <= 106))) {
						choice1 = false;
						printBoard(userBoardS, botBoard);
						break;
					}
					if (int(x) <= 74) {
						x1 = int(x) - 65;
					}
					else
						x1 = int(x) - 97;
					cout << "Enter pos(y)(0-9)";
					cin >> y;
					if (y < 0 || y > 9)
					{
						choice1 = false;
						printBoard(userBoardS, botBoard);
						break;
					}
					break;
				}
				if (choice1 == false) {
					continue;
				}
				switch (ship) {
				case 1:
					if (fillBoat(userBoard, userBoardS, vh, ud, x1, y, ship) && cell1 > 0) {
						printBoard(userBoardS, botBoard);
						cell1--;
						countboat--;
					}
					else if (cell1 <= 0) {
						cout << "You can't place 1cell ship anymore";
					}
					break;
				case 2:
					if (fillBoat(userBoard, userBoardS, vh, ud, x1, y, ship) && cell2 > 0) {
						printBoard(userBoardS, botBoard);
						cell2--;
						countboat--;
					}
					else if (cell2 <= 0) {
						cout << "You can't place 2cell ship anymore";
					}
					break;
				case 3:
					if (fillBoat(userBoard, userBoardS, vh, ud, x1, y, ship) && cell3 > 0) {
						printBoard(userBoardS, botBoard);
						cell3--;
						countboat--;
					}
					else if (cell3 <= 0) {
						cout << "You can't place 3cell ship anymore";
					}
					break;
				case 4:
					if (fillBoat(userBoard, userBoardS, vh, ud, x1, y, ship) && cell4 > 0) {
						printBoard(userBoardS, botBoard);
						cell4--;
						countboat--;
					}
					else if (cell4 <= 0) {
						cout << "You can't place 4cell ship anymore";
					}
					break;
				}
			}
			countboat = 14;
			cell4 = 2;
			cell3 = 3;
			cell2 = 4;
			cell1 = 5;
			srand(time(0));
			while (countboat > 0) {
				int x;
				ship = rand() % 4 + 1;
				vh = choices[rand() % 2];
				ud = choicess[rand() % 2];
				x = rand() % 9;
				y = rand() % 9;
				switch (ship) {
				case 1:
					if (cell1 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell1 > 0) {
							printBoard(userBoardS, botBoard);
							countboat--;
							cell1--;
						}
						else
							num++;
					}
					break;
				case 2:
					if (cell2 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell2 > 0) {
							printBoard(userBoardS, botBoard);
							cell2--;
							countboat--;
						}
						else
							num++;
					}
					break;
				case 3:
					if (cell3 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell3 > 0) {
							printBoard(userBoardS, botBoard);
							cell3--;
							countboat--;
						}
						else
							num++;
					}
					break;
				case 4:
					if (cell4 > 0) {
						if (fillBoatRandom(botBoardS, vh, ud, x, y, ship) && cell4 > 0) {
							printBoard(userBoardS, botBoard);
							countboat--;
							cell4--;
						}
						else
							num++;
					}
					break;
				}
			}
			cout << "Finished!";
			break;
		}
		else {
			cout << "Wrong choice!";
			Sleep(1000);
			system("cls");
			printBoard(userBoardS, botBoard);
			continue;
		}
		bool step = true;
		bool while1 = true;
		char x;
		int y;
		int x1;
		int x2;
		int brain = 0;
		while (userShips > 0 && botShips > 0) {
			srand(time(0));
			bool choice1 = true;
			if (while1) {
				while (true) {
					while (true) {
						cout << "Enter pos(x)(A-J)";
						cin >> x;
						if (!((int(x) >= 65 && int(x) <= 74) || (int(x) >= 97 && int(x) <= 106))) {
							choice1 = false;
							printBoard(userBoardS, botBoard);
							break;
						}
						if (int(x) <= 74) {
							x1 = int(x) - 65;
						}
						else
							x1 = int(x) - 97;
						cout << "Enter pos(y)(0-9)";
						cin >> y;
						if (y < 0 || y > 9)
						{
							choice1 = false;
							printBoard(userBoardS, botBoard);
							break;
						}
						break;
					}
					if (choice1 == false) {
						continue;
					}
					else
						break;
				}
			}
			else {
				if (brain == 0) {
					x2 = rand() % 9;
					y = rand() % 9;
				}
				else {
					checkHit(userBoard, x2, y, brain);
					if (brain == 0) {
						x2 = rand() % 9;
						y = rand() % 9;
					}
				}
			}
			while (while1) {
				if (hitShipBot(botBoardS, botBoard, x1, y)) {
					step = true;
					printBoard(userBoardS, botBoard);
					botShips--;
					break;
				}
				else {
					step = false;
					changeColor(Red);
					cout << "There is no ship where you hit!" << endl;
					changeColor(White);
					Sleep(3000);
					printBoard(userBoardS, botBoard);
					break;
				}
			}
			while (!while1) {
				if (hitShip(userBoard, userBoardS, x2, y, userShips, botBoard)) {
					step = false;
					if (userBoard[x2][y] == char(72))
					{
						brain++;
					}
					break;
				}
				else {
					changeColor(Red);
					cout << "Bot could not hit ship!" << endl;
					cout << "Cordinates (X): " << char(x2 + 65) << " (Y): " << y << endl;
					changeColor(White);
					step = true;
					Sleep(3000);
					printBoard(userBoardS, botBoard);
					break;
				}
			}
			if (step) {
				while1 = true;
			}
			else
				while1 = false;
		}
		if (userShips == 0) {
			Sleep(2000);
			system("cls");
			string intro = "ALL YOUR SHIPS ARE DESTROYED!BOT WIN GAME!";
			for (int i = 0; i < 43; i++) {

				cout << intro[i];

				Sleep(100);
			}
			break;
		}
		else if (botShips == 0) {
			Sleep(2000);
			system("cls");
			string intro = "ALL BOT'S SHIPS ARE DESTROYED!YOU WIN GAME!";
			for (int i = 0; i < 44; i++) {

				cout << intro[i];

				Sleep(100);
			}
			break;
		}
	}
}
#pragma endregion