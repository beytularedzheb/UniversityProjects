#include <stdio.h>
#include <iostream>
/* Максимален брой върхове в графа */
#define MAXN 150
#define MAX_VALUE 10000
/* Брой върхове в графа */
const unsigned n = 8;
/* Матрица на теглата (съседство) на графа */
const int A[MAXN][MAXN] =
{
	{ 0, 12, 0, 14, 11, 0, 17, 8 },
	{ 12, 0, 9, 0, 12, 15, 10, 9 },
	{ 0, 9, 0, 18, 14, 31, 0, 9 },
	{ 14, 0, 18, 0, 0, 6, 23, 14 },
	{ 11, 12, 14, 0, 0, 15, 16, 0 },
	{ 0, 15, 31, 6, 15, 0, 8, 16 },
	{ 17, 10, 0, 23, 16, 8, 0, 22 },
	{ 8, 9, 9, 14, 0, 16, 22, 0 },
};
char used[MAXN];
unsigned prev[MAXN];
int T[MAXN];

void prim(void)
{
	int MST = 0; /* тук трупаме цената на минималното покриващо дърво */
	unsigned i, k;
	/* инициализация */
	for (i = 0; i < n; i++) { used[i] = 0; prev[i] = 0; }
	used[0] = 1; /* избираме произволен начален връх */
	for (i = 0; i < n; i++)
		T[i] = (A[0][i]) ? A[0][i] : MAX_VALUE;
	for (k = 0; k < n - 1; k++)
	{
		/* търсене на следващо минимално ребро */
		int minDist = MAX_VALUE, j = -1;
		for (i = 0; i < n; i++)
			if (!used[i])
				if (T[i] < minDist)
				{
					minDist = T[i];
					j = i;
				}
		used[j] = 1;
		printf("(%u,%u) ", prev[j] + 1, j + 1);
		MST += minDist;
		for (i = 0; i < n; i++)
			if (!used[i] && A[j][i])
			{
				if (T[i] > A[j][i])
				{
					T[i] = A[j][i];
					/* запазване на предшественика
					за евентуално отпечатване на следващо минимално ребро */
					prev[i] = j;
				}
			}
	}
	printf("\nЦената на минималното покриващо дърво е %d.\n", MST);
	printf("\n");
}

int main(void)
{
	setlocale(LC_ALL, "BGR");
	prim();

	return 0;
}