#include <iostream>
#include <string.h>
#include <stdlib.h>
using namespace std;

typedef struct Subscriber
{
	string firstName;
	string familyName;
	char phoneNumber[9];
	Subscriber *next;
} *TelephoneBook;

TelephoneBook listHead;

void AddToList(TelephoneBook Head)
{
	TelephoneBook P, Pprev, Q;
	P = Head->next;
	Pprev = Head;

	string firstName, familyName;
	char number[9];

	cout << "First name: ";
	getline(cin, firstName);
	cout << "Family name: ";
	getline(cin, familyName);
	cout << "Telephone number: ";
	cin.getline(number, 9);

	while (P && P->familyName.compare(familyName) < 0){
		Pprev = P;
		P = P->next;
	}

	Q = new Subscriber;
	Q->firstName = firstName;
	Q->familyName = familyName;
	strcpy(Q->phoneNumber, number);
	Q->next = P;
	Pprev->next = Q;
}

void SearchSubscriber(TelephoneBook Head, char telNumber[9])
{
	if (Head)
	{
		bool isExist = false;
		while (Head)
		{
			if (strcmp(Head->phoneNumber, telNumber) == 0)
			{
				cout << endl << "First name: " << Head->firstName;
				cout << endl << "Family name: " << Head->familyName;
				cout << endl << "Telephone number: " << Head->phoneNumber;
				cout << endl;
				isExist = true;
			}

			Head = Head->next;
		}

		if (!isExist)
		{
			cout << endl << "Doesn't exist!" << endl;
		}
	}
	else
	{
		cout << endl << "The telephone book is empty!" << endl;
	}

	cout << endl;
}

void NumberOfSubscribersWithFamily(TelephoneBook Head)
{
	if (Head)
	{
		int count = 1, max = 0;
		string maxFamilyName = "";

		do
		{
			if (Head->next && Head->familyName.compare(Head->next->familyName) == 0)
			{
				count++;
			}
			else if (max < count)
			{
				maxFamilyName = Head->familyName;
				max = count;
				count = 1;
			}

			Head = Head->next;
		} 
		while (Head);

		cout << endl << maxFamilyName << ": " << max << endl;
	}
	else
	{
		cout << endl << "The telephone book is empty!" << endl;
	}

	cout << endl;
}

void PrintBook(TelephoneBook Head)
{
	if (Head)
	{
		while (Head)
		{
			cout << endl << "Family name: " << Head->familyName;
			cout << endl << "First name: " << Head->firstName;
			cout << endl << "Telephone number: " << Head->phoneNumber;
			cout << endl;

			Head = Head->next;
		}
	}
	else
	{
		cout << endl << "The telephone book is empty!" << endl;
	}

	cout << endl;
}

int main()
{
	listHead = NULL;
	listHead = new Subscriber;
	listHead->next = NULL;

	short choice;

	do
	{
		system("cls");
		cout << "1 - Add subscriber in telephone book." << endl;
		cout << "2 - Find subscriber/s by telephone number." << endl;
		cout << "3 - Find the number of the subscribers with maximal family." << endl;
		cout << "4 - Print telephone book alphabetically by family name." << endl;
		cout << "0 - Exit." << endl;
		cin >> choice;
		cin.sync();

		switch (choice)
		{
		case 1:
			AddToList(listHead);
			break;
		case 2:
			char number[9];
			cout << "Telephone number: ";
			cin.getline(number, 9);
			SearchSubscriber(listHead->next, number);
			system("pause");
			break;
		case 3:
			NumberOfSubscribersWithFamily(listHead->next);
			system("pause");
			break;
		case 4:
			PrintBook(listHead->next);
			system("pause");
			break;
		case 0:
			return 0;
			break;
		}
	} 
	while (true);
}
