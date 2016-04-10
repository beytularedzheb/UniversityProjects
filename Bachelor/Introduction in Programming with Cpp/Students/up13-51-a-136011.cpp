#include <iostream>
#include <string>

using namespace std;

#define ONE_DIM	1
#define TWO_DIM	2
#define INS		3
#define DEL		4

struct myArrItem
{
	int a;		// поле 1 с име а
	string b;	// поле 2 с име b
	float c;	// поле 3 с име c
	string d;	// поле 4 с име d
};

myArrItem *oneDimArr; // едномерене масив
myArrItem **twoDimArr; // двумерен масив
int rows; // брой редове на двумерния масив
int cols; // брой колони на двумерния масив
int sizeOneDimArr; // размер на едномерния масив

// функция за извеждане на масив (двумерен / едномерен)
void PrintArray(int choiceDim)
{
	// Ако е избран ЕДНОмерният масив за печат
	if (choiceDim == ONE_DIM)
	{
		for (int index = 0; index < sizeOneDimArr; index++)
		{
			cout << endl << "Item [" << index + 1 << "]" << endl;
			cout << oneDimArr[index].a << endl;
			cout << oneDimArr[index].b << endl;
			cout << oneDimArr[index].c << endl;
			cout << oneDimArr[index].d << endl;
		}
	}
	// Ако е избран ДВУмерният масив за печат
	else if (choiceDim == TWO_DIM)
	{
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				cout << endl << "Item [" << row + 1 << ", " << col + 1 << "]" << endl;
				cout << twoDimArr[row][col].a << endl;
				cout << twoDimArr[row][col].b << endl;
				cout << twoDimArr[row][col].c << endl;
				cout << twoDimArr[row][col].d << endl;
			}
		}
	}
	// Грешен избор
	else
	{
		cout << endl << "Wrong dimension of the array!" << endl;
	}
}


// функция за въвеждане на елементите на матрицата
void ReadTwoDimArr()
{
	// обхождане по редове
	for (int row = 0; row < rows; row++)
	{
		// обхождане по колони
		for (int col = 0; col < cols; col++)
		{
			cout << endl << "Item [" << row + 1 << ", " << col + 1 << "]" << endl;

			cout << "Please enter an integer number (a): ";
			cin >> twoDimArr[row][col].a;

			cin.sync();
			cout << "Please enter a string (b): ";
			getline(cin, twoDimArr[row][col].b);

			cout << "Please enter a floating point number (c): ";
			cin >> twoDimArr[row][col].c;

			cin.sync();
			cout << "Please enter a string (d): ";
			getline(cin, twoDimArr[row][col].d);
		}
	}
}

// функция за създаване на двумерен масив
void CreateТwoDimArray()
{
	// въвеждане размера на матрицата (двумерния масив)
	cout << "Please enter the number of the array's rows: ";
	cin >> rows;
	
	// Ако числото е коректно, т.е положително
	if (rows > 0)
	{
		// заделяне на памет за редовете
		twoDimArr = new myArrItem *[rows];
	
		// проверка дали има достатъчно памет
		if (twoDimArr == nullptr)
		{
			cout << endl << "Error: memory could not be allocated!" << endl;
			system("pause");
			exit(1);
		}
		else
		{
			cout << "Please enter the number of the array's columns: ";
			cin >> cols;

			if (cols > 0)
			{
				// заделяне на памет за колоните
				for (int index = 0; index < rows; index++)
				{
					twoDimArr[index] = new myArrItem[cols];
					if (twoDimArr[index] == nullptr)
					{
						cout << endl << "Error: memory could not be allocated!" << endl;
						system("pause");
						exit(1);
					}
				}
			}
			else
			{
				cout << endl << "Error: the number of the array's columns can't"
					<< " be negative or zero!" << endl;
			}
		}
	}
	else
	{
		cout << endl << "Error: the number of the array's rows can't"
			 << " be negative or zero!" << endl;
	}
}

