#include <iostream>
#include <string>

using namespace std;

const char emptyNodeChar = ' ';

struct Node {
	char value;
	Node *left;
	Node *right;
};

/* Добавяне на нов елемент */
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
				cout << endl << "\tВъзелът \'" 
					<< (*T)->value << "\' е презаписан!" << endl;
			}
			(*T)->value = message[currentCharIndex];
			break;
		}
	}
}

/* Извеждане на всички ЛИСТА отляво надясно */
void print(Node *T) {
	if (T) {
		if (T->value != emptyNodeChar && !T->left && !T->right) {
			cout << T->value;
		}
		
		print(T->left);
		print(T->right);
	}
}

/* Намиране броя на всички възли, които не са листа */
void numberOfNodesWithouLeaves(Node *T, int &sum) {
	if (T) {
		if (T->left || T->right) {
			sum++;
		}
		numberOfNodesWithouLeaves(T->left, sum);
		numberOfNodesWithouLeaves(T->right, sum);
	}
}

/* Извеждане на пътя през дървото до всички листа */
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

	/* ако това е листо отпечатвай пътя до него */
	if (T->left == NULL && T->right == NULL) {
		cout << path << endl;
	}
	else {
		/* иначе продължавай търсенето */
		printRootToLeavesPaths(T->left, path, 'l');
		printRootToLeavesPaths(T->right, path, 'r');
	}
}

/* Главна програма */
int main() {
	setlocale(LC_ALL, "bgr");
	Node *root = NULL;
	int choice;
	int sum = 0;
	string path = "";
	string message;

	do {
		cout << "[1] Добавяне на нов низ" << endl;
		cout << "[2] Извеждане на листата отляво-надясно" << endl;
		cout << "[3] Брой бъзли, които не са листа" << endl;
		cout << "[4] Извеждане на пътя през дървото до всички листа" << endl;
		cout << "[0] Изход" << endl;
		cout << " -  Избор: ";
		cin >> choice;
		cin.sync();

		switch (choice) {
		case 1:
			cout << "Задайте низа: ";
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