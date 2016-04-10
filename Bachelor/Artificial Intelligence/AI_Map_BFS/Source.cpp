#include <stdio.h>
#include <iostream>

#define MAXN 200 /* Максимален брой върхове в графа */
/* Брой върхове в графа */
const unsigned n = 8;
char sv; /* Начален връх */
char ev; /* Краен връх */

/* Матрица на съседство на графа */
const char A[MAXN][MAXN] = {
	{ 0, 1, 1, 0, 0, 0, 0, 0 }, // A - 1
	{ 1, 0, 1, 1, 0, 0, 0, 0 }, // B - 2
	{ 1, 1, 0, 0, 1, 0, 0, 0 }, // C - 3
	{ 0, 1, 0, 0, 1, 1, 0, 0 }, // D - 4
	{ 0, 0, 1, 1, 0, 0, 1, 0 }, // E - 5
	{ 0, 0, 0, 1, 0, 0, 0, 0 }, // F - 6
	{ 0, 0, 0, 0, 1, 0, 0, 1 }, // G - 7
	{ 0, 0, 0, 0, 0, 0, 1, 0 }, // H - 8
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
	printf("%c ", j + 'A'); /* Oтпечатва поредния връх от намерения път */

	return count;
}

void solve(unsigned start, unsigned end) {
	unsigned k;

	for (k = 0; k < n; k++) {
		used[k] = 0;
		pred[k] = -1;
	}
	BFS(start, end);
	if (pred[end] > -1) {
		printf("Намереният път е: \n");
		printf("\nДължината на пътя е %u.\n", printPath(end));
	}
	else
		printf("Не съществува път между двата върха! \n");
}

int main(void) {
	setlocale(LC_ALL, "BGR");

	printf("Задайте началния връх (A..%c): ", n + 64);
	scanf("%c", &sv);
	sv = toupper(sv);

	std::cin.sync();

	printf("Задайте крайния връх (A..%c): ", n + 64, sv);
	scanf("%c", &ev);
	ev = toupper(ev);

	solve(sv - 'A', ev - 'A');

	return 0;
}