// функция за осовобождаване на паметта, заета
// от двата основни масива:
// двумерния и едномерния
void FreeArrays()
{
	// освобождаване на паметта, заета от колоните на двумерния масив
	if (cols > 0)
	{
		for (int index = 0; index < rows; index++)
		{
			delete[] twoDimArr[index];
		}
		cols = 0;
	}
	// освобождаване на паметта, заета от редовете на двумерния масив
	if (rows > 0)
	{
		delete[] twoDimArr;
		rows = 0;
	}

	// освобождаване на паметта, заета от одномерния масив
	if (sizeOneDimArr > 0)
	{
		delete[] oneDimArr;
		sizeOneDimArr = 0;
	}
}


// функция за прехвърляне на елементите с нечетна стойност
// на полето 'а' на двумерния масив в едномерен масив
void TransferToOneDimArr()
{
	// размерът на едномерния масива в "най-лошия" случай 
	// може да е rows * cols, в случай че стойността на полето
	// 'а' на всички елементи на двумерния масив е нечетна.

	sizeOneDimArr = rows * cols;
	// създаване на временен едномерен масив с максимално възможен размер
	myArrItem *bufferArray = new myArrItem[sizeOneDimArr];

	int index = 0; // индекс на едномерния масив (брояч)

	// прехвърляне на елементите, отговарящи на зададеното условие
	// във временния масив
	for (int row = 0; row < rows; row++)
	{
		for (int col = 0; col < cols; col++)
		{
			if (twoDimArr[row][col].a % 2 != 0)
			{
				bufferArray[index].a = twoDimArr[row][col].a;
				bufferArray[index].b = twoDimArr[row][col].b;
				bufferArray[index].c = twoDimArr[row][col].c;
				bufferArray[index].d = twoDimArr[row][col].d;
				index++;
			}
		}
	}

	// Ако има поне 1 прехвърлен елемент
	if (index > 0)
	{
		sizeOneDimArr = index;

		// създаване на едномерен масив с нужния брой елементи
		oneDimArr = new myArrItem[sizeOneDimArr];

		// копиране на елементите в масива
		for (int i = 0; i < index; i++)
		{
			oneDimArr[i].a = bufferArray[i].a;
			oneDimArr[i].b = bufferArray[i].b;
			oneDimArr[i].c = bufferArray[i].c;
			oneDimArr[i].d = bufferArray[i].d;
		}

		cout << endl << "Ready!" << endl; 
	}
	else
	{
		cout << endl << "One-dimensional array is empty!" << endl;
		sizeOneDimArr = 0;
	}

	// освобождаване на паметта, заета от временния масив
	delete[] bufferArray;
}

// функция за печатане средно-аритметичното на а и с
// ако на 3 позиция на b има символа '&'
void PrintAverageOfAC()
{
	// средно-аритметично
	double average = 0;
	// сума
	double sum = 0;
	// Булева променлива за проверка дали има поне 1
	// елемент, отговарящ на зададеното условие
	bool flag = false;

	for (int index = 0; index < sizeOneDimArr; index++)
	{
		// Ако низът е с дължина >= 4 и на 3-та позиция има символа '&'
		// низът може да е с дължина < 4 - затова се прави тази проверка!
		if (oneDimArr[index].b.length() >= 4 && oneDimArr[index].b[3] == '&')
		{
			flag = true;

			sum += oneDimArr[index].a;
			sum += oneDimArr[index].c;

			// изчисляване на средно-аритметичното
			average = sum / 2.0;

			printf("\n\rItem [%d] Average: %.2f", index + 1, average);
		}
		sum = 0;
	}

	if (!flag)
	{
		cout << endl << "No items matching the condition!" << endl;
	}
}

