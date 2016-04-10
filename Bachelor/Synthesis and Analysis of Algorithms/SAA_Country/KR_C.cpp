#include <stdio.h>
#include <iostream>
#include <string.h>
#include <stdlib.h>

using namespace std;

//���������� �� �������
struct Country {
	string Name;         //��� �� ���������
	unsigned long Population;          //���� ���������
	Country *left, *right;
}

*root = NULL;

//��������� �� ������� � �������
void create(string name, unsigned long population, Country *&rootTree) {
	if (rootTree == NULL) {               //��� ���� �������� �������
		rootTree = new Country;           //�� ������� ������� 
		rootTree->Name = name;
		rootTree->Population = population;
		rootTree->left = rootTree->right = NULL;
	}
	else if (name < rootTree->Name) {  //��������� �� ���� �������������� � ��-������ �� ������
		create(name, population, rootTree->left);    //��� �� - �� ������� ������ 
	}
	else if (name > rootTree->Name) {
		create(name, population, rootTree->right); //� �������� ������ - ������ 
	}
	else {
		cout << "\n ���� ���������� ������ �������!\n";
		return;
	}
}

//��������� �� ������������ �� ������ �������
void print(Country *rootTree) {
	if (rootTree) {                       //��� ������� ����������
		print(rootTree->left);           //����������� ��� �������� ���
		cout << "\n ���: " << rootTree->Name 
			 << "; ���������: " << rootTree->Population;
		print(rootTree->right);
	}
}

//������� �� �������
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

//������� ������������ �� ������ �������
void change(string name, Country *rootTree) {
	Country *result = search(name, rootTree);
	if (result) {
		cout << "\n �������� ���������: ";
		cin >> result->Population;
		cout << "\n ������� �� �����������!";
	}
	else {
		cout << "\n ��������� �� � ��������!";
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
		cout << "\n �������: " << rootTree->Name << ", ���������: " << rootTree->Population;
	}
	if (toupper(end) > toupper(rootTree->Name[0])) {
		search2(start, end, rootTree->right); 
	}
}

int main() {
	//system("chcp 1251"); // �������� - Visual �++
	setlocale(LC_ALL, "BGR"); // �������� - DEV C++
	char c1, ch1, ch2;
	string name;
	unsigned long pop;	
	int c;
	
	do {
		cout << "\n==========================================================";
		cout << "\n���� � ���������� ��������:";
		cout << "\n 1. ��������;";
		cout << "\n 2. ��������� �� ������ ������� �������;";
		cout << "\n 3. ��������� �� ������������ �� ������ �������;";
		cout << "\n 4. ������� �� ������������ �� ������ �������;";
		cout << "\n 5. ��������� �� ������� � ��������� ������� �������� � ������ ����.";
		cout << "\n==========================================================";
		cout << "\n �������� �������� ��� 0 �� ����: ";
		cin >> c;
		
		switch (c) {
			case 1: {
				do {
					cout << "�������� ����� �� ���������: ";
					cin >> name;
					cout << "�������� ���� �� �����������: ";
					cin >> pop;
					create(name, pop, root);
					cout << "�� ��������� ��? (y/n): ";
					cin >> c1;
				} while (toupper(c1) != 'N');
				break;
			}
			case 2: print(root); break;
			case 3: {
				cin.sync();
				cout << "�������� ����� �� ���������: ";
				cin >> name;
				
				Country * result = search(name, root);
				if (result != NULL) {
					cout << "\n �������: " << result->Name 
						 << ", ���������: " << result->Population;
				}
				else {
					cout << "\n ��������� �� � ��������!";
				}
				 break;	
			}
			case 4: {
				cout << "�������� ����� �� ��������� �� �����������: ";
				cin >> name;
				change(name, root);
				break;
			}
			case 5: {
				cout << "������ �������� �� ���������: ";
				cin >> ch1;
				cout << "������ ���� �� ���������: ";
				cin >> ch2;
				while (ch1 >= ch2) {
					cout << "������ ���� �� ���������: ";
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
