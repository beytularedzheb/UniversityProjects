#include <iostream>
#include <string>
#include <sstream>
using namespace std;

struct Node
{
	int counter;
	string word;
	Node *left;
	Node *right;
};

bool removed;

/* �������� �� ��� ������� */
void add(Node **T, string word) {
	if (*T == NULL) {
		*T = new Node;
		(*T)->word = word;
		(*T)->counter = 0;
		(*T)->left = NULL;
		(*T)->right = NULL;
	}
	else if (word < (*T)->word) {
		add(&(*T)->left, word);
	}
	else if (word >(*T)->word) {
		add(&(*T)->right, word);
	}
}

/* �������� �� ���������� ������� � ����� */
Node* findMin(Node *T) {
	while (T->left) {
		T = T->left;
	}
	return T;
}

/* ��������� �� ������� ������� �� ������� */
void remove(Node **T, string word) {
	if (NULL == *T) {
		return;
	}
	else {
		if (word < (*T)->word)
			remove(&(*T)->left, word);
		else if (word >(*T)->word)
			remove(&(*T)->right, word);
		else {/* ��������� �� ���������� � ������� */
			if ((*T)->left && (*T)->right) {/* ������ ��� ��� ���������� */
											/* ������ �� ������ �� ������� */
				Node *replace = findMin((*T)->right);
				(*T)->word = replace->word;
				remove(&(*T)->right, (*T)->word); /* ������ �� �������� */
			}
			else { /* ��������� ��� ���� ��� ���� ���������� */
				Node *temp = *T;
				if ((*T)->left)
					*T = (*T)->left;
				else
					*T = (*T)->right;
				delete temp;
				removed = true; // �������� ����������
			}
		}
	}
}

/* ������� �� ������� � ������� ����� */
Node* search(Node *T, string word) {
	if (T) {
		if (word == T->word) /* ��������� � ������� */
			return T;
		else if (word < T->word)
			return search(T->left, word);
		else
			return search(T->right, word);
	}
	else return NULL;
}

/* ��������� �� ������, ��������� ��� ������� ��� */
void print_start_with(Node *T, string word)
{
	if (T)
	{
		print_start_with(T->left, word);
		if (T->word.find(word) == 0)
		{
			cout << "����: " << T->word
				<< ", ������� �� �������: " << T->counter
				<< endl;
		}
		print_start_with(T->right, word);
	}
}

/* ��������� �� ������� � ������� ��� */
void print(Node *T)
{
	if (T)
	{
		print(T->left);
		cout << "����: " << T->word
			<< ", ������� �� �������: " << T->counter
			<< endl;
		print(T->right);
	}
}

/* ������ �������� */
int main()
{
	setlocale(LC_ALL, "bgr");
	Node *root = NULL, *node;
	int choice;
	string text, word;
	istringstream  iss;

	do {
		cout << "[1] �������� �� ���� ����" << endl;
		cout << "[2] ��������� �� ������� � ������� ���" << endl;
		cout << "[3] ��������� �� ������, ��������� ��� ������� ���" << endl;
		cout << "[4] �������� �� ������������� / ������������ �� ������" << endl;
		cout << "[5] ��������� �� �������" << endl;
		cout << "[0] �����" << endl;
		cout << " -  �����: ";
		cin >> choice;
		cin.sync();
		system("cls");

		switch (choice) {
		case 1:
			cout << "������� ����: ";
			cin >> word;
			add(&root, word);
			break;
		case 2:
			print(root);
			cout << endl;
			break;
		case 3:
			cout << "������� ���������� ���: ";
			cin >> word;
			print_start_with(root, word);
			cout << endl;
			break;
		case 4:
			cin.ignore();
			cout << "������� �����: ";
			getline(cin, text);
			iss.str(text);

			while (iss >> word)
			{
				node = search(root, word);
				if (node)
				{
					node->counter++;
					cout << endl << "������� �� " << node->word << " � �������������!" << endl;
				}
				else
				{
					cout << endl << word << " �� � �������!" << endl;
				}
			}
			break;
		case 5:
			cout << "������� ������ �� ���������: ";
			cin >> word;
			removed = false;
			remove(&root, word);
			if (removed == true)
			{
				cout << endl << "������ � �������!" << endl;
			}
			else
			{
				cout << endl << "������ �� � �������� � �������!" << endl;
			}
			break;
		}
		cout << endl;
	} while (choice != 0);

	return 0;
}