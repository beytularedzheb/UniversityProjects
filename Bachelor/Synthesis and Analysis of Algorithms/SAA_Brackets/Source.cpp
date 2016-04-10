#include <iostream>
#include <string>
using namespace std;

typedef struct Bracket {
	char character;
	string bracketType;
	Bracket *left;
	Bracket *right;
} *PBracket;

void InsertTree(PBracket br, PBracket &root) {
	if (NULL == root) {
		root = new Bracket;
		root->character = br->character;
		root->bracketType = br->bracketType;
		root->left = NULL;
		root->right = NULL;
	}
	else if (br->character < root->character)
		InsertTree(br, root->left);
	else if (br->character > root->character)
		InsertTree(br, root->right);
}

void PrintTree(PBracket t) {
	if (t){
		cout << t->character << ": ";
		if (t->left)
			cout << t->left->character << ", ";
		else
			cout << "0, ";
		if (t->right)
			cout << t->right->character << endl;
		else
			cout << "0\n";
		PrintTree(t->left);
		PrintTree(t->right);
	}
}

void Create(PBracket &Head, PBracket &root, string expr) {
	PBracket last = NULL, P;

	for (int i = 0; i < expr.length(); i++) {
		P = new Bracket;
		P->left = NULL;
		P->right = NULL;

		if (expr[i] == '(') {
			P->character = '(';
			P->bracketType = "kragla";
		}
		else if (expr[i] == '[') {
			P->character = '[';
			P->bracketType = "kvadratna";
		}
		else if (expr[i] == '{') {
			P->character = '{';
			P->bracketType = "figurna";
		}
		else if (expr[i] == ')') {
			P->character = ')';
			P->bracketType = "kragla";
		}
		else if (expr[i] == ']') {
			P->character = ']';
			P->bracketType = "kvadratna";
		}
		else if (expr[i] == '}') {
			P->character = '}';
			P->bracketType = "figurna";
		}
		else {
			P->character = expr[i];
			P->bracketType = "";
			InsertTree(P, root);
			continue;
		}

		if (Head) last->left = P;
		else Head = P;
		last = P;
	}
}

void DeleteBrackets(PBracket &Head, PBracket br) {
	PBracket p = Head, prev = NULL;
	while (p) {
		if (p == br) {
			if (p == Head && !p->left) {
				Head = NULL;
			}
			else if (p == Head && p->left) {
				Head = Head->left;
			}
			else if (p != Head) {
				if (prev) prev->left = p->left;
				else Head = p->left;
			}

			delete p;
			break;
		}

		prev = p;
		p = p->left;
	}
}

void Check(PBracket &Head) {
	PBracket p = Head;
	PBracket openingBracket = NULL, closingBracket = NULL;

	while (p) {
		if (p->character == '(' || p->character == '[' || p->character == '{') {
			openingBracket = p;
		}
		else {
			closingBracket = p;
			if (openingBracket) {
				if (openingBracket->bracketType == closingBracket->bracketType) {
					DeleteBrackets(Head, openingBracket);
					DeleteBrackets(Head, closingBracket);
					openingBracket = NULL;
					closingBracket = NULL;
					p = Head;
					continue;
				}
				else {
					cout << endl << "Greshna zatvarqshta skoba!" << endl;
					return;
				}
			}
		}

		p = p->left;
	}

	/*************************************************/
	// ako priemem, che }{ e validno, to skobite se
	// iztrivat.. tova se pravi poradi tova, che v uslovieto
	// na zadachata nqma takuv predviden sluchai za nepravilno
	// postaveni skobi
	bool flag;
	p = Head;
	while (p) {
		flag = false;
		PBracket q = p->left;
		while (q) {
			if (p->bracketType == q->bracketType) {
				DeleteBrackets(Head, p);
				DeleteBrackets(Head, q);
				flag = true;
				break;
			}
			q = q->left;
		}
		if (flag) {
			p = Head;
		}
		else {
			p = p->left;
		}
	}
	/*************************************************/

	if (Head) {
		if (Head->character == '(' || Head->character == '[' || Head->character == '{') {
			cout << endl << "Lipsva zatvarqshta skoba!" << endl;
		}
		else {
			cout << endl << "Mnogo zatvarqshti skobi!" << endl;
		}
	}
	else {
		cout << endl << "OK!" << endl;
	}
}

int main() {
	PBracket listHead = NULL;
	PBracket treeRoot = NULL;
	string expression;
	cout << "Vuvedete izraz: ";
	cin >> expression;

	Create(listHead, treeRoot, expression);
	Check(listHead);
	PrintTree(treeRoot);

	return 0;
}