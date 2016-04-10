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

/* Добавяне на нов елемент */
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

/* Намиране на минималния елемент в дърво */
Node* findMin(Node *T) {
	while (T->left) {
		T = T->left;
	}
	return T;
}

/* Изтриване на зададен елемент от дървото */
void remove(Node **T, string word) {
	if (NULL == *T) {
		return;
	}
	else {
		if (word < (*T)->word)
			remove(&(*T)->left, word);
		else if (word >(*T)->word)
			remove(&(*T)->right, word);
		else {/* елементът за изключване е намерен */
			if ((*T)->left && (*T)->right) {/* върхът има два наследника */
											/* намира се върхът за размяна */
				Node *replace = findMin((*T)->right);
				(*T)->word = replace->word;
				remove(&(*T)->right, (*T)->word); /* върхът се изключва */
			}
			else { /* елементът има нула или едно поддървета */
				Node *temp = *T;
				if ((*T)->left)
					*T = (*T)->left;
				else
					*T = (*T)->right;
				delete temp;
				removed = true; // глобална променлива
			}
		}
	}
}

/* Търсене на елемент в двоично дърво */
Node* search(Node *T, string word) {
	if (T) {
		if (word == T->word) /* елементът е намерен */
			return T;
		else if (word < T->word)
			return search(T->left, word);
		else
			return search(T->right, word);
	}
	else return NULL;
}

/* Извеждане на думите, започващи със зададен низ */
void print_start_with(Node *T, string word)
{
	if (T)
	{
		print_start_with(T->left, word);
		if (T->word.find(word) == 0)
		{
			cout << "Дума: " << T->word
				<< ", Честота на срещане: " << T->counter
				<< endl;
		}
		print_start_with(T->right, word);
	}
}

/* Извеждане на дървото в азбучен ред */
void print(Node *T)
{
	if (T)
	{
		print(T->left);
		cout << "Дума: " << T->word
			<< ", Честота на срещане: " << T->counter
			<< endl;
		print(T->right);
	}
}

/* Главна програма */
int main()
{
	setlocale(LC_ALL, "bgr");
	Node *root = NULL, *node;
	int choice;
	string text, word;
	istringstream  iss;

	do {
		cout << "[1] Добавяне на нова дума" << endl;
		cout << "[2] Извеждане на речника в азбучен ред" << endl;
		cout << "[3] Извеждане на думите, започващи със зададен низ" << endl;
		cout << "[4] Проверка за принадлежност / актуализация на брояча" << endl;
		cout << "[5] Изтриване на елемент" << endl;
		cout << "[0] Изход" << endl;
		cout << " -  Избор: ";
		cin >> choice;
		cin.sync();
		system("cls");

		switch (choice) {
		case 1:
			cout << "Задайте дума: ";
			cin >> word;
			add(&root, word);
			break;
		case 2:
			print(root);
			cout << endl;
			break;
		case 3:
			cout << "Задайте символният низ: ";
			cin >> word;
			print_start_with(root, word);
			cout << endl;
			break;
		case 4:
			cin.ignore();
			cout << "Задайте текст: ";
			getline(cin, text);
			iss.str(text);

			while (iss >> word)
			{
				node = search(root, word);
				if (node)
				{
					node->counter++;
					cout << endl << "Броячът на " << node->word << " е инкрементиран!" << endl;
				}
				else
				{
					cout << endl << word << " не е намерен!" << endl;
				}
			}
			break;
		case 5:
			cout << "Задайте думата за изтриване: ";
			cin >> word;
			removed = false;
			remove(&root, word);
			if (removed == true)
			{
				cout << endl << "Думата е изтрита!" << endl;
			}
			else
			{
				cout << endl << "Думата не е намерена в речника!" << endl;
			}
			break;
		}
		cout << endl;
	} while (choice != 0);

	return 0;
}