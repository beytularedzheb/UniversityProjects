#include <iostream>
#include <string>

using namespace std;

const char emptyNodeChar = ' ';

struct Node {
	char value;
	Node *left;
	Node *right;
};

/* �������� �� ��� ������� */
void add(Node **T, string message, int currentCharIndex) {
	if (currentCharIndex < message.length()) {
		if (*T == NULL) {
			*T = new Node;
			(*T)->value = emptyNodeChar;
			(*T)->left = NULL;
			(*T)->right = NULL;
		}
		switch (toupper(message[currentCharIndex])) {
		case 'L':
			add(&(*T)->left, message, ++currentCharIndex);
			break;
		case 'R':
			add(&(*T)->right, message, ++currentCharIndex);
			break;
		default:
			if ((*T)->value != emptyNodeChar) {
				cout << endl << "\t������� \'" 
					<< (*T)->value << "\' � ����������!" << endl;
			}
			(*T)->value = message[currentCharIndex];
			break;
		}
	}
}

/* ��������� �� ������ ����� ������ ������� */
void print(Node *T) {
	if (T) {
		if (T->value != emptyNodeChar && !T->left && !T->right) {
			cout << T->value;
		}
		
		print(T->left);
		print(T->right);
	}
}

/* �������� ���� �� ������ �����, ����� �� �� ����� */
void numberOfNodesWithouLeaves(Node *T, int &sum) {
	if (T) {
		if (T->left || T->right) {
			sum++;
		}
		numberOfNodesWithouLeaves(T->left, sum);
		numberOfNodesWithouLeaves(T->right, sum);
	}
}

/* ��������� �� ���� ���� ������� �� ������ ����� */
void printRootToLeavesPaths(Node* T, string path, char currentTree) {
	if (T == NULL)
		return;

	if (T->value == emptyNodeChar) {
		if (currentTree == 'l' || currentTree == 'r') {
			path += currentTree;
		}
	}
	else {
		path += currentTree;
		path += T->value;
	}

	/* ��� ���� � ����� ���������� ���� �� ���� */
	if (T->left == NULL && T->right == NULL) {
		cout << path << endl;
	}
	else {
		/* ����� ����������� ��������� */
		printRootToLeavesPaths(T->left, path, 'l');
		printRootToLeavesPaths(T->right, path, 'r');
	}
}

/* ������ �������� */
int main() {
	setlocale(LC_ALL, "bgr");
	Node *root = NULL;
	int choice;
	int sum = 0;
	string path = "";
	string message;

	do {
		cout << "[1] �������� �� ��� ���" << endl;
		cout << "[2] ��������� �� ������� ������-�������" << endl;
		cout << "[3] ���� �����, ����� �� �� �����" << endl;
		cout << "[4] ��������� �� ���� ���� ������� �� ������ �����" << endl;
		cout << "[0] �����" << endl;
		cout << " -  �����: ";
		cin >> choice;
		cin.sync();

		switch (choice) {
		case 1:
			cout << "������� ����: ";
			cin >> message;
			add(&root, message, 0);
			break;
		case 2:
			print(root);
			break;
		case 3:
			sum = 0;
			numberOfNodesWithouLeaves(root, sum);
			cout << sum << endl;
			break;
		case 4:
			path = "";
			printRootToLeavesPaths(root, path, emptyNodeChar);
			break;
		}
		cout << endl;
	} while (choice != 0);
	
	return 0;
}