void InsertDeleteItems(int insOrDel)
{
	int numElements;
	string msg = "How many elements you want to insert? ";

	if (insOrDel == DEL)
		msg = "How many elements you want to delete? ";

	cout << endl << msg;
	cin >> numElements;

	// ако е въведено коректно число, т.е 0 или по-голямо
	if (numElements > -1)
	{
		// ако има поне 22 елемента и 22-ят елемент има низ
		// с име "Петров" / "Petrov"
		if (sizeOneDimArr >= 22 && 
			(oneDimArr[21].b == "Petrov" || 
			 oneDimArr[21].d == "Petrov" ||
			 oneDimArr[21].b == "Петров" ||
			 oneDimArr[21].d == "Петров"))
		{
			// заделяне на памет за новия масив
			int size;
			// ако е избрана операцията вмъкване
			if (insOrDel == INS)
			{
				size = sizeOneDimArr + numElements;
			}
			// ако е избрана операцията изтриване и има достатъчно
			// на брой елементи за изтриване
			else if (insOrDel == DEL && (sizeOneDimArr - 12 > numElements))
			{
				size = sizeOneDimArr - numElements;
			}
			// грешен избор или няма достатъчно на брой
			// елементи за изтриване
			else
			{
				cout << "\n\rNot as many items for deletion "
					<< "as you set!" << endl;
				system("pause");
				return;
			}

			// заделяне на памет
			myArrItem *bufferArray = new myArrItem[size];

			// копиране на първите 12 елемента от основния
			// масив във временния масив
			for (int index = 0; index < 12; index++)
			{
				bufferArray[index].a = oneDimArr[index].a;
				bufferArray[index].b = oneDimArr[index].b;
				bufferArray[index].c = oneDimArr[index].c;
				bufferArray[index].d = oneDimArr[index].d;
			}
			
			if (insOrDel == INS)
			{
				// въвеждане на numElements на брой елемента
				// от клавиатурата във временния масив
				for (int index = 12; index < 12 + numElements; index++)
				{
					cout << endl << "Item [" << index - 11 << "]" << endl;

					cout << "Please enter an integer number (a): ";
					cin >> bufferArray[index].a;

					cin.sync();
					cout << "Please enter a string (b): ";
					getline(cin, bufferArray[index].b);

					cout << "Please enter a floating point number (c): ";
					cin >> bufferArray[index].c;

					cin.sync();
					cout << "Please enter a string (d): ";
					getline(cin, bufferArray[index].d);
				}

				// копиране на всички елементи след 12-ия
				// от основния във временния масив
				for (int index = 12; index < sizeOneDimArr; index++)
				{
					bufferArray[index + numElements].a = oneDimArr[index].a;
					bufferArray[index + numElements].b = oneDimArr[index].b;
					bufferArray[index + numElements].c = oneDimArr[index].c;
					bufferArray[index + numElements].d = oneDimArr[index].d;
				}

				cout << endl << "Inserted!" << endl;
			}
			else if (insOrDel == DEL)
			{
				// пропускане numElements на брой елемента
				// след 12-ия и копиране на следващите
				for (int index = 12 + numElements; index < sizeOneDimArr; index++)
				{
					bufferArray[index - numElements].a = oneDimArr[index].a;
					bufferArray[index - numElements].b = oneDimArr[index].b;
					bufferArray[index - numElements].c = oneDimArr[index].c;
					bufferArray[index - numElements].d = oneDimArr[index].d;
				}

				cout << endl << "Deleted!" << endl;
			}
			sizeOneDimArr = size;
			// освобождаване на паметта, заета от основния масив
			delete[] oneDimArr;
			// заделяне на памет за основния масив
			// (колкото е необходимо)
			oneDimArr = new myArrItem[sizeOneDimArr];

			// копиране на елементите от временния масив
			// в основния
			for (int index = 0; index < sizeOneDimArr; index++)
			{
				oneDimArr[index].a = bufferArray[index].a;
				oneDimArr[index].b = bufferArray[index].b;
				oneDimArr[index].c = bufferArray[index].c;
				oneDimArr[index].d = bufferArray[index].d;
			}

			// освобождаване на паметта, заета от 
			// временния масив
			delete[] bufferArray;
		}
		else
		{
			// ако няма 22 или повече елемента
			if (sizeOneDimArr < 22)
			{
				cout << endl << "Not a sufficient number (22) of "
					<< "elements in the array!" << endl;
			}
			// ако има 22 или повече елемента, но 22-ят елемент
			// няма низ с име "Петров" / "Petrov"
			else
			{
				cout << endl << "b and d of the 22nd element is " 
					<< "not equal to \"Petrov\"" << endl;
			}
		}
	}
	// ако е въведено отрицателно число
	else
	{
		cout << endl << "The number of elements must be 0 "
			<< "or greater!" << endl;
	}
}

