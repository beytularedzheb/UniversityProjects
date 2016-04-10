#include <iostream>
#include <string>

using namespace std;

#define ONE_DIM	1
#define TWO_DIM	2
#define INS		3
#define DEL		4

struct myArrItem
{
	int a;		// ���� 1 � ��� �
	string b;	// ���� 2 � ��� b
	float c;	// ���� 3 � ��� c
	string d;	// ���� 4 � ��� d
};

myArrItem *oneDimArr; // ���������� �����
myArrItem **twoDimArr; // �������� �����
int rows; // ���� ������ �� ��������� �����
int cols; // ���� ������ �� ��������� �����
int sizeOneDimArr; // ������ �� ���������� �����

// ������� �� ��������� �� ����� (�������� / ���������)
void PrintArray(int choiceDim)
{
	// ��� � ������ ����������� ����� �� �����
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
	// ��� � ������ ���������� ����� �� �����
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
	// ������ �����
	else
	{
		cout << endl << "Wrong dimension of the array!" << endl;
	}
}


// ������� �� ��������� �� ���������� �� ���������
void ReadTwoDimArr()
{
	// ��������� �� ������
	for (int row = 0; row < rows; row++)
	{
		// ��������� �� ������
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

// ������� �� ��������� �� �������� �����
void Create�woDimArray()
{
	// ��������� ������� �� ��������� (��������� �����)
	cout << "Please enter the number of the array's rows: ";
	cin >> rows;
	
	// ��� ������� � ��������, �.� �����������
	if (rows > 0)
	{
		// �������� �� ����� �� ��������
		twoDimArr = new myArrItem *[rows];
	
		// �������� ���� ��� ���������� �����
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
				// �������� �� ����� �� ��������
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

// ������� �� �������������� �� �������, �����
// �� ����� ������� ������:
// ��������� � ����������
void FreeArrays()
{
	// ������������� �� �������, ����� �� �������� �� ��������� �����
	if (cols > 0)
	{
		for (int index = 0; index < rows; index++)
		{
			delete[] twoDimArr[index];
		}
		cols = 0;
	}
	// ������������� �� �������, ����� �� �������� �� ��������� �����
	if (rows > 0)
	{
		delete[] twoDimArr;
		rows = 0;
	}

	// ������������� �� �������, ����� �� ���������� �����
	if (sizeOneDimArr > 0)
	{
		delete[] oneDimArr;
		sizeOneDimArr = 0;
	}
}


// ������� �� ����������� �� ���������� � ������� ��������
// �� ������ '�' �� ��������� ����� � ��������� �����
void TransferToOneDimArr()
{
	// �������� �� ���������� ������ � "���-�����" ������ 
	// ���� �� � rows * cols, � ������ �� ���������� �� ������
	// '�' �� ������ �������� �� ��������� ����� � �������.

	sizeOneDimArr = rows * cols;
	// ��������� �� �������� ��������� ����� � ���������� �������� ������
	myArrItem *bufferArray = new myArrItem[sizeOneDimArr];

	int index = 0; // ������ �� ���������� ����� (�����)

	// ����������� �� ����������, ���������� �� ���������� �������
	// ��� ��������� �����
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

	// ��� ��� ���� 1 ���������� �������
	if (index > 0)
	{
		sizeOneDimArr = index;

		// ��������� �� ��������� ����� � ������ ���� ��������
		oneDimArr = new myArrItem[sizeOneDimArr];

		// �������� �� ���������� � ������
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

	// ������������� �� �������, ����� �� ��������� �����
	delete[] bufferArray;
}

// ������� �� �������� ������-������������� �� � � �
// ��� �� 3 ������� �� b ��� ������� '&'
void PrintAverageOfAC()
{
	// ������-�����������
	double average = 0;
	// ����
	double sum = 0;
	// ������ ���������� �� �������� ���� ��� ���� 1
	// �������, ��������� �� ���������� �������
	bool flag = false;

	for (int index = 0; index < sizeOneDimArr; index++)
	{
		// ��� ����� � � ������� >= 4 � �� 3-�� ������� ��� ������� '&'
		// ����� ���� �� � � ������� < 4 - ������ �� ����� ���� ��������!
		if (oneDimArr[index].b.length() >= 4 && oneDimArr[index].b[3] == '&')
		{
			flag = true;

			sum += oneDimArr[index].a;
			sum += oneDimArr[index].c;

			// ����������� �� ������-�������������
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

	// ��� � �������� �������� �����, �.� 0 ��� ��-������
	if (numElements > -1)
	{
		// ��� ��� ���� 22 �������� � 22-�� ������� ��� ���
		// � ��� "������" / "Petrov"
		if (sizeOneDimArr >= 22 && 
			(oneDimArr[21].b == "Petrov" || 
			 oneDimArr[21].d == "Petrov" ||
			 oneDimArr[21].b == "������" ||
			 oneDimArr[21].d == "������"))
		{
			// �������� �� ����� �� ����� �����
			int size;
			// ��� � ������� ���������� ��������
			if (insOrDel == INS)
			{
				size = sizeOneDimArr + numElements;
			}
			// ��� � ������� ���������� ��������� � ��� ����������
			// �� ���� �������� �� ���������
			else if (insOrDel == DEL && (sizeOneDimArr - 12 > numElements))
			{
				size = sizeOneDimArr - numElements;
			}
			// ������ ����� ��� ���� ���������� �� ����
			// �������� �� ���������
			else
			{
				cout << "\n\rNot as many items for deletion "
					<< "as you set!" << endl;
				system("pause");
				return;
			}

			// �������� �� �����
			myArrItem *bufferArray = new myArrItem[size];

			// �������� �� ������� 12 �������� �� ��������
			// ����� ��� ��������� �����
			for (int index = 0; index < 12; index++)
			{
				bufferArray[index].a = oneDimArr[index].a;
				bufferArray[index].b = oneDimArr[index].b;
				bufferArray[index].c = oneDimArr[index].c;
				bufferArray[index].d = oneDimArr[index].d;
			}
			
			if (insOrDel == INS)
			{
				// ��������� �� numElements �� ���� ��������
				// �� ������������ ��� ��������� �����
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

				// �������� �� ������ �������� ���� 12-��
				// �� �������� ��� ��������� �����
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
				// ���������� numElements �� ���� ��������
				// ���� 12-�� � �������� �� ����������
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
			// ������������� �� �������, ����� �� �������� �����
			delete[] oneDimArr;
			// �������� �� ����� �� �������� �����
			// (������� � ����������)
			oneDimArr = new myArrItem[sizeOneDimArr];

			// �������� �� ���������� �� ��������� �����
			// � ��������
			for (int index = 0; index < sizeOneDimArr; index++)
			{
				oneDimArr[index].a = bufferArray[index].a;
				oneDimArr[index].b = bufferArray[index].b;
				oneDimArr[index].c = bufferArray[index].c;
				oneDimArr[index].d = bufferArray[index].d;
			}

			// ������������� �� �������, ����� �� 
			// ��������� �����
			delete[] bufferArray;
		}
		else
		{
			// ��� ���� 22 ��� ������ ��������
			if (sizeOneDimArr < 22)
			{
				cout << endl << "Not a sufficient number (22) of "
					<< "elements in the array!" << endl;
			}
			// ��� ��� 22 ��� ������ ��������, �� 22-�� �������
			// ���� ��� � ��� "������" / "Petrov"
			else
			{
				cout << endl << "b and d of the 22nd element is " 
					<< "not equal to \"Petrov\"" << endl;
			}
		}
	}
	// ��� � �������� ����������� �����
	else
	{
		cout << endl << "The number of elements must be 0 "
			<< "or greater!" << endl;
	}
}

// ������� �� ��������� �� ��������� �����
// � �������� ��� �� ������ �� ���.
// ������� �� ������� �� ���������� ��
// ������ �
void ShellSort(myArrItem x[], int n)
{
	int h = 0, i, j, next;
	myArrItem y;

	//�������� ������� (���-������) ������
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
			// ��� ���� � ������� ���� ��������, ����� �� �� 
			// ������� ������ � ���������� �� �� �������
			// �������� (�� �� �������� �������)
			if (!isSelectedCreate)
			{
				isSelectedCreate = true;

				Create�woDimArray();
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
			// ��� ���� � ������� ���� ��������, ����� �� �� 
			// ������� ������ � ���������� �� �� �������
			// �������� (�� �� �������� �������)
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
			// ���������� �� ���������
			system("cls");
			break;
		} // end swich
	} // end do-while
	while (choice != 0);

	FreeArrays();

	system("pause");
}