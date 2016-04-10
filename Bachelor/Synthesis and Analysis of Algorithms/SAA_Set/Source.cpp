#include <iostream>
#include <string>

using namespace std;

typedef struct NizList{
	char niz[100];
	NizList *leftNext, *right;
} *ListTree;

ListTree firstListHead, secondListHead, 
		 unionList, sectionList;
ListTree treeRoot;

void AddToList(char str[100], ListTree LHead)
{
	ListTree P, Pprev, Q;
	P = LHead->leftNext;
	Pprev = LHead;

	while (P && strcmp(P->niz, str) < 0){
		Pprev = P;
		P = P->leftNext;
	}

	Q = new NizList;
	strcpy_s(Q->niz, str);
	Q->leftNext = P;
	Pprev->leftNext = Q;
}

int DeleteListItems(ListTree &LHead){
	unsigned int length, counter = 0;

	cout << "\nPlease enter a length: ";
	cin >> length;

	if (length > 0)
	{
		ListTree prv, tmp, pt = LHead;
		while (pt && strlen(pt->niz) > length)
		{
			tmp = pt->leftNext;
			delete pt;
			++counter;
			pt = tmp;
		}

		if ((LHead = pt) == 0)
		{
			return counter;
		}

		prv = pt;
		pt = pt->leftNext;

		while (pt)
		{
			if (strlen(pt->niz) > length)
			{
				tmp = prv->leftNext = pt->leftNext;
				delete pt;
				++counter;
				pt = tmp;
			}
			else 
			{
				prv = pt;
				pt = pt->leftNext;
			}
		} 

		return counter;
	} 
	else if (length <= 0)
	{
		cout << endl << "Incorrect input!" << endl;
	}
}

void PrintList(ListTree LHead)
{
	if (LHead)
	{
		cout << LHead->niz << endl;
		PrintList(LHead->leftNext);
	}
}

bool IsExist(ListTree LHead, char str[100])
{
	bool result = false;

	while (LHead)
	{
		if (strcmp(LHead->niz, str) == 0)
		{
			result = true;
			break;
		}

		LHead = LHead->leftNext;
	}

	return result;
}

void Union(ListTree &result, ListTree firstList, ListTree secondList)
{
	while (firstList)
	{
		AddToList(firstList->niz, result);
		firstList = firstList->leftNext;
	}

	while (secondList)
	{
		if (!IsExist(result, secondList->niz))
		{
			AddToList(secondList->niz, result);
		}
		
		secondList = secondList->leftNext;
	}
}

void Section(ListTree &result, ListTree firstList, ListTree secondList)
{
	ListTree listOne = firstList;
	ListTree listTwo = secondList;
	if (!listOne)
	{
		listOne = secondList;
		listTwo = firstList;
	}

	while (listOne)
	{
		if (IsExist(listTwo, listOne->niz))
		{
			AddToList(listOne->niz, result);
		}

		listOne = listOne->leftNext;
	}
}

void AddToTree(ListTree &tree, char niz[100])
{
	if (tree == NULL)
	{
		tree = new NizList;
		strcpy_s(tree->niz, niz);
		tree->leftNext = NULL;
		tree->right = NULL;
	}
	else if (strcmp(niz, tree->niz) < 0)
	{
		AddToTree(tree->leftNext, niz);
	}
	else if (strcmp(niz, tree->niz) > 0)
	{
		AddToTree(tree->right, niz);
	}
}

void GetItemsFromSetAndAddToTree(ListTree list, ListTree &tree)
{
	char niz[4];
	while (list)
	{
		if (strlen(list->niz) > 1)
		{
			niz[0] = list->niz[0];
			niz[1] = list->niz[1];
			niz[2] = list->niz[strlen(list->niz) - 1];
			niz[3] = '\0';
			AddToTree(tree, niz);
		}

		list = list->leftNext;
	}
}

void PrintTree(ListTree tree)
{
	if (tree)
	{
		PrintTree(tree->leftNext);
		cout << tree->niz << endl;
		PrintTree(tree->right);
	}
}

void Menu()
{
	firstListHead = NULL;
	firstListHead = new NizList;
	firstListHead->leftNext = NULL;
	secondListHead = NULL;
	secondListHead = new NizList;
	secondListHead->leftNext = NULL;
	unionList = NULL;
	unionList = new NizList;
	unionList->leftNext = NULL;
	sectionList = NULL;
	sectionList = new NizList;
	sectionList->leftNext = NULL;

	short choice;
	char niz[100];

	do
	{
		cout << "1 - Add item to first set." << endl;
		cout << "2 - Add item to second set." << endl;
		cout << "3 - Delete items from first set." << endl;
		cout << "4 - Delete items from second set." << endl;
		cout << "5 - Print first set." << endl;
		cout << "6 - Print second set." << endl;
		cout << "7 - Union." << endl;
		cout << "8 - Section." << endl;
		cout << "9 - Create Tree." << endl;
		cout << "0 - Exit" << endl;
		cin >> choice;

		switch (choice)
		{
			case 1:
				cout << "Please enter a string: ";
				cin >> niz;
				if (!IsExist(firstListHead->leftNext, niz))
				{
					AddToList(niz, firstListHead);
				}
				else
				{
					cout << endl << "This item already exist!" << endl;
					system("pause");
				}
				break;
			case 2:
				cout << "Please enter a string: ";
				cin >> niz;
				if (!IsExist(secondListHead->leftNext, niz))
				{
					AddToList(niz, secondListHead);
				}
				else
				{
					cout << endl << "This item already exist!" << endl;
					system("pause");
				}
				break;
			case 3:
				cout << DeleteListItems(firstListHead->leftNext) <<
					" items was deleted!" << endl;
				system("pause");
				break;
			case 4:
				cout << DeleteListItems(secondListHead->leftNext) <<
					" items was deleted!" << endl;
				system("pause");
				break;
			case 5:
				PrintList(firstListHead->leftNext);
				system("pause");
				break;
			case 6:
				PrintList(secondListHead->leftNext);
				system("pause");
				break;
			case 7:
				Union(unionList, firstListHead->leftNext, secondListHead->leftNext);
				PrintList(unionList->leftNext);
				system("pause");
				break;
			case 8:
				Section(sectionList, firstListHead->leftNext, secondListHead->leftNext);
				PrintList(sectionList->leftNext);
				system("pause");
				break;
			case 9:
				GetItemsFromSetAndAddToTree(secondListHead->leftNext, treeRoot);
				PrintTree(treeRoot);
				system("pause");
				break;
		}

		system("cls");
	} while (choice != 0);
}

int main()
{
	Menu();
	return 0;
}