// функция за сортиране на едномерен масив
// в низходящ ред по метода на Шел.
// Масивът се сортира по стойността на
// полето с
void ShellSort(myArrItem x[], int n)
{
	int h = 0, i, j, next;
	myArrItem y;

	//Намиране начална (най-голяма) стъпка
	while (2 * (next = 3 * h + 1) <= n) 
		h = next;

	for (; h > 0; h /= 3)
	{
		for (i = h; i < n; i++) {

			y.a = x[i].a; 
			y.b = x[i].b;
			y.c = x[i].c;
			y.d = x[i].d;

			j = i - h;
			while (j >= 0 && y.c > x[j].c)
			{
				x[j + h].a = x[j].a;
				x[j + h].b = x[j].b;
				x[j + h].c = x[j].c;
				x[j + h].d = x[j].d;
				j -= h;
			}
			x[j + h].a = y.a;
			x[j + h].b = y.b;
			x[j + h].c = y.c;
			x[j + h].d = y.d;
		}
	}
}


void main()
{
	int choice;
	bool isSelectedCreate = false;
	bool isSelectedTransfer = false;

	do
	{
		printf("\n\r");
		printf("%18s--------------------MENU------------------\n\r", "");
		printf("%25s1.   Create Two-Dimensional Array\n\r", "");
		printf("%25s2.   Print Two-Dimensional Array\n\r", "");
		printf("%25s3.   Transfer\n\r", "");
		printf("%25s4.   Print One-Dimensional Array\n\r", "");
		printf("%25s5.   Print - Condition 1\n\r", "");
		printf("%25s6.   Insert items\n\r", "");
		printf("%25s7.   Delete items\n\r", "");
		printf("%25s8.   Sort Array\n\r", "");
		printf("%25s9.   Delete Arrays\n\r", "");
		printf("%25s10.  Clear - Console\n\r", "");
		printf("%21sChoice operation or enter 0 for exit\n\r", "");
		printf("%18s------------------------------------------\n\r", "");
		printf("%18s", "");
		cin >> choice;
		getchar();

		switch (choice)
		{
/*****/	case 1:
			// ако вече е избрана тази операция, преди да се 
			// изпълни отново е необходимо да се изтрият
			// масивите (да се освободи паметта)
			if (!isSelectedCreate)
			{
				isSelectedCreate = true;

				CreateТwoDimArray();
				ReadTwoDimArr();
			}
			else
			{
				cout << endl << "First you must to delete "
					"the arrays! (choice 9)" << endl;
			}
			break;
/*****/	case 2:
			PrintArray(TWO_DIM);
			break;
/*****/ case 3:
			// ако вече е избрана тази операция, преди да се 
			// изпълни отново е необходимо да се изтрият
			// масивите (да се освободи паметта)
			if (!isSelectedTransfer)
			{
				TransferToOneDimArr();
				isSelectedTransfer = true;
			}
			else
			{
				cout << endl << "First you must to delete "
					"the arrays! (choice 9)" << endl;
			}
			break;
/*****/ case 4:
			PrintArray(ONE_DIM);
			break;
/*****/ case 5:
			PrintAverageOfAC();
			break;
/*****/ case 6:
			InsertDeleteItems(INS);
			break;
/*****/ case 7:
			InsertDeleteItems(DEL);
			break;
/*****/ case 8:
			ShellSort(oneDimArr, sizeOneDimArr);
			break;
/*****/ case 9:
			FreeArrays();
			isSelectedCreate = false;
			isSelectedTransfer = false;
			break;
/*****/ case 10:
			// изчистване на конзолата
			system("cls");
			break;
		} // end swich
	} // end do-while
	while (choice != 0);

	FreeArrays();

	system("pause");
}