#include <iostream>
#include <string>

using namespace std;

struct Node {
	string food;
	Node *left;
	Node *right;
};

/* Добавяне на нов елемент */
void addFood(const int atLevel, Node **T, const string food, int &currentLevel) {
	if (currentLevel == atLevel) {
		if (*T == NULL) {
			*T = new Node;
			(*T)->food = food;
			(*T)->left = NULL;
			(*T)->right = NULL;
			currentLevel++;
		}
	}
	else if (currentLevel < atLevel) {
		if (*T == NULL) {
			*T = new Node;
			(*T)->food = "";
			(*T)->left = NULL;
			(*T)->right = NULL;
		}
		currentLevel++;
		addFood(atLevel, &(*T)->left, food, currentLevel);
		addFood(atLevel, &(*T)->right, food, currentLevel);
		if (currentLevel <= atLevel) {
			// ако не е намерено място - връщане назад с 1 ниво
			currentLevel--;
		}
	}
}

/* Извеждане на храните на Зайо Байо */
void printFoods(Node *T) {
	if (T == NULL)
		return;
	if (T->left == NULL && T->right == NULL) {
		cout << T->food << endl;
	}
	printFoods(T->left);
	printFoods(T->right);
}

/* Търсене на храна и намиране на пътя до нея */
bool findFood(Node *T, string food, string &path) {
	if (T == NULL)
		return false;
	if (T->food == food) {
		return true;
	}
	if (findFood(T->left, food, path)) {
		path = "left " + path;
		return true;
	}
	if (findFood(T->right, food, path)) {
		path = "right " + path;
		return true;
	}

	return false;
}

int main() {
	Node *root = NULL;

	string path = "";
	int startLevel = 0;
	const int addAtLevel = 5;

	string food;
	int choice;

	do {
		cout << "[1] Add new food" << endl;
		cout << "[2] Print all foods" << endl;
		cout << "[3] Find food" << endl;
		cout << "[0] Exit" << endl;
		cout << " -  choice: ";
		cin >> choice;
		cin.sync();
		system("cls");

		switch (choice) {
		case 1:
			cout << "Food: ";
			cin >> food;
			startLevel = 0;
			addFood(addAtLevel, &root, food, startLevel);
			if (startLevel <= addAtLevel) {
				cout << "No free space!" << endl;
			}
			break;
		case 2:
			printFoods(root);
			break;
		case 3:
			cout << "Food: ";
			cin >> food;
			path = "";
			if (findFood(root, food, path)) {
				cout << path << endl;
			}
			else {
				cout << "Not exists!" << endl;
			}
			break;
		}
		cout << endl;
	} while (choice != 0);

	return 0;
}