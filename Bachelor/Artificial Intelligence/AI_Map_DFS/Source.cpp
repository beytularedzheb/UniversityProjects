#include <stdio.h>
#include <iostream>

// Брой върхове в графа
const unsigned n = 8;

// Матрица на съседство на графа
const char A[n][n] = {
	{ 0, 1, 1, 0, 0, 0, 0, 0 }, // A
	{ 1, 0, 1, 1, 0, 0, 0, 0 }, // B
	{ 1, 1, 0, 0, 1, 0, 0, 0 }, // C
	{ 0, 1, 0, 0, 1, 1, 0, 0 }, // D
	{ 0, 0, 1, 1, 0, 0, 1, 0 }, // E
	{ 0, 0, 0, 1, 0, 0, 0, 0 }, // F
	{ 0, 0, 0, 0, 1, 0, 0, 1 }, // G
	{ 0, 0, 0, 0, 0, 0, 1, 0 }, // H
};

char used[n];
unsigned path[n], count;

// Намира всички прости пътища между върховете i и j
void allDFS(unsigned i, unsigned j)
{
	unsigned k;
	if (i == j) {
		path[count] = j;	
		for (unsigned ind = 0; ind <= count; ind++)
			printf("%c ", path[ind] + 'A');
		printf("\n");
		return;
	}
	// маркиране на посетения връх
	used[i] = 1;
	path[count++] = i;
	for (k = 0; k < n; k++) // рекурсия за всички съседи на i
		if (A[i][k] && !used[k])
			allDFS(k, j);
	// връщане: размаркиране на посетения връх
	used[i] = 0; 
	count--;
}
int main(void) {
	setlocale(LC_ALL, "BGR");

	char sv; // Начален връх
	char ev; // Краен връх

	for (unsigned k = 0; k < n; k++)
		used[k] = 0;
	count = 0;
	printf("Задайте началния връх (A..%c): ", n + 64);
	scanf("%c", &sv);
	sv = toupper(sv);

	std::cin.sync();

	printf("Задайте крайния връх (A..%c): ", n + 64);
	scanf("%c", &ev);
	ev = toupper(ev);

	printf("Прости пътища между %c и %c: \n", sv, ev);
	allDFS(sv - 'A', ev - 'A');

	return 0;
}
