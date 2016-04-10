#include <stdlib.h>
#include <iostream>
using namespace std;
#define MAXN 20 /* Максимален брой върхове в графа */
/* Брой върхове в графа */
const unsigned n = 13;
const unsigned ev = 11; /* Краен връх */
unsigned sv; /* Начален връх */

/* Матрица на съседство на графа */
const char A[MAXN][MAXN] = {
	{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //0 - - CAB
	{ 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //1 C - AB
	{ 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }, //2 C A B
	{ 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }, //3 AC - B
	{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }, //4 - CA B
	{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, //5 - A CB
	{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, //6 BC A -
	{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, //7 C BA -
	{ 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //8 BAC - -
	{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }, //9 - BCA -
	{ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 }, //10 - - ACB
	{ 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, //11 ABC - -
	{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }  //12 - CBA -
};

const string States[n] = {
	"- - CAB",
	"C - AB",
	"C A B",
	"AC - B",
	"- CA B",
	"- A CB",
	"BC A -",
	"C BA -",
	"BAC - -",
	"- BCA -",
	"- - ACB",
	"ABC - -",
	"- CBA -"
};

int pred[MAXN];
char used[MAXN];

/* Oбхождане в ширина от даден връх със запазване на предшественика */
void BFS(unsigned i, unsigned end) {
	unsigned queue[MAXN];
	unsigned currentVert, levelVertex, queueEnd, k, p, j;

	for (k = 0; k < n; k++) {
		queue[k] = 0;
	}
	queue[0] = i;
	used[i] = 1;
	currentVert = 0;
	levelVertex = 1;
	queueEnd = 1;

	while (currentVert < queueEnd) { /* докато опашката не е празна */
		for (p = currentVert; p < levelVertex; p++) {
			/* p - вземаме поредния елемент от опашката */
			currentVert++;

			/* за всеки необходен наследник j на queue[p] */
			for (j = 0; j < n; j++) {
				if (A[queue[p]][j] && !used[j]) {
					queue[queueEnd++] = j;
					used[j] = 1;
					pred[j] = queue[p];
					if (pred[end] > -1) {
						// пътят е намерен
						return;
					}
				}
			}
		}

		levelVertex = queueEnd;
	}
}

/* Отпечатва върховете от минималния път и връща дължината му */
unsigned printPath(unsigned j) {
	unsigned count = 1;
	
	if (pred[j] > -1) {
		count += printPath(pred[j]);
	}
	cout << States[j] << endl; /* Oтпечатва поредния връх от намерения път */

	return count;
}

void solve(unsigned start, unsigned end) {
	unsigned k;

	if (sv == ev) {
		cout << "Кубчетата са подредени!" << endl;
	}
	else {
		for (k = 0; k < n; k++) {
			used[k] = 0;
			pred[k] = -1;
		}
		BFS(start, end);
		if (pred[end] > -1) {
			cout << "Резултат:" << endl;
			printPath(end);
		}
	}
}

int main(void) {
	setlocale(LC_ALL, "BGR");
	unsigned ch;
	do {
		cout << "[1]. ABC";
		cout << "  [2]. ACB" << endl;
		cout << "[3]. BAC";
		cout << "  [4]. BCA" << endl;
		cout << "[5]. CAB";
		cout << "  [6]. CBA" << endl;
		cout << "[0]. Изход" << endl;
		cout << "Изберете начален връх: ";
		cin >> ch;
		system("cls");
		switch(ch) {
			case 1: sv = 11; break;
			case 2: sv = 10; break;
			case 3: sv = 8; break;
			case 4: sv = 9; break;
			case 5: sv = 0; break;
			case 6: sv = 12; break;
			case 0: ch = 0; break;
			default: ch = -1; break;
		}
		if (ch != 0 && ch != -1) {
			cout << endl;
			solve(sv, ev);
			cout << endl;
		}
	} while(ch != 0);

	return 0;
}
