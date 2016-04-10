#include <stdio.h>
#include <iostream>
#include <string.h>
#include <stdlib.h>

using namespace std;

//Дефиниране на дървото
struct Country {
	string Name;         //Име на държавата
	unsigned long Population;          //Брой население
	Country *left, *right;
}

*root = NULL;

//Въвеждане на държави в дървото
void create(string name, unsigned long population, Country *&rootTree) {
	if (rootTree == NULL) {               //Ако няма въведени държави
		rootTree = new Country;           //се създава коренът 
		rootTree->Name = name;
		rootTree->Population = population;
		rootTree->left = rootTree->right = NULL;
	}
	else if (name < rootTree->Name) {  //Проверява се дали нововъведената е по-голяма от корена
		create(name, population, rootTree->left);    //Ако да - се записва отляво 
	}
	else if (name > rootTree->Name) {
		create(name, population, rootTree->right); //В противен случай - вдясно 
	}
	else {
		cout << "\n Вече съществува такава държава!\n";
		return;
	}
}

//Извеждане на информацията за всички държави
void print(Country *rootTree) {
	if (rootTree) {                       //Ако дървото съществува
		print(rootTree->left);           //отпечатваме във възходящ ред
		cout << "\n Име: " << rootTree->Name 
			 << "; население: " << rootTree->Population;
		print(rootTree->right);
	}
}

//Търсене на държава
Country * search(string name, Country *rootTree) {
	if (rootTree == NULL)
		return NULL;
	else if (name == rootTree->Name) {
		return rootTree;
	}
	else if (name < rootTree->Name) {
		return search(name, rootTree->left);
	}
	else if (name > rootTree->Name) {
		return search(name, rootTree->right);
	}
}

//Промяна информацията за дадена държава
void change(string name, Country *rootTree) {
	Country *result = search(name, rootTree);
	if (result) {
		cout << "\n Въведете население: ";
		cin >> result->Population;
		cout << "\n Данните са редактирани!";
	}
	else {
		cout << "\n Държавата не е намерена!";
	}
}

void search2(char start, char end, Country *rootTree) {

	if (rootTree == NULL) {
		return;
	}
	if (toupper(start) < toupper(rootTree->Name[0])) {
		search2(start, end, rootTree->left);
	}
	if (toupper(start) <= toupper(rootTree->Name[0]) && toupper(end) >= toupper(rootTree->Name[0])) {
		cout << "\n Държава: " << rootTree->Name << ", население: " << rootTree->Population;
	}
	if (toupper(end) > toupper(rootTree->Name[0])) {
		search2(start, end, rootTree->right); 
	}
}

int main() {
	//system("chcp 1251"); // кирилица - Visual С++
	setlocale(LC_ALL, "BGR"); // кирилица - DEV C++
	char c1, ch1, ch2;
	string name;
	unsigned long pop;	
	int c;
	
	do {
		cout << "\n==========================================================";
		cout << "\nМеню с възможните операции:";
		cout << "\n 1. Добавяне;";
		cout << "\n 2. Извеждане на всички налични държави;";
		cout << "\n 3. Извеждане на информацията за дадена държава;";
		cout << "\n 4. Промяна на информацията за дадена държава;";
		cout << "\n 5. Извеждане на държави в определен азбучен интервал и техния брой.";
		cout << "\n==========================================================";
		cout << "\n Изберете операция или 0 за край: ";
		cin >> c;
		
		switch (c) {
			case 1: {
				do {
					cout << "Въведете името на държавата: ";
					cin >> name;
					cout << "Въведете броя на населението: ";
					cin >> pop;
					create(name, pop, root);
					cout << "Ще въвеждате ли? (y/n): ";
					cin >> c1;
				} while (toupper(c1) != 'N');
				break;
			}
			case 2: print(root); break;
			case 3: {
				cin.sync();
				cout << "Въведете името на държавата: ";
				cin >> name;
				
				Country * result = search(name, root);
				if (result != NULL) {
					cout << "\n Държава: " << result->Name 
						 << ", население: " << result->Population;
				}
				else {
					cout << "\n Държавата не е намерана!";
				}
				 break;	
			}
			case 4: {
				cout << "Въведете името на държавата за редактиране: ";
				cin >> name;
				change(name, root);
				break;
			}
			case 5: {
				cout << "Въведи началото на интервала: ";
				cin >> ch1;
				cout << "Въведи края на интервала: ";
				cin >> ch2;
				while (ch1 >= ch2) {
					cout << "Въведи края на интервала: ";
					cin >> ch2;
				}
				if (root) {
					search2(ch1, ch2, root);
				}
				break;
			}
		}
	} while (c != 0);
	
	system("pause");
	return 0;
}
