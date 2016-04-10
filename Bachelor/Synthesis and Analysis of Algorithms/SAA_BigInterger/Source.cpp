#include <iostream>
using namespace std;

typedef struct Number
{
	unsigned short digit;
	Number *prev, *next;
} *BigInteger;

BigInteger firstNumber, secondNumber;

void CreateBigInteger(BigInteger &numberList, const char *strNumber)
{
	BigInteger p, last;

	numberList = new Number;
	numberList->digit = (unsigned short)strNumber[0] - 48;
	numberList->next = numberList;
	numberList->prev = numberList;
	p = new Number;

	for (int i = 1; i < strlen(strNumber); i++, p = p->next)
	{
		if (i == 1)
		{
			numberList->next = p;
			numberList->prev = p;
			p->prev = numberList;
			p->next = NULL;
		}

		last = new Number;
		p->digit = (unsigned short)strNumber[i] - 48;
		p->next = last;
		last->prev = p;

		if (i == (strlen(strNumber) - 1))
		{
			p->next = numberList;
			numberList->prev = p;
		}
	}
}

void PrintNumber(BigInteger number)
{
	if (number)
	{
		BigInteger q = number;

		do 
		{
			cout << q->digit;
			q = q->next;
		} 
		while (q != number);
	}

	cout << endl;
}

int Compare(BigInteger firstNum, BigInteger secondNum)
{
	BigInteger f = firstNum;
	BigInteger s = secondNum;

	if (f && s)
	{
		int compareDigit = 0;
		do
		{
			if (compareDigit == 0)
			{
				if (f->digit > s->digit)
				{
					compareDigit = 1;
				}
				else if (f->digit < s->digit)
				{
					compareDigit = -1;
				}
				else
				{
					compareDigit = 0;
				}
			}

			f = f->next;
			s = s->next;
		} 
		while (f != firstNum && s != secondNum);

		if (f == firstNum && s == secondNum)
		{
			return compareDigit;
		}
		else if (f == firstNum && s != secondNum)
		{
			return -1;
		}
		else
		{
			return 1;
		}
	}

	return 2;
}

BigInteger Multiplication(unsigned short intNumber, BigInteger bigNumber)
{
	if (bigNumber)
	{
		BigInteger result = NULL, q = bigNumber;
		string strResult = "";
		char charDigit[2];
		int buffer, carry = 0;

		if (intNumber != 0)
		{
			do
			{
				q = q->prev;
				buffer = q->digit * intNumber + carry;

				if (buffer > 9)
				{
					_itoa_s(buffer % 10, charDigit, 10);
					carry = buffer / 10;
				}
				else
				{
					_itoa_s(buffer, charDigit, 10);
					carry = 0;
				}

				strResult = charDigit + strResult;
			} 
			while (q != bigNumber);

			if (carry != 0)
			{
				_itoa_s(carry, charDigit, 10);
				strResult = charDigit + strResult;
			}
		}
		else
		{
			strResult = "0";
		}

		CreateBigInteger(result, strResult.c_str());
		
		return result;
	}

	return NULL;
}

BigInteger Sum(BigInteger firstNum, BigInteger secondNum)
{
	if (firstNum && secondNum)
	{
		int carry = 0;
		int buffer;
		char charDigit[2];
		string strResult = "";
		BigInteger result = NULL;
		BigInteger f = firstNum;
		BigInteger s = secondNum;

		f = f->prev;
		s = s->prev;
		buffer = f->digit + s->digit;
		carry = (buffer > 9) ? 1 : 0;
		_itoa_s(buffer % 10, charDigit, 10);
		strResult = charDigit; 

		while (f != firstNum || s != secondNum)
		{
			if (f != firstNum && s != secondNum)
			{
				f = f->prev;
				s = s->prev;
				buffer = f->digit + s->digit + carry;
			}
			else if (f == firstNum && s != secondNum)
			{
				s = s->prev;
				buffer = s->digit + carry;
			}
			else if (f != firstNum && s == secondNum)
			{
				f = f->prev;
				buffer = f->digit + carry;
			}

			carry = (buffer > 9) ? 1 : 0;
			_itoa_s(buffer % 10, charDigit, 10);
			strResult = charDigit + strResult;
		}

		if (carry == 1)
		{
			_itoa_s(carry, charDigit, 10);
			strResult = charDigit + strResult;
		}

		CreateBigInteger(result, strResult.c_str());

		return result;
	}

	return NULL;
}

int main()
{
	firstNumber = NULL;
	secondNumber = NULL;

	/*********************** READ INPUT ***************************/
	char strFirtsNumber[71];
	char strSecondNumber[71];

	cout << "Please enter first integer number: ";
	cin >> strFirtsNumber;
	// проверка дали не е въведен празен символ, защото потребителят има възможност
	// да въвежда стойност null (\0) чрез клавишната комбинация Ctrl + Z.
	if (strlen(strFirtsNumber) > 0)
	{
		CreateBigInteger(firstNumber, strFirtsNumber);
	}
	else
	{
		cout << "Invalid input!";
		return 0;
	}

	cout << "Please enter second integer number: ";
	cin >> strSecondNumber;
	if (strlen(strSecondNumber) > 0)
	{
	CreateBigInteger(secondNumber, strSecondNumber);
	}
	else
	{
		cout << "Invalid input!";
		return 0;
	}
	cout << "N1 = ";
	PrintNumber(firstNumber);
	cout << "N2 = ";
	PrintNumber(secondNumber);

	/*********************** COMPARE ******************************/
	int compareResult = Compare(firstNumber, secondNumber);
	switch (compareResult)
	{
		case -1:
			cout << "N1 < N2" << endl;
			break;
		case 0:
			cout << "N1 = N2" << endl;
			break;
		case 1:
			cout << "N1 > N2" << endl;
			break;
		default:
			cout << "Some number not exist!" << endl;
			break;
	}

	/*********************** MULTIPLICATION ***************************/
	unsigned short intNum;
	cout << "Please enter an integer number (0..9): ";
	cin >> intNum;

	cout << intNum << " * N1 = ";
	PrintNumber(Multiplication(intNum, firstNumber));

	/********************** SUM ***************************************/
	cout << "N1 + N2 = ";
	PrintNumber(Sum(firstNumber, secondNumber));

	/********************** EXPRESSION *********************************/
	cout << "(2 * N1) + (3 * N2) = ";
	PrintNumber(Sum(Multiplication(2, firstNumber), Multiplication(3, secondNumber)));

	cout << endl;
	return 0;
}